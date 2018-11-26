using CmsData;
using CmsData.Codes;
using CmsWeb.Areas.Main.Models;
using Dapper;
using Elmah;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web.Hosting;
using System.Web.Mvc;
using UtilityExtensions;

namespace CmsWeb.Areas.Main.Controllers
{
    [RouteArea("Main", AreaPrefix = "Email"), Route("{action}/{id?}")]
    public class EmailController : CmsStaffController
    {
        [ValidateInput(false)]
        [Route("~/Email/{id:guid}")]
        public ActionResult Index(Guid id, int? templateID, bool? parents, string body, string subj, bool? ishtml, bool? ccparents, bool? nodups, int? orgid, int? personid, bool? recover, bool? onlyProspects, bool? membersAndProspects)
        {
            if (Util.SessionTimedOut())
            {
                return Redirect("/Errors/SessionTimeout.htm");
            }

            if (!body.HasValue())
            {
                body = TempData["body"] as string;
            }

            if (!subj.HasValue() && templateID != 0)
            {
                if (templateID == null)
                {
                    return View("SelectTemplate", new EmailTemplatesModel
                    {
                        WantParents = parents ?? false,
                        QueryId = id,
                    });
                }

                DbUtil.LogActivity("Emailing people");

                var m = new MassEmailer(id, parents, ccparents, nodups);

                m.Host = Util.Host;

                if (body.HasValue())
                {
                    templateID = SaveDraft(null, null, 0, null, body);
                }

                ViewBag.templateID = templateID;
                m.OrgId = orgid;
                m.guid = id;
                if (recover == true)
                {
                    m.recovery = true;
                }

                return View("Compose", m);
            }

            // using no templates

            DbUtil.LogActivity("Emailing people");

            var me = new MassEmailer(id, parents, ccparents, nodups);
            me.Host = Util.Host;
            me.OnlyProspects = onlyProspects.GetValueOrDefault();

            // Unless UX-AllowMyDataUserEmails is true, CmsController.OnActionExecuting() will filter them
            if (!User.IsInRole("Access"))
            {
                if (templateID != 0 || (!personid.HasValue && !orgid.HasValue))
                {
                    return Redirect($"/Person2/{Util.UserPeopleId}");
                }
            }

            if (personid.HasValue)
            {
                me.AdditionalRecipients = new List<int> { personid.Value };

                var person = DbUtil.Db.LoadPersonById(personid.Value);
                ViewBag.ToName = person?.Name;
            }
            else if (orgid.HasValue)
            {
                var org = DbUtil.Db.LoadOrganizationById(orgid.Value);
                GetRecipientsFromOrg(me, orgid.Value, onlyProspects, membersAndProspects);
                me.Count = me.Recipients.Count();
                ViewBag.ToName = org?.OrganizationName;
            }

            if (body.HasValue())
            {
                me.Body = Server.UrlDecode(body);
            }

            if (subj.HasValue())
            {
                me.Subject = Server.UrlDecode(subj);
            }

            ViewData["oldemailer"] = "/EmailPeople.aspx?id=" + id
                 + "&subj=" + subj + "&body=" + body + "&ishtml=" + ishtml
                 + (parents == true ? "&parents=true" : "");

            if (parents == true)
            {
                ViewData["parentsof"] = "with ParentsOf option";
            }

            return View("Index", me);
        }

        private static void GetRecipientsFromOrg(MassEmailer me, int orgId, bool? onlyProspects, bool? membersAndProspects)
        {
            var members = DbUtil.Db.OrgPeopleCurrent(orgId).Select(x => DbUtil.Db.LoadPersonById(x.PeopleId));
            var prospects = DbUtil.Db.OrgPeopleProspects(orgId, false).Select(x => DbUtil.Db.LoadPersonById(x.PeopleId));

            me.Recipients = new List<string>();
            me.RecipientIds = new List<int>();

            var recipients = new List<Person>();

            if (onlyProspects.GetValueOrDefault())
            {
                recipients = prospects.ToList();
            }
            else if (membersAndProspects.GetValueOrDefault())
            {
                recipients = members.Union(prospects).ToList();
            }
            else
            {
                recipients = members.ToList();
            }

            foreach (var r in recipients)
            {
                me.Recipients.Add(r.ToString());
                me.RecipientIds.Add(r.PeopleId);
            }
        }

        public ActionResult EmailBody(string id)
        {
            var i = id.ToInt();
            var c = ViewExtensions2.GetContent(i);
            if (c == null)
            {
                return new EmptyResult();
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(c.Body);
            var bvedits = doc.DocumentNode.SelectNodes("//div[contains(@class,'bvedit') or @bvedit]");
            if (bvedits == null || !bvedits.Any())
            {
                c.Body = $"<div bvedit='discardthis'>{c.Body}</div>";
            }

            ViewBag.content = c;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveDraft(MassEmailer m, int saveid, string name, int roleid)
        {
            var id = SaveDraft(saveid, name, roleid, m.Subject, m.Body);

            System.Diagnostics.Debug.Print("Template ID: " + id);

            ViewBag.parents = m.wantParents;
            ViewBag.templateID = id;

            return View("Compose", m);
        }

        private static int SaveDraft(int? draftId, string name, int roleId, string draftSubject, string draftBody)
        {
            Content content = null;

            if (draftId.HasValue && draftId > 0)
            {
                content = DbUtil.ContentFromID(draftId.Value);
            }

            if (content != null)
            {
                DbUtil.Db.ArchiveContent(draftId);
            }
            else
            {
                content = new Content
                {
                    Name = name.HasValue()
                        ? name
                        : "new draft " + DateTime.Now.FormatDateTm(),
                    TypeID = ContentTypeCode.TypeSavedDraft,
                    RoleID = roleId,
                    OwnerID = Util.UserId
                };
            }

            content.Title = draftSubject;
            content.Body = GetBody(draftBody);
            content.Archived = null;
            content.ArchivedFromId = null;

            content.DateCreated = DateTime.Now;

            if (!draftId.HasValue || draftId == 0)
            {
                DbUtil.Db.Contents.InsertOnSubmit(content);
            }

            DbUtil.Db.SubmitChanges();

            return content.Id;
        }

        private static string GetBody(string body)
        {
            if (body == null)
            {
                body = "";
            }

            body = body.RemoveGrammarly();
            var doc = new HtmlDocument();
            doc.LoadHtml(body);
            var ele = doc.DocumentNode.SelectSingleNode("/div[@bvedit='discardthis']");
            if (ele != null)
            {
                body = ele.InnerHtml;
            }

            return body;
        }

        [HttpPost]
        public ActionResult ContentDeleteDrafts(Guid queryid, bool parents, int[] draftId)
        {
            using (var cn = new SqlConnection(Util.ConnectionString))
            {
                cn.Open();
                cn.Execute("delete from dbo.Content where id in @ids", new { ids = draftId });
            }
            return RedirectToAction("Index", new { id = queryid, parents });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QueueEmails(MassEmailer m)
        {
            m.Body = GetBody(m.Body);
            if (UsesGrammarly(m))
            {
                return Json(new { error = GrammarlyNotAllowed });
            }

            if (TooLarge(m))
            {
                return Json(new { error = TooLargeError });
            }

            if (!m.Subject.HasValue() || !m.Body.HasValue())
            {
                return Json(new { id = 0, error = "Both subject and body need some text." });
            }

            if (!User.IsInRole("Admin") && m.Body.Contains("{createaccount}", ignoreCase: true))
            {
                return Json(new { id = 0, error = "Only Admin can use {createaccount}." });
            }

            if (Util.SessionTimedOut())
            {
                Session["massemailer"] = m;
                return Content("timeout");
            }

            DbUtil.LogActivity("Emailing people");

            if (m.EmailFroms().Count(ef => ef.Value == m.FromAddress) == 0)
            {
                return Json(new { id = 0, error = "No email address to send from." });
            }

            m.FromName = m.EmailFroms().First(ef => ef.Value == m.FromAddress).Text;

            int id;
            try
            {
                var eq = m.CreateQueue();
                if (eq == null)
                {
                    throw new Exception("No Emails to send (tag does not exist)");
                }

                id = eq.Id;

                // If there are additional recipients, add them to the queue
                if (m.AdditionalRecipients != null)
                {
                    foreach (var pid in m.AdditionalRecipients)
                    {
                        // Protect against duplicate PeopleIDs ending up in the queue
                        var q3 = from eqt in DbUtil.Db.EmailQueueTos
                                 where eqt.Id == eq.Id
                                 where eqt.PeopleId == pid
                                 select eqt;
                        if (q3.Any())
                        {
                            continue;
                        }
                        eq.EmailQueueTos.Add(new EmailQueueTo
                        {
                            PeopleId = pid,
                            OrgId = eq.SendFromOrgId,
                            Guid = Guid.NewGuid(),
                        });
                    }
                    DbUtil.Db.SubmitChanges();
                }

                if (m.RecipientIds != null)
                {
                    foreach (var pid in m.RecipientIds)
                    {
                        // Protect against duplicate PeopleIDs ending up in the queue
                        var q3 = from eqt in DbUtil.Db.EmailQueueTos
                                 where eqt.Id == eq.Id
                                 where eqt.PeopleId == pid
                                 select eqt;
                        if (q3.Any())
                        {
                            continue;
                        }
                        eq.EmailQueueTos.Add(new EmailQueueTo
                        {
                            PeopleId = pid,
                            OrgId = eq.SendFromOrgId,
                            Guid = Guid.NewGuid(),
                        });
                    }
                    DbUtil.Db.SubmitChanges();
                }

                if (eq.SendWhen.HasValue)
                {
                    return Json(new { id = 0, content = "Emails queued to be sent." });
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(new { id = 0, error = ex.Message });
            }

            var host = Util.Host;
            var currorgid = DbUtil.Db.CurrentSessionOrgId;
            // save these from HttpContext to set again inside thread local storage
            var userEmail = Util.UserEmail;
            var isInRoleEmailTest = User.IsInRole("EmailTest");
            var isMyDataUser = User.IsInRole("Access") == false;

            try
            {
                ValidateEmailReplacementCodes(DbUtil.Db, m.Body, new MailAddress(m.FromAddress));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

            var onlyProspects = m.OnlyProspects;

            HostingEnvironment.QueueBackgroundWorkItem(ct =>
            {
                try
                {
                    var db = DbUtil.Create(host);
                    var cul = db.Setting("Culture", "en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cul);
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cul);
                    // set these again inside thread local storage
                    db.SetCurrentOrgId(currorgid);
                    Util.UserEmail = userEmail;
                    Util.IsInRoleEmailTest = isInRoleEmailTest;
                    Util.IsMyDataUser = isMyDataUser;
                    db.SendPeopleEmail(id, onlyProspects);
                }
                catch (Exception ex)
                {
                    var ex2 = new Exception($"Emailing error for queueid {id} on {host}\n{ex.Message}", ex);
                    var cb = new SqlConnectionStringBuilder(Util.ConnectionString) { InitialCatalog = "ELMAH" };
                    var errorLog = new SqlErrorLog(cb.ConnectionString) { ApplicationName = "BVCMS" };
                    errorLog.Log(new Error(ex2));

                    var db = DbUtil.Create(host);
                    var equeue = db.EmailQueues.Single(ee => ee.Id == id);
                    equeue.Error = ex.Message.Truncate(200);
                    db.SubmitChanges();
                }
            });
            return Json(new { id = id });
        }

        private const string TooLargeError = "This email is too large. It appears that it may contain an embedded image. Please see <b><a href='http://docs.touchpointsoftware.com/EmailTexting/EmailFileUpload.html' target='_blank'>this document</a></b> for instructions on how to send an image.";
        private static bool TooLarge(MassEmailer m)
        {
            return (m.Body.Contains("data:image") && m.Body.Length > 100000) || m.Body.Length > 400000;
        }
        private const string GrammarlyNotAllowed = "It appears that you are using Grammarly. Please see <b><a href='https://blog.touchpointsoftware.com/2016/06/29/warning-re-grammarly-and-ck-editor/' target='_blank'>this document</a></b> for important information about why we cannot allow Grammarly";
        private static bool UsesGrammarly(MassEmailer m)
        {
            return m.Body.Contains("btn_grammarly");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult TestEmail(MassEmailer m)
        {
            m.Body = GetBody(m.Body);
            if (UsesGrammarly(m))
            {
                return Json(new { error = GrammarlyNotAllowed });
            }

            if (TooLarge(m))
            {
                return Json(new { error = TooLargeError });
            }

            if (Util.SessionTimedOut())
            {
                Session["massemailer"] = m;
                return Content("timeout");
            }

            if (m.EmailFroms().Count(ef => ef.Value == m.FromAddress) == 0)
            {
                return Json(new { error = "No email address to send from." });
            }

            m.FromName = m.EmailFroms().First(ef => ef.Value == m.FromAddress).Text;
            var from = Util.FirstAddress(m.FromAddress, m.FromName);
            var p = DbUtil.Db.LoadPersonById(Util.UserPeopleId ?? 0);

            try
            {
                ValidateEmailReplacementCodes(DbUtil.Db, m.Body, from);

                DbUtil.Db.CopySession();
                DbUtil.Db.Email(from, p, null, m.Subject, m.Body, false);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
            return Content("Test email sent.");
        }

        [HttpPost]
        public ActionResult TaskProgress(string id)
        {
            var idi = id.ToInt();
            var queue = SetProgressInfo(idi);
            if (queue == null)
            {
                return Json(new { error = "No queue." });
            }

            var title = string.Empty;
            var message = string.Empty;

            if ((bool)ViewData["finished"])
            {
                title = "Email has completed.";
            }
            else if (((string)ViewData["error"]).HasValue())
            {
                return Json(new { error = (string)ViewData["error"] });
            }
            else
            {
                title = "Your emails have been queued and will be sent.";
            }

            message = $"Queued: {ViewData["queued"]}\nStarted: {ViewData["started"]}\nTotal Emails: {ViewData["total"]}\nSent: {ViewData["sent"]}\nElapsed: {ViewData["elapsed"]}";

            return Json(new { title = title, message = message });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateVoteTag(int orgid, bool confirm, string smallgroup, string message, string text, string votetagcontent)
        {
            if (votetagcontent.HasValue())
            {
                return Content($"<votetag id={orgid} confirm={confirm} smallgroup=\"{smallgroup}\" message=\"{message}\">{votetagcontent}</votetag>");
            }

            return Content($"{{votelink id={orgid} confirm={confirm} smallgroup=\"{smallgroup}\" message=\"{message}\" text=\"{text}\"}}");
        }

        public ActionResult CheckQueued()
        {
            var q = from e in DbUtil.Db.EmailQueues
                    where e.SendWhen < DateTime.Now
                    where e.Sent == null
                    select e;

            foreach (var emailqueue in q)
            {
                DbUtil.Db.SendPeopleEmail(emailqueue.Id);
            }

            return Content("done");
        }

        private EmailQueue SetProgressInfo(int id)
        {
            var emailqueue = DbUtil.Db.EmailQueues.SingleOrDefault(e => e.Id == id);
            if (emailqueue != null)
            {
                var q = from et in DbUtil.Db.EmailQueueTos
                        where et.Id == id
                        select et;
                ViewData["queued"] = emailqueue.Queued.ToString("g");
                ViewData["total"] = q.Count();
                ViewData["sent"] = q.Count(e => e.Sent != null);
                ViewData["finished"] = false;
                if (emailqueue.Started == null)
                {
                    ViewData["started"] = "not started";
                    ViewData["completed"] = "not started";
                    ViewData["elapsed"] = "not started";
                }
                else
                {
                    ViewData["started"] = emailqueue.Started.Value.ToString("g");
                    var max = q.Max(et => et.Sent);
                    max = max ?? DateTime.Now;

                    if (emailqueue.Sent == null && !emailqueue.Error.HasValue())
                    {
                        ViewData["completed"] = "running";
                    }
                    else
                    {
                        ViewData["completed"] = max;
                        if (emailqueue.Error.HasValue())
                        {
                            ViewData["Error"] = emailqueue.Error;
                        }
                        else
                        {
                            ViewData["finished"] = true;
                        }
                    }
                    ViewData["elapsed"] = max.Value.Subtract(emailqueue.Started.Value).ToString(@"h\:mm\:ss");
                }
            }
            return emailqueue;
        }

        private static void ValidateEmailReplacementCodes(CMSDataContext db, string emailText, MailAddress fromAddress)
        {
            var er = new EmailReplacements(db, emailText, fromAddress);
            er.DoReplacements(db, DbUtil.Db.LoadPersonById(Util.UserPeopleId ?? 0));
        }
    }
}

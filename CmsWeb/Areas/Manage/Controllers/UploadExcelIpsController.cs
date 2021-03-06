using CmsData;
using CmsWeb.Lifecycle;
using CmsWeb.Models;
using OfficeOpenXml;
using System;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using UtilityExtensions;

namespace CmsWeb.Areas.Manage.Controllers
{
    [Authorize(Roles = "Developer,UploadBridgePlus")]
    [RouteArea("Manage", AreaPrefix = "UploadExcelIps"), Route("{action=index}")]
    public class UploadExcelIpsController : CmsStaffController
    {
        public UploadExcelIpsController(IRequestManager requestManager) : base(requestManager)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(HttpPostedFileBase file, bool noupdate, bool ignoremissinggifts)
        {
            string host = Util.Host;
            var pid = Util.UserPeopleId;

            var package = new ExcelPackage(file.InputStream);

            HostingEnvironment.QueueBackgroundWorkItem(ct =>
            {
                try
                {
                    var localDbInstance = DbUtil.Create(host);

                    UploadPeopleRun testrun = ProcessImport(localDbInstance, noupdate, ignoremissinggifts, host, pid, package, true);
                    UploadPeopleRun realrun = ProcessImport(localDbInstance, noupdate, ignoremissinggifts, host, pid, package, false);
                }
                catch (Exception ex)
                {
                    //CurrentDatabase.Dispose();
                    //db = DbUtil.Create(host);

                    //var q = from r in CurrentDatabase.UploadPeopleRuns
                    //        where r.Id == CurrentDatabase.UploadPeopleRuns.Max(rr => rr.Id)
                    //        select r;
                    Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
                    //var rt = q.Single();
                    //rt.Error = ex.Message.Truncate(200);
                    //CurrentDatabase.SubmitChanges();
                }
            });
            return Redirect("/UploadExcelIps/Progress");
        }

        private UploadPeopleRun ProcessImport(CMSDataContext db, bool noupdate, bool ignoremissinggifts, string host, int? pid, ExcelPackage package, bool testing)
        {
            var rt = new UploadPeopleRun { Started = DateTime.Now, Count = 0, Processed = 0 };
            db.UploadPeopleRuns.InsertOnSubmit(rt);
            db.SubmitChanges();

            var upload = new UploadExcelIpsModel(db, host, pid ?? 0, noupdate, ignoremissinggifts, testing);
            upload.DoUpload(package);
            return rt;
        }

        [HttpGet]
        public ActionResult Progress()
        {
            var rt = CurrentDatabase.UploadPeopleRuns.OrderByDescending(mm => mm.Id).First();
            return View(rt);
        }

        [HttpPost]
        public JsonResult Progress2()
        {
            var r = CurrentDatabase.UploadPeopleRuns.OrderByDescending(mm => mm.Id).First();
            return Json(new { r.Count, r.Error, r.Processed, Completed = r.Completed.ToString(), r.Running, r.Description });
        }

    }
}


﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Web.Mvc;
using System.Xml.Linq;
using UtilityExtensions;
using System.Linq;
using CmsData;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CmsWeb.Models
{
    public class TaskNotesExcelResult : ActionResult
    {
        int qid;
        public TaskNotesExcelResult(int id)
        {
            qid = id;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var Response = context.HttpContext.Response;
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=CMSTasks.xls");
            Response.Charset = "";

                var qB = DbUtil.Db.LoadQueryById(qid);
                var q = from p in DbUtil.Db.People.Where(qB.Predicate())
                        let t = p.TasksAboutPerson.OrderByDescending(t => t.CreatedOn).FirstOrDefault(t => t.Notes != null)
                        where t != null
                        select new
                        {
                            p.Name,
                            t.Notes,
                            t.CreatedOn
                        };
            var dg = new DataGrid();
            dg.DataSource = q;
            dg.DataBind();
            dg.RenderControl(new HtmlTextWriter(Response.Output));
            Response.End();
        }
    }
}
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CmsWeb.Models.TaskModel>" %>
<% foreach (var list in Model.FetchTaskLists())
   { %>
   <li><a href='#<%=list.Id %>'><span><%=list.Name%></span></a></li>
<% } %>

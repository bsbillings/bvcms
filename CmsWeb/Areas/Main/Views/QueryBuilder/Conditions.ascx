<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CmsWeb.Models.QueryModel>" %>
<% foreach(var c in Model.ConditionList())
   { %>
   <li class="conditionPopup" id='<%=c.Clause.QueryId %>'>
        <img src="/images/1pix.gif" width="<%=c.Level.ToString() %>" height="1px" />
        <img src="/images/DownRight.gif" width="19px" height="12px" />
        <a href='#'><%=c.Clause.ToString() %></a>
   </li>
<% } %>


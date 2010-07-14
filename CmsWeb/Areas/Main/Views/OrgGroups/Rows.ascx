﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CmsWeb.Models.OrgGroupsModel>" %>
<% foreach(var om in Model.FetchOrgMemberList())
   { %>
	<tr <%=om.IsInGroup() %>>
		<td><input name="list" type="checkbox" value="<%=om.PeopleId %>" /></td>
		<td class="tip" title="<%=om.ToolTip %>"><%=om.Name %></td>
		<td><%=om.Address %><br />
		<%=om.CityStateZip %></td>
		<td><%=om.Gender %> </td>
		<td><%=om.Age %> </td>
		<td><%=om.Request %> </td>
		<td><%=om.GroupsDisplay %> </td>
	</tr>
<% } %>


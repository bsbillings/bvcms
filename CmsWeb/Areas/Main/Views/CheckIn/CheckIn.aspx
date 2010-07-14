<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CmsWeb.Models.CheckInRecModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="/Content/jquery.tooltip.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%= SquishIt.Framework.Bundle.JavaScript()
                .Add("/Content/js/jquery.jeditable.js")
                .Add("/Content/js/jquery.autocomplete.js")
                .Add("/Scripts/CheckIn.js")
                .Render("/Content/CheckIn_#.js")
            %>        

    <%=Html.Hidden("OrgId") %>
    <%=Html.Hidden("PeopleId", Model.person.PeopleId) %>
    <table class="checkin" cellpadding="5">
        <tr>
            <td>
                <img src='<%=Model.person.ImageUrl %>' /><br />
                <a href='tkup:<%=Model.person.PeopleId %>,<%=Model.guid %>,<%=Model.host %>' id="tkup">Take Picture</a>
            </td>
            <td>
            <h2>
                CheckIn for
                <%=Model.OrgName %></h2>
                <table cellpadding="3">
                    <tr>
                        <th>
                            Name:
                        </th>
                        <td>
                            <a href='/Person/Index/<%=Model.person.PeopleId %>'>
                                <%=Model.person.Name%></a>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Addr Line 1:
                        </th>
                        <td>
                            <%=Model.person.Addr1 %>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Addr Line 2:
                        </th>
                        <td>
                            <%=Model.person.Addr2 %>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            City, State, Zip:
                        </th>
                        <td>
                            <%=Model.person.CityStateZip%>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Home Phone:
                        </th>
                        <td>
                            <%=Model.person.Phone%>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Cell:
                        </th>
                        <td>
                            <%=Model.person.Cell %>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Email:
                        </th>
                        <td>
                            <%=Model.person.Email %>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Birthday:
                        </th>
                        <td>
                            <%=Model.person.Birthday %>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            School:
                        </th>
                        <td>
                            <a id='editschool' title="click to edit" href='#'>
                                <%=Model.person.School%></a>
                            <input type="text" id='s.<%=Model.person.PeopleId %>' class="schooltext" value='<%=Model.person.School%>' /><br />
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Graduate Year:
                        </th>
                        <td>
                            <span id='y.<%=Model.person.PeopleId %>' title="click to edit" class="edit" href='#'>
                                <%=Model.person.Year%></span>
                        </td>
                    </tr>
                    <tr>
                        <th nowrap="nowrap">
                            Notes:
                        </th>
                        <td>
                            <span id='n.<%=Model.person.PeopleId %>' class='editarea'>
                                <%=Model.person.CheckInNotes%></span>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div>
        KeyCard #:
        <input type="text" id="KeyCard" />
        New Card?
        <input type="checkbox" id="newCard" />
    </div>
    <h3>Family</h3>
    <ul>
    <% foreach (var m in Model.GetFamilyMembers())
       { %>
       <li><a href="/CheckIn/CheckIn/<%=Model.OrgId %>?pid=<%=m.PeopleId %>"><%=m.Name %></a></li>
    <% } %>
    </ul>
    <div id="GOdialog" style="display: none; cursor: default">
        <h1>
            Click GO to refresh page.</h1>
        <input type="button" id="GOrefresh" value="GO" />
    </div>
</asp:Content>

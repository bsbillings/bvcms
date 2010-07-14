﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InReachRpt.aspx.cs" Inherits="CmsWeb.InReachRpt" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"  Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>In Reach Report</title>
</head>
<body>
    <form id="form1" runat="server">
<%--    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="1600px" Width="100%" SizeToReportContent="True">
        <LocalReport ReportPath="Report/PastAttendeeRpt.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="PastAttendeeInfo" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="OrganizationInfo" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
--%>    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="PastAttendees"
        TypeName="CMSPresenter.AttendenceController" >
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="orgid" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetOrganizationInfo"
        TypeName="CMSPresenter.AttendenceController">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="orgid" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>

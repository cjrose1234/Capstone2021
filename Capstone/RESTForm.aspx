<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="RESTForm.aspx.cs" Inherits="Capstone.RESTForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <asp:Label ID="lblSelectAnalysis" runat="server" Text="SelectAnalysis"></asp:Label>
    <asp:DropDownList ID="ddlSAList" runat="server"></asp:DropDownList>
    <asp:Label ID="lblRequests" runat="server" Text="Choose Request:"></asp:Label>
    <asp:DropDownList ID="ddlRequest" runat="server">
        <asp:ListItem Text="gettitle"></asp:ListItem>
        <asp:ListItem Text="getsource"></asp:ListItem>
        <asp:ListItem Text="getpeople"></asp:ListItem>
        <asp:ListItem Text="getplaces"></asp:ListItem>
        <asp:ListItem Text="getvisinteractionschord"></asp:ListItem>
        <asp:ListItem Text="getvisnarrativeweb"></asp:ListItem>
        <asp:ListItem Text="getviswordcloud-subjects"></asp:ListItem>
        <asp:ListItem Text="getviswordcloud-places"></asp:ListItem>
        <asp:ListItem Text="getviswordcloud-people"></asp:ListItem>
        <asp:ListItem Text="getviswordcloud-groups"></asp:ListItem>
        <asp:ListItem Text="getsentencedetails"></asp:ListItem>
        <asp:ListItem Text="showdashboard"></asp:ListItem>
        <asp:ListItem Text="showbootstrapdashboard"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnMakeRequest" runat="server" Text="Button" OnClick="btnMakeRequest_Click" />
    <br />
    <asp:TextBox ID="txtDisplay" runat="server" Rows="15" Height="200" Width="400" TextMode="MultiLine" ></asp:TextBox>
    <div runat="server" id="displayViz"></div>
</asp:Content>

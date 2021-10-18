<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="addAffiliation.aspx.cs" Inherits="Capstone.addAffiliation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Add Affiliations" Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="lblOrganizations" runat="server" Text="Organizations:"></asp:Label>
    <br />
    <asp:DropDownList ID="lstOrganizations" runat="server" Width="300"></asp:DropDownList>
    <br />
    <asp:Button ID="btnJoinOrg" runat="server" Text="Request to join" OnClick="btnJoinOrg_Click"/>
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
</asp:Content>

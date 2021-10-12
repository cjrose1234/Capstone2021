<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="Capstone.userLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <asp:LinkButton ID="lnkCreate" runat="server" OnClick="lnkCreate_Click">Create User</asp:LinkButton>
    <br />
    <br />
    <strong>Login</strong><br />
    Username:
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    Password:
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
</asp:Content>

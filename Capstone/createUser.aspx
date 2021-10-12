<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="createUser.aspx.cs" Inherits="Capstone.createUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Login</asp:LinkButton>
    <br />
    <br />
    <strong>Create User</strong><br />
    First Name:&nbsp;
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Last Name:
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Email Address:
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Phone Number:
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPhone"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Mailing Address:
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Purpose of Use:
    <br />
    <asp:TextBox ID="txtPurpose" runat="server" Width="150" Height="200" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPurpose"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Username:
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUsername"
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    Password:
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:LinkButton ID="lnkAnother" runat="server" OnClick="lnkAnother_Click" Visible="False">Create Another</asp:LinkButton>
</asp:Content>

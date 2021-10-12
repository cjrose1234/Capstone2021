<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Capstone.UserPage" %>
<%-- Cooper Rosenberg 9/27/2021 This is the chunk that handles user editing--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <asp:Label ID="lblUserStatus" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click"/>
    <br />
    <br />
    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtFirstName" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="firstNameRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtLastName" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="lastNameRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address:"></asp:Label>
    <br />
    <asp:TextBox ID="txtEmailAddress" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="emailRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmailAddress" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
    <br />
    <asp:TextBox ID="txtPhoneNumber" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="phoneRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPhoneNumber" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
    <br />
    <asp:TextBox ID="txtAddress" runat="server" Width="300"></asp:TextBox>
    <asp:RequiredFieldValidator ID="addressRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblPurpose" runat="server" Text="Purpose of use:"></asp:Label>
    <br />
    <asp:TextBox ID="txtPurpose" runat="server" Width="300" Height="200" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="purposeRequired" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPurpose" 
        Text="Must not be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnEdit" runat="server" Text="Edit User" OnClick="btnEdit_Click"/>
    <asp:Label ID="lblEditComplete" runat="server" Text=""></asp:Label>
    <br />
    
</asp:Content>

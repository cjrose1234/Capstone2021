<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="createOrg.aspx.cs" Inherits="Capstone.createOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <br />
    <asp:Label ID="lblCreateOrg" runat="server" Text="Create Organization"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblOrgName" runat="server" Text="Organization Name:"></asp:Label>
    <asp:TextBox ID="txtOrgName" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtOrgNameVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtOrgName"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblOrgStreet" runat="server" Text="Street Address:"></asp:Label>
    <asp:TextBox ID="txtStreet" runat="server" Width="300"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtStreetVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtStreet"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblOrgCity" runat="server" Text="City:"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtCityVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblOrgState" runat="server" Text="State:"></asp:Label>
    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtStateVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtState"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblOrgZip" runat="server" Text="Zip Code:"></asp:Label>
    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtZipVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtZip"></asp:RequiredFieldValidator>
    <br />
    <br />
    Organization Email:
    <asp:TextBox ID="txtEmail" runat="server" Width="225"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtEmailVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
    <br />
    Organization Phone Number:
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="txtPhoneVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnCommitOrg" runat="server" Text="Create Organization" OnClick="btnCommitOrg_Click"/>
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnAnother" runat="server" Text="Create Another" Visible="false" OnClick="btnAnother_Click" CausesValidation="false"/>
</asp:Content>

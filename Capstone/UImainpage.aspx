<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="UImainpage.aspx.cs" Inherits="Capstone.UImainpage" %>
<%-- Cooper Rosenberg 9/27/2021 This is the chunk that users will first arrive at. It has buttons to lead to other parts of the web app --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Table ID="Table1" runat="server" CellSpacing="75" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="#61FFCF" BackColor="DarkGray">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblViewUserLogin" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewLoginPage" runat="server" Text="Go To" OnClick="btnViewLoginPage_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblCreateUser" runat="server" Text="Create User"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCreateUser" runat="server" Text="Go To" OnClick="btnCreateUser_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblStoreTextPage" runat="server" Text="Store/Manage New Text"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnStoreTextPage" runat="server" Text="Go to" OnClick="btnStoreTextPage_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblViewAnalysisPage" runat="server" Text="View your analyses"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewAnalysisPage" runat="server" Text="Go to" OnClick="btnViewAnalysisPage_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblStoryAnalysis" runat="server" Text="See your Story Analysis listings"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnStoryAnalysis" runat="server" Text="Go To" OnClick="btnStoryAnalysis_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblFriendsAnalysis" runat="server" Text="See Analysis Commons"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnFriendsAnalysis" runat="server" Text="Go To" OnClick="btnFriendsAnalysis_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCreateOrg" runat="server" Text="Create Organization"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCreateOrg" runat="server" Text="Go To" OnClick="btnCreateOrg_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblAffiliation" runat="server" Text="Affiliate with an organization"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAffiliation" runat="server" Text="Go To" OnClick="btnAffiliation_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>

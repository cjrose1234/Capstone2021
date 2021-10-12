<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="analysisCommons.aspx.cs" Inherits="Capstone.analysisCommons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <br />
    <asp:Label ID="lblAnalysisCommons" runat="server" Text="Analysis Commons"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblSearchForUser" runat="server" Text="Search for User:"></asp:Label>
    <asp:TextBox ID="txtSearchForUser" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearchForUser" runat="server" Text="->" OnClick="btnSearchForUser_Click" />
    <br />
    <asp:ListBox ID="lstUsers" runat="server" Width="300" Height="100"></asp:ListBox>
    <br />
    <asp:Button ID="btnFriendUser" runat="server" Text="Add friend" OnClick="btnFriendUser_Click" />
    <br />
    <br />
    <br />
    <asp:Label ID="lblFriends" runat="server" Text="Friends:"></asp:Label>
    <br />
    <asp:ListBox ID="lstFriends" runat="server" Width="300" Height="100"></asp:ListBox>
    <br />
    <asp:Button ID="btnShowAnalysis" runat="server" Text="Show selected friend Analyses" OnClick="btnShowAnalysis_Click"/>
    <asp:Button ID="btnRemoveFriend" runat="server" Text="Remove friend" OnClick="btnRemoveFriend_Click"/>
    <br />
    <asp:ListBox ID="lstFriendAnalysis" runat="server" Width="300" Height="100"></asp:ListBox>
    <br />
    <asp:Button ID="btnShowFriendAnalysis" runat="server" Text="Show Analysis" OnClick="btnShowFriendAnalysis_Click"/>
    <br />
    <asp:TextBox ID="txtAnalysis" runat="server" Width="300" Height="200" TextMode="MultiLine"></asp:TextBox>
</asp:Content>

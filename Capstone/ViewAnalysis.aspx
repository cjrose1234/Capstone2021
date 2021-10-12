<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="ViewAnalysis.aspx.cs" Inherits="Capstone.ViewAnalysis" %>
<%-- Cooper Rosenberg 9/27/2021 This is the chunk that handles analysis requests --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectedText" runat="server" Text="Send Analysis Request:"></asp:Label>
                <br />
                <asp:DropDownList ID="lstManageTexts" runat="server" Width="300">
                    <asp:ListItem Text="Please select Text" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSendRequest" runat="server" Text="Send" OnClick="btnSendRequest_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <br />
                <asp:Label ID="lblCompletedRequests" runat="server" Text="Completed Requests:"></asp:Label>
                <br />
                <asp:ListBox ID="lstCompletedRequests" runat="server" Width="250" Height="200"></asp:ListBox>
                <asp:Button ID="btnShowResults" runat="server" Text="Show Results" OnClick="btnShowResults_Click"/>
                <br />
                <asp:Button ID="btnDeleteAnalysis" runat="server" Text="Delete" OnClick="btnDeleteAnalysis_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblResults" runat="server" Text="Results:"></asp:Label>
                <br />
                <asp:TextBox ID="txtResults" runat="server" Height="200" Width="200" TextMode="MultiLine"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

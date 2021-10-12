<%@ Page Title="" Language="C#" MasterPageFile="~/UImasterform.Master" AutoEventWireup="true" CodeBehind="TextStorage.aspx.cs" Inherits="Capstone.TextStorage" %>
<%-- Cooper Rosenberg 9/27/2021 This is the chunk that handles the text storage --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainPage" runat="server">
    
    <br />
    <asp:Label ID="lblStoreTextTitle" runat="server" Text="Text Title:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBoxTextTitle" runat="server" Width="300" AutoPostBack="false" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="textTitleVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtBoxTextTitle"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="txtTitleUniqueValidate" runat="server" ErrorMessage="CustomValidator" Text="Must be unique title!" ForeColor="Red" 
        OnServerValidate="txtTitleUniqueValidate_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lblStoreTextSource" runat="server" Text="Text Source:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBoxTextSource" runat="server" Width="300" AutoPostBack="false" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="textSourceVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
        ForeColor="Red" ControlToValidate="txtBoxTextSource"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblStoreTextBody" runat="server" Text="Text Body:"></asp:Label>
                <br />
                <asp:Label ID="lblTextFile" runat="server" Text="Choose File to Upload:"></asp:Label>
                <asp:FileUpload ID="fileUploadText" runat="server" />
                <asp:Button ID="btnUploadFile" runat="server" Text="Upload File" Onclick="btnUploadFile_Click" CausesValidation="false"/>
                <asp:Label ID="lblUploadSuccess" runat="server" Text=""></asp:Label>
                <br />
                <asp:TextBox ID="txtBoxTextBody" runat="server" Height="300" Width="600" AutoPostBack="false" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="textBodyVal" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must not be blank!" 
                    ForeColor="Red" ControlToValidate="txtBoxTextBody"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" OnClick="btnClear_Click"/>
                <asp:Button ID="btnPopulateText" runat="server" Text="Populate" CausesValidation="false" OnClick="btnPopulateText_Click"/>
                <asp:Button ID="btnCreate" runat="server" Text="Save Text" OnClick="btnCreate_Click"/>
                <asp:Button ID="btnEditSave" runat="server" Text="Save Edit" CausesValidation="false" OnClick="btnEditSave_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblManageTexts" runat="server" Text="Manage Texts" Font-Size="Large"></asp:Label>
                <br />
                <asp:DropDownList ID="lstManageTexts" runat="server" Width="300" DataSoureceID="sqlsrcTextsTable" DataTextField="textTitle" DataValueField="textID" AppendDataBoundItems="true">
                <asp:ListItem Text="Please select Text" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnEditText" runat="server" Text="Edit selected text" CausesValidation="false" OnClick="btnEditText_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GerarPDFTeste._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        
        <asp:Button ID="GerarPdf" runat="server" Text="Button" OnClick="GerarPdf_Click" />
        
    </div>

</asp:Content>

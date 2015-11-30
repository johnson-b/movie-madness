<%@ Page Title="Add" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="MovieMadness.Add" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <span class="navbar-brand">Movie Madness</span>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <div class="form-group">
            <asp:Label runat="server" for="MovieTitle"><strong>Title</strong></asp:Label>
            <asp:TextBox runat="server" ID="MovieTitle" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="ReleaseDate" CssClass="control-label"><strong>Release Date (Year)</strong></asp:Label>
            <asp:TextBox runat="server" ID="ReleaseDate" CssClass="form-control" MaxLength="4" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="Duration" CssClass="control-label"><strong>Duration</strong></asp:Label>
            <asp:TextBox runat="server" ID="Duration" CssClass="form-control" MaxLength="3" />
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="Rating" CssClass="control-label"><strong>Rating</strong></asp:Label>
            <asp:TextBox runat="server" ID="Rating" CssClass="form-control" MaxLength="5" />
        </div>
        <asp:Button runat="server" ID="BtnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="InsertMovie" />
    </div>
</asp:Content>

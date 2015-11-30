<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MovieMadness.Edit" %>

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
        <form runat="server">
            <div class="form-group">
                <asp:Label runat="server" for="MovieTitle">Title</asp:Label>
                <asp:TextBox runat="server" ID="MovieTitle" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" for="ReleaseDate" CssClass="control-label">Release Date (Year)</asp:Label>
                <asp:TextBox runat="server" ID="ReleaseDate" CssClass="form-control" MaxLength="4" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" for="Duration" CssClass="control-label">Duration</asp:Label>
                <asp:TextBox runat="server" ID="Duration" CssClass="form-control" MaxLength="3" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" for="Rating" CssClass="control-label">Rating</asp:Label>
                <asp:TextBox runat="server" ID="Rating" CssClass="form-control" MaxLength="5" />
            </div>
            <asp:Button runat="server" ID="Update" Text="Update" CssClass="btn btn-primary" />
        </form>
    </div>
</asp:Content>

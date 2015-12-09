<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="MovieMadness._Browse" EnableEventValidation="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <nav class="navbar navbar-default navbar-fixed-top" style="background-color: #4f6dff">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="Landing.html" style="color: white;">Movie Madness</a>
            </div>
            <div class="navbar-form navbar-right" role="link">
                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-default" Text="Add Movie" OnClick="InsertMovie" />
            </div>
            <div class="navbar-form navbar-right" role="search">
                <div class="form-group">
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="form-control" placeholder="Search" AutoPostBack="true" OnTextChanged="SearchMovie" />
                </div>
                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-default" Text="Search" OnClick="SearchMovie" />
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <table class="table table-responsive">
            <asp:Repeater ID="Movies" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <td class="col-md-5"><strong>Title</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Release Date</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Duration</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Rating</strong>
                            </td>
                            <td class="col-md-.5"></td>
                            <td class="col-md-.5"></td>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="pointer table-item-hover">
                            <div class="button-transparent" onclick="return movieDetails(this)">
                                <%# Eval("title") %>
                            </div>
                        </td>
                        <td class="text-center">
                            <%# Eval("release_year") %>
                        </td>
                        <td class="text-center">
                            <%# Eval("duration") %>
                        </td>
                        <td class="text-center">
                            <%# Eval("rating") %>
                        </td>
                        <td class="pointer text-center">
                            <button class="btn btn-danger fa fa-trash-o fa-lg" onclick="deleteMovie(this)"></button>
                        </td>
                        <td class="pointer text-center">
                            <button class="btn btn-default fa fa-pencil-square-o fa-lg" onclick="return editMovie(this)"></button>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

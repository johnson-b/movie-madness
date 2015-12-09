<%@ Page Title="Wizard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wizard.aspx.cs" Inherits="MovieMadness.Wizard" EnableEventValidation="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <nav class="navbar navbar-default navbar-fixed-top" style="background-color:#4f6dff">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="Landing.html" style="color:white;">Movie Madness</a>
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
    <h3 class="font-raleway">To begin, choose three of your favorite movies.</h3>
    <div id="browse-area" style="height: 500px; overflow-y: scroll;">
        <table class="table table-responsive">
            <asp:Repeater ID="Movies" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <td class="col-md-.5"></td>
                            <td class="col-md-5"><strong>Title</strong></td>
                            <td class="text-center col-md-2"><strong>Release Date</strong></td>
                            <td class="text-center col-md-2"><strong>Duration</strong></td>
                            <td class="text-center col-md-2"><strong>Rating</strong>
                            </td>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="pointer text-center">
                            <div class="fa fa-plus-square-o fa-lg" onclick="addMovieToFavorites(this)" />
                        </td>
                        <td>
                            <%# Eval("title") %>
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
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <br />
    <div class="col-lg-12" onload="loadList()">
        <ul id="favorite-list" class="list-group">
        </ul>
    </div>
    <button id="submit-button" class="btn btn-primary" onclick="submitFavorites()">Submit</button>
    <%--<div id="place-holder">Begin by searching for your favorite movies. After each search, add up to three movies to your list.</div>--%>
</asp:Content>

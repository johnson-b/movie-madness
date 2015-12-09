<%@ Page Title="Similar Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimilarMovies.aspx.cs" Inherits="MovieMadness.SimilarMovies" EnableEventValidation="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <nav class="navbar navbar-default navbar-fixed-top" style="background-color: #4f6dff">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="Landing.html" style="color: white">Movie Madness</a>
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
                            <td class="col-md-6"><strong>Title</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Release Date</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Duration</strong>
                            </td>
                            <td class="text-center col-md-2"><strong>Rating</strong>
                            </td>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="pointer table-item-hover">
                            <div class="button-transparent" onclick="return movieDetails(this)">
                                <%# Eval("Title") %>
                            </div>
                        </td>
                        <td class="text-center">
                            <%# Eval("ReleaseYear") %>
                        </td>
                        <td class="text-center">
                            <%# Eval("Duration") %>
                        </td>
                        <td class="text-center">
                            <%# Eval("Rating") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

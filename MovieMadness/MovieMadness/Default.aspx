<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieMadness._Default" EnableEventValidation="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="Default.aspx">Movie Madness</a>
            </div>
            <div class="navbar-form navbar-right" role="link">
                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add Movie" OnClick="InsertMovie" />
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
                            <asp:Label runat="server" ID="title" Text='<%# Eval("title") %>'>
                            </asp:Label>
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
                            <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="DeleteMovie" Style="font-family: Arial, Helvetica, sans-serif; font-size: 14px">
                                <span aria-hidden="true" class="fa fa-trash-o fa-lg"></span>
                            </asp:LinkButton>
                        </td>
                        <td class="pointer text-center">
                            <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="EditMovie" Style="font-family: Arial, Helvetica, sans-serif; font-size: 14px" >
                                <span aria-hidden="true" class="fa fa-pencil-square-o fa-lg"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

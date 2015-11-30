<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieMadness._Default" EnableEventValidation="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <table class="table table-responsive">
            <asp:Repeater ID="Movies" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <td><strong>Title</strong>
                            </td>
                            <td class="text-center"><strong>Release Date</strong>
                            </td>
                            <td class="text-center"><strong>Duration</strong>
                            </td>
                            <td class="text-center"><strong>Rating</strong>
                            </td>
                            <td></td>
                            <td></td>
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
                            <asp:Button runat="server" CssClass="btn btn-default glyphicon glyphicon-pencil" Text="Delete" OnClick="DeleteMovie" Style="font-family: Arial, Helvetica, sans-serif; font-size: 14px" />
                            <%--<div class="glyphicon glyphicon-trash" style="color: red"/>--%>
                        </td>
                        <td class="pointer text-center">
                            <asp:Button runat="server" CssClass="btn btn-default glyphicon glyphicon-pencil" Text="Edit" OnClick="EditMovie" Style="font-family: Arial, Helvetica, sans-serif; font-size: 14px" />
                            <%--<div class="glyphicon glyphicon-pencil" style="color: cornflowerblue" />--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

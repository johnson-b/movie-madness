<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MovieMadness.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>About Us.</h1>
        <h2>Movie Madness</h2>
    </hgroup>

    <article>
        The data you see in our website was taken from <a href="http://www.themoviedb.org">themoviedb.org</a> using an open source API. A console app was written to perform <br />
        each fetch to their database. There are two main functions of this web application. A user can either browse the current library and see information about each <br />
        movie or they can get recommendations based on their own favorites. Depending on what the user wants to do, they can select either choice from the landing page. <br />
        To get recommendations, you may search for your favorite movies, and click the plus sign next to the resulting list. This will add the selected movies to a sub <br />
        list. Once there are three movies in the sublist, you may hit submit to see the recommendations. 
    </article>
</asp:Content>
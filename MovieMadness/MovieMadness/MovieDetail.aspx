<%@ Page Title="Movie Madness" Language="C#" MasterPageFile="~/MovieDetail.Master" AutoEventWireup="true" CodeBehind="MovieDetail.aspx.cs" Inherits="MovieMadness.MovieDetail" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MovieDetail">
    <script>
        $(document).ready(function () {
            getMovieDetail();
        });
    </script>
    <div class="intro-header">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="intro-message"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="content-section-a">
        <div class="container">
            <div class="row">
                <div class="col-lg-5 col-sm-6">
                    <hr class="section-heading-spacer">
                    <div class="clearfix"></div>
                    <h2 id="movie-title" class="section-heading font-raleway"></h2>
                    <p id="movie-duration-release-rating" class="font-raleway"></p>
                    <p id="movie-overview" class="lead font-raleway"></p>
                </div>
                <ul class="col-lg-5 col-lg-offset-2 col-sm-push-2 col-sm-6 caption-style-1">
                    <li class="container-shadow">
                        <img id="movie-poster" class="container-shadow img-responsive img-rounded img-fade" src="place-holder" alt="<Image Unavailable>">
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="content-section-b">
        <div class="container">
            <div class="row">
                <div class="col-lg-5 col-lg-offset-1 col-sm-push-6  col-sm-6">
                    <hr class="section-heading-spacer">
                    <div class="clearfix"></div>
                    <h2 class="section-heading font-raleway">Cast & Crew</h2>
                    <p id="movie-director-name" class="lead font-raleway"></p>
                    <p id="movie-actor" class="lead font-raleway">Starring | </p>
                </div>
                <ul class="col-lg-5 col-sm-pull-6 col-sm-6 caption-style-1">
                    <li class="container-shadow">
                        <img id="actor-image" class="container-shadow img-responsive img-rounded" src="place-holder" alt="<Image Unavailable>">
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

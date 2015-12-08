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
                    <h2 id="movie-director" class="section-heading font-raleway">/h2>
                    <p class="lead font-raleway"></p>
                </div>
                <ul class="col-lg-5 col-sm-pull-6 col-sm-6 caption-style-1">
                    <li class="container-shadow">
                        <img class="container-shadow img-responsive img-rounded" src="../Images/saw.jpg" alt="">
                        <a href="Browse.aspx">
                            <div class="caption">
                                <div class="blur"></div>
                                <div class="caption-text font-raleway">
                                    <h3>Browse library</h3>
                                </div>
                            </div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>

    <div class="content-section-a">
        <div class="container">
            <div class="row">
                <div class="col-lg-5 col-sm-6">
                    <hr class="section-heading-spacer">
                    <div class="clearfix"></div>
                    <h2 class="section-heading font-raleway">Discover: Personal Recommendations, Just For You!</h2>
                    <p class="lead font-raleway">Can't figure out what movie to watch on Friday night? Let us help. We will guide you to your very own personal recommendation based on your own preference in movies.</p>
                </div>
                <div class="col-lg-5 col-lg-offset-2 col-sm-6">
                </div>
                <ul class="col-lg-5 col-lg-offset-2 col-sm-push-2 col-sm-6 caption-style-1">
                    <li class="container-shadow">
                        <img class="container-shadow img-responsive img-rounded" src="../Images/bighero6.jpg" alt="">
                        <a href="">
                            <div class="caption">
                                <div class="blur"></div>
                                <div class="caption-text font-raleway">
                                    <h3>Get Recommendation</h3>
                                </div>
                            </div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

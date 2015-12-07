<%@ Page Title="Movie Madness" Language="C#" MasterPageFile="~/MovieDetail.Master" AutoEventWireup="true" CodeBehind="MovieDetail.aspx.cs" Inherits="MovieMadness.MovieDetail" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MovieDetail">
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
                    <h2 class="section-heading font-raleway">Coming Soon to a Theater Near You</h2>
                    <p class="lead font-raleway">View movies not yet released in theaters. See the latest and greatest, updated every day.</p>
                </div>
                <ul class="col-lg-5 col-lg-offset-2 col-sm-push-2 col-sm-6 caption-style-1">
                    <li class="container-shadow">
                        <img class="container-shadow img-responsive img-rounded img-fade" src="../Images/starwars-new.jpg" alt="">
                        <a href="">
                            <div class="caption">
                                <div class="blur"></div>
                                <div class="caption-text font-raleway">
                                    <h3>Coming Soon!</h3>
                                </div>
                            </div>
                        </a>
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
                    <h2 class="section-heading font-raleway">From New to Old: Movies<br />You Didn't Know Existed</h2>
                    <p class="lead font-raleway">From new releases to classics that have been around for years. Browse thousands of movies, all at your finger tips.</p>
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
    </div 
</asp:Content>

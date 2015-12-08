function getMovieDetail() {
    $(document).ready(function () {
        var title = decodeURI(getURLParameters('movie'));
        jQuery.ajax({
            url: 'MovieDetail.aspx/GetMovieDetails',
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                "title": decodeURI(title)
            }),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                $("#movie-title").text(res.d.Title);
                var duration = res.d.Duration;
                var release = res.d.ReleaseYear;
                var rating = res.d.Rating;
                $("#movie-duration-release-rating").text(duration + " min. | " + release + " | " + rating);
                $("#movie-overview").text(res.d.Overview);
                $("#movie-poster").attr("src", res.d.PosterImageUrl);
                getMovieBackdrop(res.d.Id);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
}

function getMovieBackdrop(id) {
    $(document).ready(function () {
        jQuery.ajax({
            url: 'MovieDetail.aspx/GetMovieBackdrops',
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                "id": id
            }),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                var header = $('.intro-header');
                if (res.d[0]) {
                    header.css("background-image", "url(" + res.d[0].BackdropUrl + ")");
                } else {
                    header.hide();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
}

function deleteMovie(element) {
    var title = element.parentElement.parentElement.cells[0].textContent;
    jQuery.ajax({
        url: 'Browse.aspx/DeleteMovie',
        type: "POST",
        dataType: "json",
        data: JSON.stringify({
            "title": title
        }),
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            console.log("success");
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function editMovie(element) {
    var title = element.parentElement.parentElement.cells[0].textContent.trim();
    var path = '/Edit.aspx?movie=' + encodeURIComponent(title);
    window.location.href = path;
    return false;
}

function movieDetails(element) {
    var title = element.parentElement.innerText.trim();
    var path = '/MovieDetail.aspx?movie=' + encodeURIComponent(title);
    window.location.href = path;
    return false;
}


function getURLParameters(param) {
    var pageUrl = window.location.search.substring(1);
    var URLVariables = pageUrl.split('&');
    for (var i = 0; i < URLVariables.length; i++) {
        var paramName = URLVariables[i].split('=');
        if (paramName[0] == param) {
            return paramName[1];
        }
    }
}
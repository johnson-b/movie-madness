function test() {
    PageMethods.doSomething(); 
    function onSuccess(result) {
        alert(result);
    }
    function onError(result) {
        alert('Something went wrong');
    }
}

function getMovieImageUrl() {

    $(document).ready(function () {
        $('#moviePoster').ready(function () {
            var title = getURLParameters('movie');
            jQuery.ajax({
                url: 'MovieDetail.aspx/GetImageUrl',
                type: "POST",
                dataType: "json",
                data: "{'title': '" + title + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#moviePoster').attr("src", data.d);
                }
            });
        });
    });
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
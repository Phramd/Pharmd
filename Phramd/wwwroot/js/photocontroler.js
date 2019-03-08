document.getElementById("gPButton").addEventListener("click", function (event) {
    event.preventDefault()
    var data = document.getElementById("gmailEmail").value;
    $.ajax({
        url: 'http://localhost:44368/PhotoController/GooglePhotos',
        type: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert(data.success);
        },
        error: function () {
            alert("error");
        }
    });
});
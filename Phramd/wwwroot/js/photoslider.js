var index = 0;
photoSlider();
function photoSlider() {
    var i;
    var y = document.getElementsByClassName("photoSlides");
    for (i = 0; i < y.length; i++) {
        y[i].style.display = "none";
    }
    index++;
    if (index > y.length) { index = 1 }
    y[index - 1].style.display = "block";
    setTimeout(photoSlider, 30000);
}

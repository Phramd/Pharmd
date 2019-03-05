var index = 0;
var time;
var timeSet;

function getTime() {
    time = document.getElementById("dropTime");
    timeSet = time.options[time.selectedIndex].value;
}

newsSlider();
function newsSlider() {
    var i;
    var y = document.getElementsByClassName("newsSlider");
    for (i = 0; i < y.length; i++) {
        y[i].style.display = "none";
    }
    index++;
    if (index > y.length) { index = 1 }
    y[index - 1].style.display = "block";
    setTimeout(newsSlider, timeSet);
}
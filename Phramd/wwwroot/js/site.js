var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$(function () {
        $(".gmailCal").on("click", function () {
            $(".hiddenGmail").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenMicro").toggle(this.hidden)
        })
        $(".appleCal").on("click", function () {
            $(".hiddenApple").toggle()
            $(".hiddenMicro").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
        })
        $(".microCal").on("click", function () {
            $(".hiddenMicro").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
        })
        $(".gPhoto").on("click", function () {
            $(".hiddenGPhoto").toggle()
        })
    }
)

var myIndex = 0;
carousel();
function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 5000);
}

$(function () {
    $(".settings").on("click", function () {
        $(".accountSettings-div").toggle()
        $(".screenOptions-div").toggle(this.hiddeniden)
    })
    $(".screen").on("click", function () {
        $(".screenOptions-div").toggle()
        $(".accountSettings-div").toggle(ths.hidden)
    })
})


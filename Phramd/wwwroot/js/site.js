var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$(function () {
        $(".gmailCal").on("click", function (e) {
            $(".hiddenGmail").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenMicro").toggle(this.hidden)
            e.preventDefault();
        })
        $(".appleCal").on("click", function (e) {
            $(".hiddenApple").toggle()
            $(".hiddenMicro").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
            e.preventDefault();
        })
        $(".microCal").on("click", function (e) {
            $(".hiddenMicro").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
            e.preventDefault();
        })
        $(".gPhoto").on("click", function (e) {
            $(".hiddenGPhoto").toggle()
            e.preventDefault();
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





function ClearFields() {
    document.getElementById("gPhotoText").value = "";
    document.getElementById("textfield2").value = "";
}

function preventDefault(e) {
    e.preventDefault();
}

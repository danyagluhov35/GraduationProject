var resultLogin = ''
var resultPassword = ''
function checkLogin() {
    var login = document.querySelector(".login")
    if (login.value == '') {
        login.style.border = "2px solid red"
    }
    else {
        resultLogin = 'good'
    }
}

function checkPassword() {
    var password = document.querySelector(".password")
    if (password.value == '') {
        password.style.border = "2px solid red"
    }
    else {
        resultPassword = 'good'
    }
}

function check() {
    if (resultLogin == 'good' && resultPassword == 'good') {
        document.querySelector(".content").style.display = "none"
        var block = document.querySelector(".block")
        document.querySelector("body").style.overflow = "hidden"
        block.setAttribute("style", "stroke-dashoffset:0px")
        block.style.transition = "all 3.5s ease-in-out"
        block.style.display = "block"
    }
}

function locationMainSite(rederect) {
    location = rederect
}

document.querySelector(".btn-send").addEventListener("click", checkLogin)
document.querySelector(".btn-send").addEventListener("click", checkPassword)


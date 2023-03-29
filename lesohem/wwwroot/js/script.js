
new Swiper(".swiper", {

})
new Swiper(".slider-partners", {
    loop: true,
    slidesPerView: 4,
    autoplay: {
        delay: 2000,
        disableOnIneraction: false
    },
    speed: 800
})



var link = document.querySelectorAll(".link")

link.forEach(function (elem) {
    if (elem.querySelector(".sub-header-list")) {
        var span = document.createElement("span")
        span.classList.add("arrow")
        elem.prepend(span)
    }
})

var link = document.querySelectorAll(".sub-link")

link.forEach(function (elem) {
    if (elem.querySelector(".sub-sub-header-list")) {
        var span = document.createElement("span")
        span.classList.add("sub-arrow")
        elem.prepend(span)
    }
})

document.querySelector("body").classList.add("mouse")
if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|BB|PlayBook|IEMobile|Windows Phone|Kindle|Silk|Opera Mini/i.test(navigator.userAgent)) {
    document.querySelector("body").classList.remove("mouse")
    document.querySelector("body").classList.add("touch")

    var arrow = document.querySelectorAll(".arrow")
    arrow.forEach(function (elem) {
        var subMenu = elem.nextElementSibling.nextElementSibling;
        elem.addEventListener("click", function () {
            subMenu.classList.toggle("open")
        })
    })

    var sub_arrow = document.querySelectorAll(".sub-arrow")
    sub_arrow.forEach(function (elem) {
        var subMenu = elem.nextElementSibling.nextElementSibling;
        elem.addEventListener("click", function () {
            subMenu.classList.toggle("open")
        })
    })
}

$(document).ready(function () {
    $(".header_burger").click(function () {
        $(".header_burger, .header_menu").toggleClass("active")
        $("body").toggleClass("lock")
        var arrow = document.querySelectorAll(".arrow")
        var subArrow = document.querySelectorAll(".sub-arrow")

    })
})

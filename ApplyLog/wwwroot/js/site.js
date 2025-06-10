// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let icons = [];

for (let i = 0; i < 10; i++) {
    let name = "fav" + i;
    let element = document.getElementById(name);
    icons.push(element.innerHTML);
}

function change(ID) {
    let element = document.getElementById(ID);
    if (element.innerHTML == '<i class="bi bi-heart-fill"></i>') {
        element.innerHTML = "";
        element.innerHTML = '<i class="bi bi-heart"></i>';
    } else {
        element.innerHTML = "";
        element.innerHTML = '<i class="bi bi-heart-fill"></i>';
    }
}

$('.carousel').carousel();
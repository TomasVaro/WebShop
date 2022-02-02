$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('#content').toggleClass('active');
    });
});

var OrderPostBackURL = '/Home/ProceedToPayment';
function ProceedOrder() {
    var x = document.getElementById("cartDetails");
    x.style.display = "none";
    $.ajax({
        type: "GET",
        url: OrderPostBackURL,
        contentType: "application/json; charset=utf-8",

        datatype: "json",
        success: function (data) {
            $('#proceedOrder').html(data);
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });   
}

var ConfirmPostBackURL = '/Home/NewConfirmedOrder';
function ConfirmOrder() {
    var x = document.getElementById("proceedOrder");
        x.style.display = "none";
    var y = document.getElementById("confirmedOrder");
    y.style.display = "block";
    $.ajax({
        type: "GET",
        url: ConfirmPostBackURL,
        contentType: "application/json; charset=utf-8",

        datatype: "json",
        success: function (data) {
            $('#confirmedOrder').html(data);
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}

function ResetCart() {
    $.ajax({
        type: "GET",
        url: '/Home/ResetCartProducts',
        contentType: "application/json; charset=utf-8",

        datatype: "json",
        success: function (data) {
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}

var CartCountPostBackURL = '/Home/CartSummary';
$(function () {
    $.ajax({
        type: "GET",
        url: CartCountPostBackURL,
        contentType: "application/json; charset=utf-8",

        datatype: "json",
        success: function (data) {
            $('#idCartCount').html(data);
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
});


var CartDetailsPostBackURL = '/Home/GetCarttInfo';
$(function () {   
    var x = document.getElementById("cartDetails");
    x.style.display = "block";
    $.ajax({
        type: "GET",
        url: CartDetailsPostBackURL,
        contentType: "application/json; charset=utf-8",

        datatype: "json",
        success: function (data) {
            $('#cartDetails').html(data);
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
});

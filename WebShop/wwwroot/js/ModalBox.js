var DetailPostBackURL = '/Home/GetProductInfo';
$(function () {
    $(".anchorDetail").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { backdrop: true, keyboard: true }
        $.ajax({
            type: "GET",
            url: DetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "productId": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

var EditPostBackURL = '/Home/EditClicked';
$(function () {
    $(".anchorEdit").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { backdrop: true, keyboard: true }
        $.ajax({
            type: "GET",
            url: EditPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "productId": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

var DeletePostBackURL = '/Home/Delete';
$(function () {
    $(".anchorDelete").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { backdrop: true, keyboard: true }
        $.ajax({
            type: "GET",
            url: DeletePostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "productId": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

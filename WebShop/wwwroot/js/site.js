// Prevent jump to top when klick on "Add to Cart"
if (userAuthorized) {
    function storePagePosition() {
        var page_y = window.pageYOffset;
        localStorage.setItem("page_y", page_y);
    }
    window.addEventListener("scroll", storePagePosition);
    var currentPageY = localStorage.getItem("page_y");

    if (currentPageY === undefined) {
        localStorage.setItem("page_y") = 0;
    }
    window.scrollTo(0, currentPageY);    
}
else
{
    window.localStorage.removeItem("page_y");
}

var script = document.createElement('script');
script.src = 'https://code.jquery.com/jquery-3.4.1.min.js';
script.type = 'text/javascript';
document.getElementsByTagName('head')[0].appendChild(script);


function goToBasket() {
    var cart;
    var stored = localStorage['cart'];
    if (stored) {
        cart = JSON.parse(stored);
    }
    else {
        cart = new Array();
    }
    $.post("/orders/goToBasket", {
        drones:cart
    }, function (data, status) {
        $('.pb-3').empty();
        $('.pb-3').html(data);
    });
}
function createOrder(a) {
    debugger;
}
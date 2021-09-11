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
function RemoveFromCart(droneId) {
    debugger;
    var drones = localStorage['cart'];
    drones = JSON.parse(drones);
    var filtered=[];
    var removed=[];
    for (let i = 0; i < drones.length; i++)
    {
        if (drones[i].droneId == droneId && removed.length > 0) {
            filtered.push(drones[i]);
        }
        else if (drones[i] == droneId) {
            removed = drones[i];
        }
        else {
            filtered.push(drones[i]);
        }
    }
    localStorage["cart"] = JSON.stringify(filtered);
    goToBasket();

}
function createOrder(a) {
    debugger;
}
function searchKeyPress() {
    var foundDrones = 0;
    var Input = document.getElementById('myInput').value;
    Input = Input.toUpperCase();
    var li = document.getElementsByClassName('square square-1');
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("span")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(Input) > -1) {
            li[i].style.display = "";
            document.getElementById('noDrones').style.display = "none";
            foundDrones += 1;
        } else {
            li[i].style.display = "none";
        }
        li[i].style.display = " ";
        
    }
    if (foundDrones == 0 ) {
        document.getElementById("noDrones").style.display = "";
    }


}
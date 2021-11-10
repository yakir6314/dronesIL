
var script = document.createElement('script');
script.src = 'https://code.jquery.com/jquery-3.4.1.min.js';
script.type = 'text/javascript';
document.getElementsByTagName('head')[0].appendChild(script);
$(window).on('load',function() {
    // Animate loader off screen
    $(".se-pre-con").fadeOut("slow");;
});

$(document).ready(function () {
    if (sessionStorage.getItem('user') != null) {
        var userObject = JSON.parse(sessionStorage.getItem('user'));
        document.getElementById('btn btn-info btn-lg').style.display = 'none';
        document.getElementById('btn btn-info btn-rg').style.display = 'none';
        if (userObject.isAdmin == true) {
            document.getElementById('adminButton').style.display = 'block';
        }
    }
    //$("#regContent").on('load', function () {
    //    @Url.Action("Create", "Users") //load partial view here
    //});
});
function ValidateUser() {
    var mail = $("#inputUserName")[0].value;
    var password = $("#inputPassword")[0].value;
    var url = "/Home/ValidateUser/";
    $("#btnlogin").val('Plesae wait..');
    $.ajax({
        url: url,
        data: { mail: mail, pass: password },
        cache: false,
        type: "POST",
        success: function (data) {
            if (data != null) {
                alert("התחברת בהצלחה");
                sessionStorage.setItem('user', JSON.stringify(data));
                location.reload();
            } else {
                alert("שם משתמש או סיסמה לא נכונים");
            }
            $("#txtmail").attr({ 'value': '' });
            $("#txtpass").attr({ 'value': '' });
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
    $("#btnlogin").val('Login');
}

//window.weatherWidgetConfig = window.weatherWidgetConfig || [];
//window.weatherWidgetConfig.push({
//    selector: ".weatherWidget",
//    apiKey: "EZMLDFYE2994242A5TT5XJF58", //Sign up for your personal key
//    location: "tel aviv,israel", //Enter an address
//    unitGroup: "metric", //"us" or "metric"
//    forecastDays: 5, //how many days forecast to show
//    title: "Tel Aviv ", //optional title to show in the
//    showTitle: true,
//    showConditions: true
//});

//(function () {
//    var d = document, s = d.createElement('script');
//    s.src = 'https://www.visualcrossing.com/widgets/forecast-simple/weather-forecast-widget-simple.js';
//    s.setAttribute('data-timestamp', +new Date());
//    (d.head || d.body).appendChild(s);
//})();

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
    var drones = localStorage['cart'];
    drones = JSON.parse(drones);
    var filtered=[];
    var removed=[];
    for (let i = 0; i < drones.length; i++)
    {
        if (drones[i].droneId == droneId && removed.length > 0) {
            filtered.push(drones[i]);
        }
        else if (drones[i].droneId == droneId) {
            removed.push(drones[i]);
        }
        else {
            filtered.push(drones[i]);
        }
    }
    localStorage["cart"] = JSON.stringify(filtered);
    goToBasket();

}
function createOrder(a) {

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



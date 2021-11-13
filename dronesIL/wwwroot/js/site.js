
var script = document.createElement('script');
script.src = 'https://code.jquery.com/jquery-3.4.1.min.js';
script.type = 'text/javascript';
document.getElementsByTagName('head')[0].appendChild(script);
$(window).on('load',function() {
    // Animate loader off screen
    $(".se-pre-con").fadeOut("slow");;
});

$(document).ready(function () {
    if (sessionStorage.getItem('user') != null && sessionStorage.getItem('user')!='null') {
        var userObject = JSON.parse(sessionStorage.getItem('user'));
        document.getElementById('btn btn-info btn-lg').style.display = 'none';
        document.getElementById('disconnect').style.display = 'initial';
        if (userObject.isAdmin == true) {
            document.getElementById('adminButton').style.display = 'block';
        }
    }
    //$("#regContent").on('load', function () {
    //    @Url.Action("Create", "Users") //load partial view here
    //});
});




function disconnectUser() {
    var url = "/Home/disconnectUser";
    $.ajax({
        url: url,
        type: "POST",
        success: function () {
            sessionStorage.setItem('user', null);
            location.reload();

        },
        error: function (response) {
            alert("error : " + response);
        }

    });
}
function  searchPriceLessPress(){
    var foundDrones = 0;
    var Input = document.getElementById('myRange').value;
    var li = document.getElementsByClassName('card');

    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByClassName("card-text")[0];

        if (parseInt(a.textContent)<=Input && li[i].style.display !== "none") {
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
                document.getElementById('disconnect').style.display = 'block';
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

function searchKeyPress() {
    var foundDrones = 0;
    var Input = document.getElementById('myInput').value;
    var rangeInput = document.getElementById('myRange').value;
    Input = Input.toUpperCase();
    var isEnterprise = document.getElementById('isEnterprise').checked;
    var li = document.getElementsByClassName('card');

    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("span")[0];
        txtValue = a.textContent || a.innerText;
        var priceValue = li[i].getElementsByClassName("card-text")[0];
        if (Input && rangeInput && Input != "") {
            if (parseInt(priceValue.textContent) <= rangeInput && (txtValue.toUpperCase().indexOf(Input) > -1)) {
                li[i].style.display = "";
                document.getElementById('noDrones').style.display = "none";
                foundDrones += 1;
            }
            else {
                li[i].style.display = "none";
            }
            li[i].style.display = " ";
        }
        else if (Input && Input!="") {
            if ((txtValue.toUpperCase().indexOf(Input) > -1)) {
                li[i].style.display = "";
                document.getElementById('noDrones').style.display = "none";
                foundDrones += 1;
            } else {
                li[i].style.display = "none";
            }
            li[i].style.display = " ";
        }
        else if (rangeInput) {
            a = li[i].getElementsByClassName("card-text")[0];

            if (parseInt(a.textContent) <= rangeInput) {
                li[i].style.display = "";
                document.getElementById('noDrones').style.display = "none";
                foundDrones += 1;
            } else {
                li[i].style.display = "none";
            }
            li[i].style.display = " ";
        }
        if (isEnterprise == true) {
            var iscurrentEnterprice = li[i].getElementsByClassName('isEnterprise')[0].innerText;
            if (iscurrentEnterprice == 'False') {
                li[i].style.display = "none";
                foundDrones -= 1;
            }
        }

    }
    if (foundDrones == 0 ) {
        document.getElementById("noDrones").style.display = "";
    }


}

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.






$(document).ready(function () {
    $(function () {



        $.backstretch("/Images/Wallpapers/olive-green-canvas-fabric-texture.jpg");

      

    }
    );

    $.getScript("//platform.twitter.com/widgets.js");


    $(window).fontResizer({
        elements: [

            { elem: $('#tblPrayerTimes'), size: 20 },
            { elem: $("#divDigitalClock"), size: 30 },
            { elem: $("#spanBasmala"), size: 120 },
            //{ elem: $("#lblInternalIP"), size: 15 },
            //{ elem: $("#lblExternalIP"), size: 15 },
            { elem: $("#spanRadioInfo"), size: 20 },
            { elem: $("#spanChannels"), size: 20 },
            { elem: $("#divRadioinfo"), size: 20 },

            
        ]
        , baseWidth: 1980
        , startResize: true
        , sizeUnit: "px"
    }
    );
    
                
        setTimeout(GetUserPreferences(), 20000);
         
    
}
);




$(document).ready(function () {
    $(function () {

        $("#divDigitalClock").clock({ "langSet": "en", "format": "24" }); //>> will have military style 24 hour format
    }
    );


}

);




window.onload = function () {

    $("#divDigitalClock").clock({ "langSet": "en", "format": "24" }); //>> will have military style 24 hour format


};

$(function () {
    $("#tblPrayerTimes").resizable(onresize);

}


);





function htmlImages() {

    //alert(imgfileName);

    // alert("called");


    //   var i=0;
    for (var i = 0; i < imgfileName.length; i++) {
        $("#slider").append('<img src="/Images/hadiths/' + imgfileName[i] + '"' + ' id="' + imgfileName[i] + '"' + '/>');

        //document.write('<img src="/Images/hadiths/' + imgfileName[i] + '"' + ' id="' + imgfileName[i] + '" ' + 'class="PrayerInterface"' + '/>')

        // document.write(


        //   for (var i = 0; i < imgfileName.length; i++) {
        ///       imgfileName[i] = '/Images/hadiths/' + imgfileName[i];

        //    }


    }
}


function GetUserPreferences() {


    alert("called");

    $.ajax({
        type: "POST",
        url: "/Index?handler=getuserpreferences",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        //data: '{ViewMode:"' + ViewMode + '", serial: "' + serial + '" }',
       // data: JSON.stringify("1"),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {

          

           // alert(data);

            var obj = JSON.parse(data);
            alert(obj);
            alert(obj.viewmode);
            alert(obj.audiourl);

          //  document.getElementById("demo").innerHTML = obj.name + ", " + obj.age;

          

        },
        failure: function (response) {

            alert(response.d);

            alert("setting autoscreen failed try again!");
        }
    }
    );


}





function gmod(n, m) {
    return ((n % m) + m) % m;
}

function kuwaiticalendar(adjust) {
    var today = new Date();
    if (adjust) {
        adjustmili = 1000 * 60 * 60 * 24 * adjust;
        todaymili = today.getTime() + adjustmili;
        today = new Date(todaymili);
    }
    day = today.getDate();
    month = today.getMonth();
    year = today.getFullYear();
    m = month + 1;
    y = year; var AutoScreen = null;

    if ($("#chkAutoScreenStatus").is(':checked'))
        AutoScreen = "1";
    else
        AutoScreen = "0";

    $.ajax({
        type: "POST",
        url: "/settings?handler=updateautoscreen",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        //data: '{ViewMode:"' + ViewMode + '", serial: "' + serial + '" }',
        data: JSON.stringify(AutoScreen),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {

            if (data === "success") {

                alertsuccess("AutoScreen changed!");

            }
            else {

                alertfailed("failed try again!");

                return false;
            }

        },
        failure: function (response) {


            alertfailed("setting autoscreen failed try again!");
        }
    }
    );
    if (m < 3) {
        y -= 1;
        m += 12;
    }

    a = Math.floor(y / 100.);
    b = 2 - a + Math.floor(a / 4.);
    if (y < 1583) b = 0;
    if (y === 1582) {
        if (m > 10) b = -10;
        if (m === 10) {
            b = 0;
            if (day > 4) b = -10;
        }
    }

    jd = Math.floor(365.25 * (y + 4716)) + Math.floor(30.6001 * (m + 1)) + day + b - 1524;

    b = 0;
    if (jd > 2299160) {
        a = Math.floor((jd - 1867216.25) / 36524.25);
        b = 1 + a - Math.floor(a / 4.);
    }
    bb = jd + b + 1524;
    cc = Math.floor((bb - 122.1) / 365.25);
    dd = Math.floor(365.25 * cc);
    ee = Math.floor((bb - dd) / 30.6001);
    day = (bb - dd) - Math.floor(30.6001 * ee);
    month = ee - 1;
    if (ee > 13) {
        cc += 1;
        month = ee - 13;
    }
    year = cc - 4716;

    if (adjust) {
        wd = gmod(jd + 1 - adjust, 7) + 1;
    } else {
        wd = gmod(jd + 1, 7) + 1;
    }

    iyear = 10631. / 30.;
    epochastro = 1948084;
    epochcivil = 1948085;

    shift1 = 8.01 / 60.;

    z = jd - epochastro;
    cyc = Math.floor(z / 10631.);
    z = z - 10631 * cyc;
    j = Math.floor((z - shift1) / iyear);
    iy = 30 * cyc + j;
    z = z - Math.floor(j * iyear + shift1);
    im = Math.floor((z + 28.5001) / 29.5);
    if (im === 13) im = 12;
    id = z - Math.floor(29.5001 * im - 29);

    var myRes = new Array(8);

    myRes[0] = day; //calculated day (CE)
    myRes[1] = month - 1; //calculated month (CE)
    myRes[2] = year; //calculated year (CE)
    myRes[3] = jd - 1; //julian day number
    myRes[4] = wd - 1; //weekday number
    myRes[5] = id; //islamic date
    myRes[6] = im - 1; //islamic month
    myRes[7] = iy; //islamic year

    return myRes;
}
function writeIslamicDate(adjustment) {
    var wdNames = new Array("Ahad", "Ithnin", "Thulatha", "Arbaa", "Khams", "Jumuah", "Sabt");
    var iMonthNames = new Array("Muharram", "Safar", "Rabi'ul Awwal", "Rabi'ul Akhir",
        "Jumadal Ula", "Jumadal Akhira", "Rajab", "Sha'ban",
        "Ramadan", "Shawwal", "Dhul Qa'ada", "Dhul Hijja");
    var iDate = kuwaiticalendar(adjustment);
    var outputIslamicDate = wdNames[iDate[4]] + ", "
        + iDate[5] + " " + iMonthNames[iDate[6]] + " " + iDate[7] + " AH";
    return outputIslamicDate;
}

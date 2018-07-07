$(document).ready(function() {
    console.log("Hello Mr Sangg");
    LoadCommodity();
    LoadContacts();
    LoadShipments();
    LoadTypeOfBills();
    LoadUnits();
    LoadPayments();

});

function SaveAirExp() {
    var model = $('#form_new').serializeObject();
    var checked = $('#checkbox1').is(":checked");

    model.isFinish = checked;
    var request = JSON.stringify(model);

    console.log('model : ' + request);

    $.ajax({
        url: "https://localhost:44395/airexps",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: request,
        cache: false,
        async: false,
        success: function (dataJS) {
            console.log(dataJS);
            window.location.replace("http://localhost:53723/airexps");
        }
    });
}

function CreateNewCommodity() {
    var txt;
    var person = prompt("Please enter your name:", "Harry Potter");
    if (person === null || person === "") {
        txt = "User cancelled the prompt.";
    } else {
        var j = { "name": person };
        var request = JSON.stringify(j);
        console.log(request);
        $.ajax({
            url: "https://localhost:44395/commodities",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: request,
            cache: false,
            async: false,
            success: function (dataJS) {
                console.log(dataJS);
            }
        });
    }
    console.log(txt);
    //document.getElementById("demo").innerHTML = txt;
}

function LoadCommodity() {
    console.log('Enter loading commodity');
    $.ajax({
        url: "/api/commodities",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJS) {
            console.log('Load Commodities succeed');
            var datas = dataJS.object;

            $.each(datas, function (i, item) {
                $('#Commodity').append($('<option>', {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    });
}

function LoadContacts() {
    console.log('Enter loading contacts');
    $.ajax({
        url: "/api/contacts",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            console.log('Load Commodities succeed');
            var datas = dataJs.object;

            $.each(datas, function (i, item) {
                $('#opic').append($('<option>', {
                    value: item.id,
                    text: item.firstName + ' ' + item.lastName
                }));
            });

        }
    });
}

function LoadShipments() {
    console.log('Enter loading commodity');
    $.ajax({
        url: "/api/shipments",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            console.log('Load shipments succeed');
            var datas = dataJs.object;

            $.each(datas, function (i, item) {
                $('#Shipment').append($('<option>', {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    });
}

function LoadTypeOfBills() {
    console.log('Enter loading typeofbills');
    $.ajax({
        url: "/api/typeofbills",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            console.log('Load types of bill succeed');
            var datas = dataJs.object;

            $.each(datas, function (i, item) {
                $('#billtype').append($('<option>', {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    });
}

function LoadUnits() {
    console.log('Enter loading units');
    $.ajax({
        url: "/api/units",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            console.log('Load units succeed');
            var datas = dataJs.object;

            $.each(datas, function (i, item) {
                $('#Unit').append($('<option>', {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    });
}

function LoadPayments() {
    console.log('Enter loading payments');
    $.ajax({
        url: "/api/payments",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            console.log('Load payments succeed');
            var datas = dataJs.object;

            $.each(datas, function (i, item) {
                $('#Payment').append($('<option>', {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    });
}

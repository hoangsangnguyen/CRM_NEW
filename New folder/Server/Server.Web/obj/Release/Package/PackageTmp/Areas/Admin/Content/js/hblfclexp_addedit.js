$("#create-shipper").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "ShipperId", ["ShipperId", "ConsigneeId", "NotifyPartyId"]);
});

$("#create-consignee").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "ConsigneeId", ["ShipperId", "ConsigneeId", "NotifyPartyId"]);
});

$("#create-NotifyParty").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "NotifyPartyId", ["ShipperId", "ConsigneeId", "NotifyPartyId"]);
});

$("#create-FinalDestination").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "FinalDestinationId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});

$("#create-PlaceOfDelivery").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PlaceOfDeliveryId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});

$("#create-PortOfDischarge").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PortOfDischargeId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});

$("#create-PlaceOfReceipt").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PlaceOfReceiptId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});


$("#create-PortOfLoaing").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PortOfLoaingId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});

$("#create-TranshipmentPort").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "TranshipmentPortId", ["FinalDestinationId", "PlaceOfDeliveryId",
        "PortOfDischargeId", "PlaceOfReceiptId", "PortOfLoaingId", "TranshipmentPortId"]);
});

function OpenModalFirstCreation(viewResultId, formId) {
    console.log('First creation');
    $.ajax({
        url: '/Admin/HblFclExp/OpenModal',
        type: "POST",
        cache: false,
        async: false,
        contentType: 'application/json',
        data: JSON.stringify({ viewResultId: viewResultId, formId: formId }),
        success: function (dataJs) {
            $('#myModalContent').html(dataJs);
            $("#myModal").modal("show");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("Error saving new data by ajax " + thrownError + " " + xhr.error + thrownError.error);
        }
    });
}

function GetCustomerInfo(comboboxId, viewShowId) {
    console.log('show customer info');
    var customerId = $('#' + comboboxId).data("kendoComboBox").value();

    $.ajax({
        url: '/Admin/Customers/GetCustomerInfo',
        type: "POST",
        cache: false,
        async: true,
        contentType: 'application/json',
        data: JSON.stringify({ customerId: customerId }),
        success: function (dataJs) {
            $('#' + viewShowId).text(dataJs);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("Error get data by ajax " + thrownError + " " + xhr.error + thrownError.error);
        }
    });
}
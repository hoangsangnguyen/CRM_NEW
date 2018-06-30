$("#create-shipper").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "ShipperId", "DrpCustomer");
});

$("#create-consignee").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "ConsigneeId", "DrpCustomer");
});

$("#create-NotifyParty").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "NotifyPartyId", "DrpCustomer");
});

$("#create-FinalDestination").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "FinalDestinationId", "DrpPort");
});

$("#create-PlaceOfDelivery").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PlaceOfDeliveryId", "DrpPort");
});

$("#create-PortOfDischarge").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PortOfDischargeId", "DrpPort");
});

$("#create-PlaceOfReceipt").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PlaceOfReceiptId", "DrpPort");
});


$("#create-PortOfLoaing").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PortOfLoaingId", "DrpPort");
});

$("#create-TranshipmentPort").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "TranshipmentPortId", "DrpPort");
});
function OpenModalCreation(url, viewId, viewGroupId) {
    $.ajax({
        url: url,
        type: "POST",
        cache: false,
        async: true,
        contentType: 'application/json',
        data: JSON.stringify({ viewId: viewId, viewGroupId: viewGroupId }),
        success: function (dataJs) {
            $('#myModalContent').html(dataJs);
            $("#myModal").modal("show");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log("Error saving new data by ajax " + thrownError + " " + xhr.error + thrownError.error);
        }
    });
}
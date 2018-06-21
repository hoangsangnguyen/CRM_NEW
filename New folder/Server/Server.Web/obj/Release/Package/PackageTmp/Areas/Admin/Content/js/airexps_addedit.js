$("#create-opic").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "OpicId", "DrpContact");
});

$("#create-airlines").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "AirlineId", "DrpCarrier");
});

$("#create-agent").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "AgentId", "DrpCarrier");
});

$("#create-originport").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "OriginPortId", "DrpPort");
});

$("#create-destinationport").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "DestinationId", "DrpPort");
});

$("#create-transitport").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "TransitPortId", "DrpPort");
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
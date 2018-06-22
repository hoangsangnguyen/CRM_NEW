$("#create-opic").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "OpIcId", "DrpContact");
});

$("#create-sline").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "SlinesId", "DrpCarrier");
});

$("#create-agent").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "AgentId", "DrpCarrier");
});

$("#create-PolPort").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PolId", "DrpPort");
});

$("#create-PodPort").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PodId", "DrpPort");
});

$("#create-delivery").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "DeliveryId", "DrpPort");
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
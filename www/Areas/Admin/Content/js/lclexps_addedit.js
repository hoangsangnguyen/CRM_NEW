$("#create-opic").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "OpIcId", "DrpContact");
});

$("#create-coloader").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "CoLoaderId", "DrpCarrier");
});

$("#create-agent").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "AgentId", "DrpCarrier");
});

$("#create-pod").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PodId", "DrpPort");
});

$("#create-pol").click(function () {
    const url = $(this).data('request-url');
    OpenModalCreation(url, "PolId", "DrpPort");
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

//function OpenModalCreateContact(url, viewId, viewGroupId) {
//    $.ajax({
//        url: url,
//        type: "POST",
//        cache: false,
//        async: false,
//        contentType: 'application/json',
//        data: JSON.stringify({ viewId: viewId, viewGroupId: viewGroupId }),
//        success: function (dataJs) {
//            $('#myModalContent').html(dataJs);
//            $("#myModal").modal("show");
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            console.log("Error saving contacts in ajax " + thrownError + " " + xhr.error + thrownError.error);
//        }
//    });
//}

//function OpenModalCreatePort(url, viewId, viewGroupId) {
//    $.ajax({
//        url: url,
//        type: "POST",
//        cache: false,
//        async: false,
//        contentType: 'application/json',
//        data: JSON.stringify({ viewId: viewId, viewGroupId: viewGroupId }),
//        success: function (dataJs) {
//            $('#myModalContent').html(dataJs);
//            $("#myModal").modal("show");
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            console.log("Error saving contacts in ajax " + thrownError + " " + xhr.error + thrownError.error);
//        }
//    });
//}
$(document).ready(function () {
    console.log("welcome to carriers.js");
    LoadDataGrid();
});

function LoadDataGrid() {
    console.log('Enter loading data carriers');
    $.ajax({
        url: "getList",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJS) {
            if (jQuery.isEmptyObject(dataJS.Data)) {
                console.log('No data response');
                $('#example').DataTable();
                return;
            }
            $('#example').DataTable({
                destroy: true,
                data: dataJS.Data,
                "columns": [
                    { "data": "Code" },
                    { "data": "Name" }
                ]
            });

        }
    });
}
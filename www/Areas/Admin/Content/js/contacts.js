$(document).ready(function () {
    console.log("welcome to contact.js");
    LoadDataGrid();
});

function LoadDataGrid() {
    console.log('Enter loading data contact');
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
                    { "data": "ContactId" },
                    { "data": "FirstName" },
                    { "data": "EnglishName" },
                    { "data": "PositionName" },
                    { "data": "DepartmentName" }
                ]
            });

        }
    });
}
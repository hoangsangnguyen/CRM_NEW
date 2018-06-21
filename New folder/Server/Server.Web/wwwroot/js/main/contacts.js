$(document).ready(function() {
    console.log("welcome to contact.js");
    LoadDataGrid();
});

function LoadDataGrid() {
    console.log('Enter loading data contact');
    $.ajax({
        url: "getlist",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJS) {
            if (jQuery.isEmptyObject(dataJS.object)) {
                console.log('No data response');
                $('#example').DataTable();
                return;
            }
            $('#example').DataTable({
                destroy: true,
                data: dataJS.object,
                "columns": [
                    { "data": "contactID" },
                    { "data": "firstName" },
                    { "data": "englishName" },
                    { "data": "position.name" },
                    { "data": "department.name" }
                ]
            });

        }
    });
}
$(document).ready(function () {
    console.log("Hello Mr Sang");
    LoadDataGrid();
});

function LoadDataGrid() {
    console.log('Enter loading data grid');
    $.ajax({
        url: "/customers/GetList",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: true,
        success: function (dataJs) {
            if (jQuery.isEmptyObject(dataJs.Data)) {
                console.log('No data response');
                $('#example').DataTable();
                return;
            }

            var table = $('#example').DataTable({
                destroy: true,
                data: dataJs.Data,
                select: false,
                "columns": [
                    { "data": "CustomerId" },
                    { "data": "Name" },
                    {
                        "data": "Id", "render": function (data) {
                            return "<a href=/admin/customers/edit/" + data + " class='btn btn-primary' ><i class='mdi mdi-edit'></i>&nbsp;Edit</a>";
                        },
                        "orderable": false,
                        "searchable": false
                    }
                ],
                dom: 'Bfrtip',

                buttons: [
                    'copy', 'excel', 'pdf'
                ],

            });

            table.on('select',
                function (e, dt, type, indexes) {
                    var rowData = table.rows(indexes).data().toArray();
                    $('#btn_update').prop('disabled', false);
                    $('#btn_delete').prop('disabled', false);
                    id = rowData[0].id;

                    document.getElementById('btn_update').addEventListener("click",
                        function () {

                            //HTML.actionURL("/airexps/Edit", new { id });
                            //url_redirect({
                            //    url: "http://www.knowledgewalls.com",
                            //    method: "get",
                            //    data: { "q": "KnowledgeWalls" }
                            //});
                            window.location.replace('~/admin/fclexps/edit', { "id": id });

                            console.log('id: ' + id);
                        });
                    console.log(rowData[0].id);
                })
                .on('page.dt',
                function () {
                    table.rows().deselect();
                    $('#btn_update').prop('disabled', true);
                    $('#btn_delete').prop('disabled', true);

                });


        }
    });
}
$(document).ready(function () {
    console.log("Hello Mr Sang");
    LoadDataGrid();
});

function LoadDataGrid() {
    console.log('Enter loading data gridd');
    $.ajax({
        url: "/airimps/GetList",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            if (jQuery.isEmptyObject(dataJs.Data)) {
                console.log('No data response');
                $('#example').DataTable();
                return;
            }

            const monthNames = ["January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            ];

            var table = $('#example').DataTable({
                destroy: true,
                data: dataJs.Data,
                select: false,
                "columns": [
                    { "data": "JobId" },
                    {
                        "data": "Eta",
                        "type": "date ",
                        "render": function (value) {
                            if (value === null) return "";

                            var pattern = /Date\(([^)]+)\)/;
                            var results = pattern.exec(value);
                            var dt = new Date(parseFloat(results[1]));

                            var month = monthNames[dt.getMonth()];
                            return (dt.getDate() + " " + month + ", " + dt.getFullYear());
                        }
                    },
                    { "data": "Airlines.FullEnglishName" },
                    { "data": "Agent.FullEnglishName" },
                    { "data": "Routing" },
                    { "data": "Quantity" },
                    { "data": "Gw" },
                    { "data": "Cw" },
                    {
                        "data": "Id", "render": function (data) {
                            return "<a href=/admin/airimps/edit/" + data + " class='btn btn-primary' ><i class='mdi mdi-edit'></i>&nbsp;Edit</a>";

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
                            window.location.replace('~/admin/airimps/edit', { "id": id });

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
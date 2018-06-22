$(document).ready(function() {
    console.log("Hello Mr Sang");

    LoadDataGrid();
    //document.getElementById('btn_update').addEventListener("click", function () {
    //    console.log('id: ' + id);
    //});


});

function LoadDataGrid() {
    console.log('Enter loading data gridd');
    $.ajax({
        url: "/airexps/GetList",
        type: "GET",
        dataType: "json",
        contentType: 'application/json',
        cache: false,
        async: false,
        success: function (dataJs) {
            if (jQuery.isEmptyObject(dataJs.object)) {
                console.log('No data response');
                $('#example').DataTable();
                return;
            }

            const monthNames = ["January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            ];

            var table = $('#example').DataTable({
                destroy: true,
                data: dataJs.object,
                select: false,
                "columns": [
                    { "data": "jobID" },
                    {
                        "data": "etd",
                        "render": function(data) {
                            var date = new Date(data);
                            var month = monthNames[date.getMonth()];
                            return (date.getDate() + " " + month + ", " + date.getFullYear());
                        }
                    },
                    { "data": "carrier" },
                    { "data": "carrier" },
                    { "data": "eta" },
                    { "data": "quantity" },
                    { "data": "quantity" },
                    { "data": "quantity" },
                    {
                        "data": "id", "render": function (data) {
                            return "<a href=/airexps/edit/" + data + " class='btn pull-right' ><i class='mdi mdi-edit'></i>&nbsp;Edit</a>";

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
                    function(e, dt, type, indexes) {
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
                                window.location.replace('/airexps/edit', { "id": id });
                               
                                console.log('id: ' + id);
                            });
                        console.log(rowData[0].id);
                    })
                .on('page.dt',
                    function() {
                        table.rows().deselect();
                        $('#btn_update').prop('disabled', true);
                        $('#btn_delete').prop('disabled', true);

                    });


        }
    });
}
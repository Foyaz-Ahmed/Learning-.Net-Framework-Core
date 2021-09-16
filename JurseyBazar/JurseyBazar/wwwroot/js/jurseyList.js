var dataTable;

$(document).ready(function () {

    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').dataTable({

        "ajax": {
            "url": "api/Jursey",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "teamsName", "width": "20%" },
            { "data": "price", "width": "20%" },
            { "data": "quantity", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {

                    return `<div class="text-center">
                            <a href="/JurseyList/Upsert?id=${data}"  class='btn btn-success btn-sm text-white' style='cursor:pointer;width:60px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a class='btn btn-danger btn-sm text-white' style='cursor:pointer;width:60px;'
                              onclick=Delete('/api/Jursey?id='+${data})>
                                Delete
                            </a>
                            </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "NO Data Found"
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Are you sure You want to Delete?",
        text: "Once Deleted, You will not able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {

        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.toastr.error(data.message);
                    }
                }
            });
        }

    });
}
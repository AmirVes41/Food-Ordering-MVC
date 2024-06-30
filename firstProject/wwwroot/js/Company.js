var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { data: 'name', "width": "10%" },
            { data: 'unit', "width": "25%" },
            { data: 'code', "width": "10%" },
            { data: 'phoneNumber', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> ویرایش</a>
                       <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> حذف</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
       
    });
}

//function Delete(url) {
//    Swal.fire({
//        title: "آیا مطمنی میخواهی پاک بشه؟",
//        icon: "warning",
//        iconHtml: "!",
//        confirmButtonText: "بله",
//        confirmButtonColor: "#3085d6",
//        cancelButtonText: "خیر",
//        cancelButtonColor: "#d33",
//        showCancelButton: true,
//        showCloseButton: true
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: 'DELETE',
//                success: function (data) {
//                    dataTable.ajax.reload();
//                    toastr.success(data.message);
//                }
//            })
//        }
//    })
//}


function Delete(url) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            cancelButton: "btn btn-danger",
            confirmButton: "btn btn-success"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "آیا مطمنی؟",
        text: "این کار برگشت پذیر نیست",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "آره،مطمنم",
        cancelButtonText: "نه،شک دارم",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
            swalWithBootstrapButtons.fire({
                title: "حذف  شد",
                text: "فایل با موفیت حذف شد",
                icon: "success"
            });
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire({
                title: "نگران نباش",
                text: "فعلا هیچی پاک نشده",
                confirmButtonText: "باشه",
                icon: "error"
            });
        }
    });
}
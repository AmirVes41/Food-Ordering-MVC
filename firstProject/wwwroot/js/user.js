var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'firstName', "width": "15%" },
            { data: 'lastName', "width": "15%" },
            { data: 'code', "width": "15%" },
            { data: 'company.name', "width": "5%" },
            { data: 'role', "width": "15%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {

                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                        <div class="text-center">
                             <a onclick=LockUn('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:auto;">
                                    <i class="bi bi-lock-fill"></i> </a> 

                        </div>
                    `
                    }
                    else {
                        return `
                        <div class="text-center">
                              <a onclick=LockUn('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:auto;">
                                    <i class="bi bi-unlock-fill"></i></a>
                        </div>
                    `
                    }
                },
                "width": "25%"
            }
        ]
       
    });
}


//delete function
//function Delete(url) {
//    const swalWithBootstrapButtons = Swal.mixin({
//        customClass: {
//            cancelButton: "btn btn-danger",
//            confirmButton: "btn btn-success"
//        },
//        buttonsStyling: false
//    });
//    swalWithBootstrapButtons.fire({
//        title: "آیا مطمنی؟",
//        text: "این کار برگشت پذیر نیست",
//        icon: "warning",
//        showCancelButton: true,
//        confirmButtonText: "آره،مطمنم",
//        cancelButtonText: "نه،شک دارم",
//        reverseButtons: true
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
//            swalWithBootstrapButtons.fire({
//                title: "حذف  شد",
//                text: "فایل با موفیت حذف شد",
//                icon: "success"
//            });
//        } else if (
//            /* Read more about handling dismissals below */
//            result.dismiss === Swal.DismissReason.cancel
//        ) {
//            swalWithBootstrapButtons.fire({
//                title: "نگران نباش",
//                text: "فعلا هیچی پاک نشده",
//                confirmButtonText: "باشه",
//                icon: "error"
//            });
//        }
//    });
//}

function LockUn(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUn',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}
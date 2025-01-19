toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

// Default settings for SweetAlert2
const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-success mx-2',
        cancelButton: 'btn btn-danger mx-2'
    },
    buttonsStyling: false
});

// Function to handle delete confirmations
function confirmDelete(deleteUrl, dataTable) {
    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: deleteUrl,
                type: 'DELETE',
                success: function (response) {
                    if (response.success) {
                        dataTable.ajax.reload();
                        toastr.success(response.message || "Deleted successfully");
                    } else {
                        toastr.error(response.message || "Something went wrong");
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error("Error: " + error);
                }
            });
        }
    });
}

// Function to handle AJAX form submissions
function submitForm(form, successCallback) {
    $.ajax({
        url: form.action,
        type: form.method,
        data: $(form).serializeJSON(),
        contentType: 'application/json',
        success: function (response) {
            if (response.success) {
                toastr.success(response.message || "Operation successful");
                if (typeof successCallback === 'function') {
                    successCallback(response);
                }
            } else {
                toastr.error(response.message || "Something went wrong");
            }
        },
        error: function (xhr, status, error) {
            toastr.error("Error: " + error);
        }
    });
}

// DataTables default configuration
$.extend(true, $.fn.dataTable.defaults, {
    responsive: true,
    language: {
        search: "_INPUT_",
        searchPlaceholder: "Search...",
        processing: '<div class="spinner-border text-primary" role="status"><span class="visually-hidden">Loading...</span></div>'
    },
    pageLength: 10,
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print'
    ]
});
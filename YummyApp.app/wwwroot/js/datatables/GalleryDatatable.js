$(document).ready(function () {
    $('#albums').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Gallery/AllData",
            "type": "POST",
            "datatype": "JSON"
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "width": "500px"
            }
            
        ],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return `<a href="#" style="font-size: 20px !important;" class=" btn-details text-dark  text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  title="Show Details" data-id="${row.id}">${row.title}</a>`;
                },
                "name": "Title"
            },
            {
                data: null,
                className: 'text-start',
                render: function (data, type, row) {
                    if (row.status == 0) {
                        return '<button type="button" class="btn btn-primary btn-status" data-href="/Admin/Gallery/EditStatus/' + row.id + '">Private</button>';
                    } else {
                        return '<button type="button" class="btn btn-success btn-status" data-href="/Admin/Gallery/EditStatus/' + row.id + '">Public</button>';
                    }
                },
                name: "Show To Public"
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '" data-status="' + row.status + '">Delete Album</a>';
                },
                "orderable": false
            }

        ]
    });

    function ShowAnyModal(className, modalId, urlAddress, showModal, modalName) {
        $(document).on("click", className, function () {
            let modelId = $(this).data('id');
            $.ajax({
                url: "/" + urlAddress + "/" + modelId,
                type: 'GET',
                cache: false,
                success: function (result) {
                    $(".modal-backdrop.show").remove();
                    $(showModal).html(result);
                    $(modalName).modal("show");
                }

            });
            return false;
        });


    }

    // Call the function when clicking on the "Update" button
    ShowAnyModal(".btn-details", "modal", "Admin/Gallery/Details", "#ShowModal", "#kt_modal_details");

    $(document).on("click", ".btn-closee, .btn-hide", function () {
        // Trigger the modal's close functionality
        $('#kt_modal_details').modal('hide');
        $('#kt_modal_details').remove();

    });

    $('.toast').toast('show');


    // Event handler for Delete button

    $(document).on('click', '.btn-delete', function (e) {
        e.preventDefault();
        var albumId = $(this).data('id');
        var albumStatus = $(this).data('status'); // Assuming you have a data attribute for status in your button

        // Before showing SweetAlert, check if albumStatus is 1
        if (albumStatus === 1) {
            Swal.fire(
                'Cannot Delete',
                "Can't Delete This Album, Should One Photo Album be In Public Home Page.",
                'error'
            );
        } else {
            // Show SweetAlert confirmation
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    // If user confirms, delete the row and send request to the server
                    var deleteUrl = '/Admin/Gallery/Delete/' + albumId; // Replace with your actual Delete route URL
                    $.ajax({
                        url: deleteUrl,
                        type: 'POST',
                        success: function (data) {
                            // On successful deletion, hide the row and show success message
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            ).then(function () {
                                // Hide the deleted row
                                $(e.target).closest('tr').hide();
                            });
                        },
                        error: function (error) {
                            // Handle any error that may occur during the request
                            console.error(error);
                        }
                    });
                }
            });
        }
    });


    // Add click event handler to buttons with class "btn-status"
    $(document).on('click', '.btn-status', function (e) {
        // Get the URL from the data-href attribute
        var url = $(this).data('href');

        // Redirect to the URL
        window.location.href = url;
    });




});



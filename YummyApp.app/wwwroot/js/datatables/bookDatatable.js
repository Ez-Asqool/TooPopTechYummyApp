$(document).ready(function () {
    $('#books').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Book/AllData",
            "type": "POST",
            "datatype": "JSON"
        },
        "columnDefs": [
            {
            "targets": [0],
            "visible": false,
            "searchable": false
            }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                data: 'name',
                name: 'Name',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the "Email" column
                    return `<a href="#" style="font-size: 18px;" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  title="Show Details" data-id="${row.id}">${row.name}</a>`
                }
            },
            {
                data: 'date',
                name: 'Date',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the column
                    return '<div style="font-size: 14px;">' + data + '</div>';
                }
            },
            {
                data: 'time',
                name: 'Time',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the column
                    return '<div style="font-size: 14px;">' + data + '</div>';
                }
            },
            {
                data: 'numberOfPeople',
                name: 'NumberOfPeople',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the column
                    return '<div style="font-size: 14px;">' + data + ' People</div>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-reject" data-id="' + row.id + '"> Reject </a> <a href="#" class="btn btn-success btn-accept" data-id="' + row.id + '"> Accept </a> ';
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
    ShowAnyModal(".btn-details", "modal", "Admin/Book/Details", "#ShowModal", "#kt_modal_details");

    $(document).on("click", ".btn-closee, .btn-hide", function () {
        // Trigger the modal's close functionality
        $('#kt_modal_details').modal('hide');
        $('#kt_modal_details').remove();

    });


    // Event handler for Delete button
    $(document).on('click', '.btn-reject', function (e) {
        e.preventDefault();
        var eventId = $(this).data('id');

        // Show SweetAlert confirmation
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Send Reject Message!'
        }).then((result) => {
            if (result.isConfirmed) {
                // If user confirms, delete the row and send request to the server
                var deleteUrl = '/Admin/Book/Reject/' + eventId; // Replace with your actual Delete route URL
                $.ajax({
                    url: deleteUrl,
                    type: 'POST',
                    success: function (data) {
                        // On successful deletion, hide the row and show success message
                        Swal.fire(
                            'Rejected!',
                            'Reject Message Sent To Customer.',
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
    });


    // Replace the existing onClick script with the new SweetAlert function
    $(document).on('click', '.btn-accept', function (e) {
        e.preventDefault();
        var eventId = $(this).data('id');

        // Show SweetAlert confirmation with custom styles and buttons
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, Send Accept Message!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                // If user confirms, send request to the server
                var deleteUrl = '/Admin/Book/Accept/' + eventId; // Replace with your actual Accept route URL
                $.ajax({
                    url: deleteUrl,
                    type: 'POST',
                    success: function (data) {
                        // On successful acceptance, hide the row and show success message
                        swalWithBootstrapButtons.fire(
                            'Accepted!',
                            'Accept Message Sent To Customer.',
                            'success'
                        ).then(function () {
                            // Hide the row
                            $(e.target).closest('tr').hide();
                        });
                    },
                    error: function (error) {
                        // Handle any error that may occur during the request
                        console.error(error);
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                // If user cancels, show a cancel message
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Your action has been cancelled.',
                    'error'
                )
            }
        });
    });





});

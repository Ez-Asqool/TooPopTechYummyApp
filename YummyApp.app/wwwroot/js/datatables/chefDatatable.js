$(document).ready(function () {
    $('#chefs').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Chef/AllData",
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
                targets: 5, // Index of the Actions column (zero-based index)
                width: '200px', // Adjust the width as needed
                orderable: false // Disable sorting on the Actions column
            }
            
        ],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return `<a href="#" style="font-size: 18px;" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  data-id="${row.id}">${row.firstName}</a>`
                },
                "name": "FirstName"
            },
            {
                "render": function (data, type, row) {
                    return `<a href="#" style="font-size: 18px;" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  data-id="${row.id}">${row.lastName}</a>`
                },
                "name": "LastName"
            },
            {
                data: 'email',
                name: 'Email',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the "Email" column
                    return '<div style="font-size: 16px;">' + data + '</div>';
                }
            },
            {
                "render": function (data, type, row) {
                    return `<img src="/UserImages/${row.imageName}" style="width:60px; height:60px;">`
                },
                "name": "ImageName",
                "orderable": false
            },
            {
                data: null,
                className: 'text-start',
                render: function (data, type, row) {
                    var statusText = row.status === 0 ? 'Blocked' : 'Active';
                    var btnClass = row.status === 0 ? 'btn-danger' : 'btn-success';
                    return '<button type="button" class="btn ' + btnClass + ' btn-status" data-id="' + row.id + '">' + statusText + '</button>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '"> Delete </a> <a href="#" class="btn btn-primary btn-update" data-id="' + row.id + '"> Update </a>';
                },
                "orderable": false
            }

        ]
    });

    //// Event handler for Delete button
    //$('#chefs').on('click', '.btn-delete', function (e) {
    //    e.preventDefault();
    //    var eventId = $(this).data('id');

    //    // Show SweetAlert confirmation
    //    Swal.fire({
    //        title: 'Are you sure?',
    //        text: "You won't be able to revert this!",
    //        icon: 'warning',
    //        showCancelButton: true,
    //        confirmButtonColor: '#3085d6',
    //        cancelButtonColor: '#d33',
    //        confirmButtonText: 'Yes, delete it!'
    //    }).then((result) => {
    //        if (result.isConfirmed) {
    //            // If user confirms, delete the row and send request to the server
    //            var deleteUrl = '/Admin/Chef/Delete/' + eventId; // Replace with your actual Delete route URL
    //            $.ajax({
    //                url: deleteUrl,
    //                type: 'POST',
    //                success: function (data) {
    //                    // On successful deletion, hide the row and show success message
    //                    Swal.fire(
    //                        'Deleted!',
    //                        'Your file has been deleted.',
    //                        'success'
    //                    ).then(function () {
    //                        // Hide the deleted row
    //                        $(e.target).closest('tr').hide();
    //                    });
    //                },
    //                error: function (error) {
    //                    // Handle any error that may occur during the request
    //                    console.error(error);
    //                }
    //            });
    //        }
    //    });
    //});

    //// Add a click event listener to the buttons with class 'btn-status'
    //$(document).on('click', '.btn-status', function (event) {
    //    event.preventDefault(); // Prevent default button behavior
    //    var btn = $(this); // Save the reference to the button that was clicked
    //    var chefId = btn.data('id'); // Get the chef ID from the data attribute

    //    // Make the AJAX request with cache: false
    //    $.ajax({
    //        url: '/Admin/Chef/EditStatus/' + chefId,
    //        type: 'GET',
    //        cache: false, // Prevent caching of the response
    //        success: function (data) {
                

    //            // Check the current class and update it accordingly
    //            if (btn.hasClass('btn-danger')) {
    //                btn.removeClass('btn-danger').addClass('btn-success');

    //                // Update the button class and text based on the response
    //                var newStatus = 'Active';
    //                btn.text(newStatus);

    //            } else if (btn.hasClass('btn-success')) {
    //                btn.removeClass('btn-success').addClass('btn-danger');

    //                // Update the button class and text based on the response
    //                var newStatus = 'Blocked';
    //                btn.text(newStatus);
    //            }
    //        },
    //        error: function () {
    //            alert('An error occurred while updating the status.');
    //        }
    //    });
    //});


});



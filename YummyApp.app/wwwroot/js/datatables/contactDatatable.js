$(document).ready(function () {
    $('#contacts').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Contact/AllData",
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
                data: 'subject',
                name: 'Subject',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the "Email" column
                    return '<div style="font-size: 14px;">' + data + '</div>';
                }
            },
            {
                data: 'createdDate',
                name: 'Created Date',
                autowidth: true,
                render: function (data, type, row) {
                    // Convert the date string to a Date object
                    var dateObj = new Date(data);

                    // Get the day, month, year, hours, and minutes
                    var day = dateObj.getDate();
                    var month = dateObj.getMonth() + 1; // Months are zero-based, so we add 1
                    var year = dateObj.getFullYear();
                    var hours = dateObj.getHours();
                    var minutes = dateObj.getMinutes();

                    // AM or PM
                    var amOrPm = hours >= 12 ? 'PM' : 'AM';

                    // Convert hours from 24-hour format to 12-hour format
                    if (hours > 12) {
                        hours -= 12;
                    } else if (hours === 0) {
                        hours = 12;
                    }

                    // Format the date string in the desired format
                    var formattedDate = day + '/' + month + '/' + year + ' ' + hours + ':' + (minutes < 10 ? '0' + minutes : minutes) + ' ' + amOrPm;

                    // Set the font size inline for the "Created Date" column
                    return '<div style="font-size: 14px;">' + formattedDate + '</div>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '"> Delete </a> <a href="#" class="btn btn-success btn-reply" data-bs-toggle="modal" data-bs-target="#kt_modal_update"  data-id="' + row.id + '"> Reply </a> ';
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
    ShowAnyModal(".btn-details", "modal", "Admin/Contact/Details", "#ShowModal", "#kt_modal_details");
    ShowAnyModal(".btn-reply", "modal", "Admin/Contact/Reply", "#ShowModal", "#kt_modal_update");

    //$(document).on("hidden.bs.modal", ".modal", function () {
    //    $("body").removeAttr("style");
    //});

    $(document).on("click", ".btn-closee, .btn-hide", function () {
        // Trigger the modal's close functionality
        $('#kt_modal_details').modal('hide');
        $('#kt_modal_details').remove();

        $('#kt_modal_update').modal('hide');
        $('#kt_modal_update').remove();
    });


    $('.toast').toast('show');


    // Event handler for Delete button
    $(document).on('click', '.btn-delete', function (e) {
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
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                // If user confirms, delete the row and send request to the server
                var deleteUrl = '/Admin/Contact/Delete/' + eventId; // Replace with your actual Delete route URL
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
    });


});

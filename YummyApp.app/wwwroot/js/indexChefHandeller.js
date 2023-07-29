
$(document).ready(function () {
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
    ShowAnyModal(".btn-details", "modal", "Admin/Chef/Details", "#ShowModal", "#kt_modal_details");

    //$(document).on("hidden.bs.modal", ".modal", function () {
    //    $("body").removeAttr("style");
    //});

    $(document).on("click", ".btn-closee, .btn-hide", function () {
        // Trigger the modal's close functionality
        $('#kt_modal_details').modal('hide');
        $('#kt_modal_details').remove();

    });

    $('.toast').toast('show');


    // Event handler for Update button
    $('#chefs').on('click', '.btn-update', function (e) {
        e.preventDefault();
        var eventId = $(this).data('id');
        var updateUrl = '/Admin/Chef/Update/' + eventId; // Replace with your actual Update route URL
        window.location.href = updateUrl;
    });


    // Event handler for Delete button
    $('#chefs').on('click', '.btn-delete', function (e) {
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
                var deleteUrl = '/Admin/Chef/Delete/' + eventId; // Replace with your actual Delete route URL
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

    // Add a click event listener to the buttons with class 'btn-status'
    $(document).on('click', '.btn-status', function (event) {
        event.preventDefault(); // Prevent default button behavior
        var btn = $(this); // Save the reference to the button that was clicked
        var chefId = btn.data('id'); // Get the chef ID from the data attribute

        // Make the AJAX request with cache: false
        $.ajax({
            url: '/Admin/Chef/EditStatus/' + chefId,
            type: 'GET',
            cache: false, // Prevent caching of the response
            success: function (data) {


                // Check the current class and update it accordingly
                if (btn.hasClass('btn-danger')) {
                    btn.removeClass('btn-danger').addClass('btn-success');

                    // Update the button class and text based on the response
                    var newStatus = 'Active';
                    btn.text(newStatus);

                } else if (btn.hasClass('btn-success')) {
                    btn.removeClass('btn-success').addClass('btn-danger');

                    // Update the button class and text based on the response
                    var newStatus = 'Blocked';
                    btn.text(newStatus);
                }
            },
            error: function () {
                alert('An error occurred while updating the status.');
            }
        });
    });

});
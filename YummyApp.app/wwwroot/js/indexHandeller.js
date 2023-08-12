// Function to show Swal and submit the form
function showSwalAndSubmitForm(formSelector, successMessage, urlAddress) {

    $(formSelector).on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        // Create a new FormData object
        var formData = new FormData(this);

        var file = formData.get('Image'); // Get the uploaded file


        var fileSize = file.size; // Size in bytes
        var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes
        if (fileSize > maxSizeBytes) {
            // Show error alert using SweetAlert
            Swal.fire({
                title: 'Error',
                text: 'Image size should be within 4 megabytes.',
                icon: 'error',
                confirmButtonColor: '#d33',
                confirmButtonText: 'OK'
            });
            return; // Stop further execution
        }


        var allowedExtensions = ["jpg", "jpeg", "png"];
        var fileExtension = file.name.split('.').pop().toLowerCase();

        if (allowedExtensions.indexOf(fileExtension) === -1) {
            // Show error alert using SweetAlert
            Swal.fire({
                title: 'Error',
                text: 'Only JPG, JPEG, and PNG files are allowed.',
                icon: 'error',
                confirmButtonColor: '#d33',
                confirmButtonText: 'OK'
            });
            return; // Stop further execution
        }


        $.ajax({
            url: urlAddress, // Replace with your actual server URL to add/update the item
            type: 'POST',
            cache: false,
            data: formData,
            processData: false, // Important: prevent jQuery from processing the data
            contentType: false, // Important: let the server handle the content type
            success: function (data) {
                Swal.fire({
                    title: 'Success!',
                    text: successMessage,
                    icon: 'success',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'OK',
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Redirect to the Index action of the Meal controller
                        //window.location.href = '/Admin/Testimonial/Index';

                        //$('#kt_modal_new_address').modal('hide');
                        //$('#kt_modal_new_address').remove();
                        //$(".modal-backdrop.show").remove();

                        $('#events').DataTable().ajax.reload(null, false);

                        var discardButton = document.querySelector('.btn-discard');
                        if (discardButton) {
                            discardButton.click();
                        }
                    }
                });
            },
            error: function (xhr, status, error) {
                // Handle the error here
                if (xhr.status === 500) {
                    // Handle 400 error
                    console.error('Resource not found.');

                    // Redirect to the custom 404 page
                    window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
                } else {
                    // Handle other error codes
                    console.error('An error occurred:', error);
                    window.location.href = '/Error/500.html'
                }
            },
        });

    });

    // Reset the form on Discard button click
    $(formSelector).on('click', '[type="reset"]', function () {
        document.querySelector(formSelector).reset();
    });
}

$(document).ready(function () {
    // Show Swal and submit the form for Add event
    showSwalAndSubmitForm("#kt_modal_new_address_form", "Item has been added successfully.", '/Admin/Event/Add');

    // Show Swal and submit the form for Update event
    //showSwalAndSubmitForm("#kt_modal_update_form", "Item has been updated successfully.", '/Admin/Event/Update');

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
    ShowAnyModal(".btn-details", "modal", "Admin/Event/Details", "#ShowModal", "#kt_modal_details");

    //ShowAnyModal(".btn-update", "modal", "Admin/Event/Update", "#ShowModal", "#kt_modal_update");

    //ShowAnyModal(".btn-update", "modal", "Admin/Event/Update", "#ShowModal", "#kt_modal_new_address_form");

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

    $(".modal-backdrop.show").remove();
    $("#ShowModal").html(result);
    $("#kt_modal_update").modal("show");

    // Event handler for Delete button
    //$('#events').on('click', '.btn-delete', function (e) {
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
    //            var deleteUrl = '/Admin/Event/Delete/' + eventId; // Replace with your actual Delete route URL
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


});


$(document).on('click', '.btn-update', function () {
    // Load the modal content using AJAX
    var Id = $(this).data('id');
    var UrlUpdate = '/Admin/Event/Update/' + Id;

    $.get(UrlUpdate, function (data) {
        $(".modal-backdrop.show").remove();
        $("#ShowModal").html(data);
        $("#kt_modal_update").modal("show");

        // Attach an event listener to the submit button inside the modal
        $("#kt_modal_update").on('submit', 'form', function (e) {
            e.preventDefault(); // Prevent default form submission

            var formData = new FormData(this);

            var file = formData.get('Image'); // Get the uploaded file
            

            if (file.size != 0) {

                var fileSize = file.size; // Size in bytes
                var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes
                if (fileSize > maxSizeBytes) {
                    // Show error alert using SweetAlert
                    Swal.fire({
                        title: 'Error',
                        text: 'Image size should be within 4 megabytes.',
                        icon: 'error',
                        confirmButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    });
                    return; // Stop further execution
                }

                var allowedExtensions = ["jpg", "jpeg", "png"];
                var fileExtension = file.name.split('.').pop().toLowerCase();

                if (allowedExtensions.indexOf(fileExtension) === -1) {
                    // Show error alert using SweetAlert
                    Swal.fire({
                        title: 'Error',
                        text: 'Only JPG, JPEG, and PNG files are allowed.',
                        icon: 'error',
                        confirmButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    });
                    return; // Stop further execution
                }
            }
            $.ajax({
                url: "/Admin/Event/Update", // Replace with your actual server URL to add/update the item
                type: 'POST',
                cache: false,
                data: formData,
                processData: false, // Important: prevent jQuery from processing the data
                contentType: false, // Important: let the server handle the content type
                success: function (data) {
                    Swal.fire({
                        title: 'Success!',
                        text: "Item has been updated successfully.",
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'OK',
                    }).then((result) => {
                        if (result.isConfirmed) {
                            // Redirect to the Index action of the Meal controller
                            //window.location.href = '/Admin/Testimonial/Index';
                            $('#kt_modal_update').modal('hide');
                            $('#kt_modal_update').remove();
                            $('#events').DataTable().ajax.reload(null, false);
                        }
                    });
                },
                error: function (xhr, status, error) {
                    // Handle the error here
                    if (xhr.status === 500) {
                        // Handle 400 error
                        console.error('Resource not found.');

                        // Redirect to the custom 404 page
                        window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
                    } else {
                        // Handle other error codes
                        console.error('An error occurred:', error);
                        window.location.href = '/Error/500.html'
                    }
                },
            });
        });
    });



});

// Function to show Swal and submit the form
function showSwalAndSubmitForm(formSelector, successMessage, urlAddress) {

    $(formSelector).on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        // Create a new FormData object
        var formData = new FormData(this);

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
                        window.location.href = '/Chef/Meal/Index';
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

        // Send AJAX request to add/update the item
        //$.ajax({
        //    url: urlAddress, // Replace with your actual server URL to add/update the item
        //    type: 'POST',
        //    cache: false,
        //    data: formData,
        //    processData: false, // Important: prevent jQuery from processing the data
        //    contentType: false, // Important: let the server handle the content type
        //    success: function (data) {
        //        Swal.fire({
        //            title: 'Success!',
        //            text: successMessage,
        //            icon: 'success',
        //            confirmButtonColor: '#3085d6',
        //            confirmButtonText: 'OK',
        //        }).then((result) => {
        //            if (result.isConfirmed) {
        //                // Trigger the form submission programmatically
        //                $(formSelector).off('submit').submit();
        //                // Redirect to the Index action of the Meal controller
        //                window.location.href = '/Chef/Meal/Index';
        //            }
        //        });
        //    },
        //    error: function (error) {
        //        // Handle any error that may occur during the request
        //        console.error(error);
        //    },
        //});
    });



    // Intercept form submission
    //$(formSelector).on('submit', function (e) {
    //    e.preventDefault(); // Prevent default form submission

    //    // Serialize the form data
    //    var formData = $(this).serialize();
    //    // Send AJAX request to add/update the item
    //    $.ajax({
    //        url: urlAddress, // Replace with your actual server URL to add/update the item
    //        type: 'POST',
    //        cache: false,
    //        data: formData,
    //        success: function (data) {
    //            Swal.fire({
    //                title: 'Success!',
    //                text: successMessage,
    //                icon: 'success',
    //                confirmButtonColor: '#3085d6',
    //                confirmButtonText: 'OK'
    //            }).then((result) => {
    //                if (result.isConfirmed) {
    //                    // Trigger the form submission programmatically
    //                    $(formSelector).off('submit').submit();
    //                }
    //            });
    //        },
    //        error: function (error) {
    //            // Handle any error that may occur during the request
    //            console.error(error);
    //        }
    //    });
    //});

    // Reset the form on Discard button click
    $(formSelector).on('click', '[type="reset"]', function () {
        document.querySelector(formSelector).reset();
    });
}

$(document).ready(function () {
    // Show Swal and submit the form for Add event
    showSwalAndSubmitForm("#kt_modal_new_address_form", "Item has been added successfully.", '/Chef/Meal/Add');

    // Show Swal and submit the form for Update event
    //showSwalAndSubmitForm("#kt_modal_update_form", "Item has been updated successfully.", '/Chef/Meal/Update');

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
    ShowAnyModal(".btn-details", "modal", "Chef/Meal/Details", "#ShowModal", "#kt_modal_details");

    ShowAnyModal(".btn-update", "modal", "Chef/Meal/Update", "#ShowModal", "#kt_modal_update");

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

});



// Event handler for Delete button
$('#meals').on('click', '.btn-delete', function (e) {
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
            var deleteUrl = '/Chef/Meal/Delete/' + eventId; // Replace with your actual Delete route URL
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
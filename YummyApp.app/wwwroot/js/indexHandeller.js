// Function to show Swal and submit the form
function showSwalAndSubmitForm(formSelector, successMessage, urlAddress) {
    // Intercept form submission
    $(formSelector).on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        // Serialize the form data
        var formData = $(this).serialize();
        // Send AJAX request to add/update the item
        $.ajax({
            url: urlAddress, // Replace with your actual server URL to add/update the item
            type: 'POST',
            cache: false,
            data: formData,
            success: function (data) {
                Swal.fire({
                    title: 'Success!',
                    text: successMessage,
                    icon: 'success',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Trigger the form submission programmatically
                        $(formSelector).off('submit').submit();
                    }
                });
            },
            error: function (error) {
                // Handle any error that may occur during the request
                console.error(error);
            }
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

    ShowAnyModal(".btn-update", "modal", "Admin/Event/Update", "#ShowModal", "#kt_modal_update");

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
$('#events').on('click', '.btn-delete', function (e) {
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
            var deleteUrl = '/Admin/Event/Delete/' + eventId; // Replace with your actual Delete route URL
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
//// Function to show Swal and submit the form
//function showSwalAndSubmitForm(formSelector, successMessage, urlAddress) {

//    $(formSelector).on('submit', function (e) {
//        e.preventDefault(); // Prevent default form submission

//        // Create a new FormData object
//        var formData = new FormData(this);

//        var file = formData.get('Image'); // Get the uploaded file



//         //Define header signatures for valid image formats
//        var validHeaders = [
//            [0xFF, 0xD8, 0xFF, 0xE0], // JPEG
//            [0x89, 0x50, 0x4E, 0x47], // PNG
//            [ 0xFF, 0xD8, 0xFF ] // JPG
//        ];

//        var fileReader = new FileReader();
//        fileReader.onload = function (event) {
//            var headerBytes = new Uint8Array(event.target.result).subarray(0, 4);

//            var isValidFormat = validHeaders.some(function (validHeader) {
//                return validHeader.every(function (byte, index) {
//                    return byte === headerBytes[index];
//                });
//            });

//            if (!isValidFormat) {
//                Swal.fire({
//                    title: 'Error',
//                    text: 'Invalid image file.',
//                    icon: 'error',
//                    confirmButtonColor: '#d33',
//                    confirmButtonText: 'OK'
//                });
//                return; // Stop further execution
//            }


//        $.ajax({
//            url: urlAddress, // Replace with your actual server URL to add/update the item
//            type: 'POST',
//            cache: false,
//            data: formData,
//            processData: false, // Important: prevent jQuery from processing the data
//            contentType: false, // Important: let the server handle the content type
//            success: function (data) {
//                Swal.fire({
//                    title: 'Success!',
//                    text: successMessage,
//                    icon: 'success',
//                    confirmButtonColor: '#3085d6',
//                    confirmButtonText: 'OK',
//                }).then((result) => {
//                    if (result.isConfirmed) {
//                        // Redirect to the Index action of the Meal controller
//                        //window.location.href = '/Admin/Testimonial/Index';

//                        //$('#kt_modal_new_address').modal('hide');
//                        //$('#kt_modal_new_address').remove();
//                        //$(".modal-backdrop.show").remove();

//                        $('#testimonials').DataTable().ajax.reload(null, false);

//                        var discardButton = document.querySelector('.btn-discard');
//                        if (discardButton) {
//                            discardButton.click();
//                        }
//                    }
//                });
//            },
//            error: function (xhr, status, error) {
//                // Handle the error here
//                if (xhr.status === 500) {
//                    // Handle 400 error
//                    console.error('Resource not found.');

//                    // Redirect to the custom 404 page
//                    window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
//                } else {
//                    // Handle other error codes
//                    console.error('An error occurred:', error);
//                    window.location.href = '/Error/500.html'
//                }
//            },
//        });

//    });

//    // Reset the form on Discard button click
//    $(formSelector).on('click', '[type="reset"]', function () {
//        document.querySelector(formSelector).reset();
//    });
//}

// Function to show Swal and submit the form
function showSwalAndSubmitForm(formSelector, successMessage, urlAddress) {
    $(formSelector).on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        // Create a new FormData object
        var formData = new FormData(this);

        var file = formData.get('Image'); // Get the uploaded file

        // Define header signatures for valid image formats
        var validHeaders = [
            [0xFF, 0xD8, 0xFF, 0xE0], // JPEG
            [0x89, 0x50, 0x4E, 0x47], // PNG
            [0xFF, 0xD8, 0xFF] // JPG
        ];

        var fileReader = new FileReader();
        fileReader.onload = function (event) {
            var headerBytes = new Uint8Array(event.target.result).subarray(0, 4);

            var isValidFormat = validHeaders.some(function (validHeader) {
                return validHeader.every(function (byte, index) {
                    return byte === headerBytes[index];
                });
            });

            if (!isValidFormat) {
                Swal.fire({
                    title: 'Error',
                    text: 'Invalid image file.',
                    icon: 'error',
                    confirmButtonColor: '#d33',
                    confirmButtonText: 'OK'
                });
                return; // Stop further execution
            }

            // Perform the AJAX request here
            $.ajax({
                url: urlAddress,
                type: 'POST',
                cache: false,
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    Swal.fire({
                        title: 'Success!',
                        text: successMessage,
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            // Reload data and perform other actions
                            $('#testimonials').DataTable().ajax.reload(null, false);
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
                        console.error('Resource not found.');
                        window.location.href = '/Error/500.html';
                    } else {
                        console.error('An error occurred:', error);
                        window.location.href = '/Error/500.html';
                    }
                },
            });
        };

        // Read the file as an ArrayBuffer
        fileReader.readAsArrayBuffer(file);
    });

    // Reset the form on Discard button click
    $(formSelector).on('click', '[type="reset"]', function () {
        document.querySelector(formSelector).reset();
    });
}



$(document).ready(function () {
    // Show Swal and submit the form for Add event
    showSwalAndSubmitForm("#kt_modal_new_address_form", "Item has been added successfully.", '/Admin/Testimonial/Add');

    // Show Swal and submit the form for Update event
    //showSwalAndSubmitForm("#kt_modal_update_form", "Item has been updated successfully.", '/Admin/Testimonial/Update');

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
    ShowAnyModal(".btn-details", "modal", "Admin/Testimonial/Details", "#ShowModal", "#kt_modal_details");

    //ShowAnyModal(".btn-update", "modal", "Admin/Testimonial/Update", "#ShowModal", "#kt_modal_update");

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


    // Add a click event listener to the buttons with class 'btn-status'
    $(document).on('click', '.btn-status', function (event) {
        event.preventDefault(); // Prevent default button behavior
        var btn = $(this); // Save the reference to the button that was clicked
        var chefId = btn.data('id'); // Get the chef ID from the data attribute

        // Make the AJAX request with cache: false
        $.ajax({
            url: '/Admin/Testimonial/EditStatus/' + chefId,
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
            var deleteUrl = '/Admin/Testimonial/Delete/' + eventId; // Replace with your actual Delete route URL
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

    // Attach an event listener to the button that opens the modal
//$(document).on('click', '.btn-update', function () {
//    // Load the modal content using AJAX
//    var Id = $(this).data('id');
//    var UrlUpdate = '/Admin/Testimonial/Update/' + Id;

//    $.get(UrlUpdate, function (data) {
//        $(".modal-backdrop.show").remove();
//        $("#ShowModal").html(data);
//        $("#kt_modal_update").modal("show");

//        // Attach an event listener to the submit button inside the modal
//        $("#kt_modal_update").on('submit', 'form', function (e) {
//            e.preventDefault(); // Prevent default form submission

//            var formData = new FormData(this);

//            var file = formData.get('Image'); // Get the uploaded file
//            if (file.size != 0) {
//                var allowedExtensions = ["jpg", "jpeg", "png"];
//                var fileExtension = file.name.split('.').pop().toLowerCase();

//                if (allowedExtensions.indexOf(fileExtension) === -1) {
//                    // Show error alert using SweetAlert
//                    Swal.fire({
//                        title: 'Error',
//                        text: 'Only JPG, JPEG, and PNG files are allowed.',
//                        icon: 'error',
//                        confirmButtonColor: '#d33',
//                        confirmButtonText: 'OK'
//                    });
//                    return; // Stop further execution
//                }
//            }
//                $.ajax({
//                    url: "/Admin/Testimonial/Update", // Replace with your actual server URL to add/update the item
//                    type: 'POST',
//                    cache: false,
//                    data: formData,
//                    processData: false, // Important: prevent jQuery from processing the data
//                    contentType: false, // Important: let the server handle the content type
//                    success: function (data) {
//                        Swal.fire({
//                            title: 'Success!',
//                            text: "Item has been updated successfully.",
//                            icon: 'success',
//                            confirmButtonColor: '#3085d6',
//                            confirmButtonText: 'OK',
//                        }).then((result) => {
//                            if (result.isConfirmed) {
//                                // Redirect to the Index action of the Meal controller
//                                //window.location.href = '/Admin/Testimonial/Index';
//                                $('#kt_modal_update').modal('hide');
//                                $('#kt_modal_update').remove();
//                                $('#testimonials').DataTable().ajax.reload(null, false);
//                            }
//                        });
//                    },
//                    error: function (xhr, status, error) {
//                        // Handle the error here
//                        if (xhr.status === 500) {
//                            // Handle 400 error
//                            console.error('Resource not found.');

//                            // Redirect to the custom 404 page
//                            window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
//                        } else {
//                            // Handle other error codes
//                            console.error('An error occurred:', error);
//                            window.location.href = '/Error/500.html'
//                        }
//                    },
//                });
//            });
//        });



//});


$(document).on('click', '.btn-update', function () {
    // Load the modal content using AJAX
    var Id = $(this).data('id');
    var UrlUpdate = '/Admin/Testimonial/Update/' + Id;

    $.get(UrlUpdate, function (data) {
        $(".modal-backdrop.show").remove();
        $("#ShowModal").html(data);
        $("#kt_modal_update").modal("show");

        // Attach an event listener to the submit button inside the modal
        $("#kt_modal_update").on('submit', 'form', function (e) {
            e.preventDefault(); // Prevent default form submission

            var formData = new FormData(this);

            var file = formData.get('Image'); // Get the uploaded file
            if (file.size !== 0) {
                // Define header signatures for valid image formats
                var validHeaders = [
                    [0xFF, 0xD8, 0xFF, 0xE0], // JPEG
                    [0x89, 0x50, 0x4E, 0x47], // PNG
                    [0xFF, 0xD8, 0xFF] // JPG
                ];

                var fileReader = new FileReader();
                fileReader.onload = function (event) {
                    var headerBytes = new Uint8Array(event.target.result).subarray(0, 4);

                    var isValidFormat = validHeaders.some(function (validHeader) {
                        return validHeader.every(function (byte, index) {
                            return byte === headerBytes[index];
                        });
                    });

                    if (!isValidFormat) {
                        Swal.fire({
                            title: 'Error',
                            text: 'Invalid image file format.',
                            icon: 'error',
                            confirmButtonColor: '#d33',
                            confirmButtonText: 'OK'
                        });
                        return; // Stop further execution
                    }

                    // Continue with AJAX request if image format is valid
                    $.ajax({
                        url: "/Admin/Testimonial/Update", // Replace with your actual server URL to add/update the item
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
                                    $('#kt_modal_update').modal('hide');
                                    $('#kt_modal_update').remove();
                                    $('#testimonials').DataTable().ajax.reload(null, false);
                                }
                            });
                        },
                        error: function (xhr, status, error) {
                            // Handle the error here
                            if (xhr.status === 500) {
                                console.error('Resource not found.');
                                window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
                            } else {
                                console.error('An error occurred:', error);
                                window.location.href = '/Error/500.html';
                            }
                        },
                    });
                };

                // Read the file as an ArrayBuffer
                fileReader.readAsArrayBuffer(file);
            } else {
                // No image provided, continue with the AJAX request
                $.ajax({
                    url: "/Admin/Testimonial/Update", // Replace with your actual server URL to add/update the item
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
                                $('#kt_modal_update').modal('hide');
                                $('#kt_modal_update').remove();
                                $('#testimonials').DataTable().ajax.reload(null, false);
                            }
                        });
                    },
                    error: function (xhr, status, error) {
                        // Handle the error here
                        if (xhr.status === 500) {
                            console.error('Resource not found.');
                            window.location.href = '/Error/500.html'; // Replace with the actual URL of your custom 404 page
                        } else {
                            console.error('An error occurred:', error);
                            window.location.href = '/Error/500.html';
                        }
                    },
                });
            }
        });
    });
});

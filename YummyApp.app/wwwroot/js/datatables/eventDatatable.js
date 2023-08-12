//$(document).ready(function () {
//    $('#events').dataTable({
//        "serverSide": true,
//        "filter": true,
//        "ajax": {
//            "url": "/Admin/Event/AllData",
//            "type": "POST",
//            "datatype": "JSON"
//        },
//        "columnDefs": [{
//        "targets": [0],
//        "visible": false,
//        "searchable": false
//        }],
//        "columns": [
//            { "data": "id", "name": "Id", "autowidth": true },
//            //{
//            //    "render": function (data, type, row) {
//            //        return `<a href="Admin/Event/Get/${row.imageName}"></a>`
//            //    },
//            //    "name": "Id"
//            //},
//            {
//                "render": function (data, type, row) {
//                    return `<a class="text-dark fw-bold text-hover-primary mb-1 fs-6" href="/Admin/Event/Details/${row.id}">${row.title}</a>`
//                },
//                "name": "Title"
//            },
//            //{ "data": "title", "name": "Title", "autowidth": true },
//            { "data": "price", "name": "Price", "autowidth": true },
//            //{ "data": "description", "name": "Description", "autowidth": true },
//            {
//                "render": function (data, type, row) {
//                    return `<img src="/EventImages/${row.imageName}" style="width:60px; height:60px;">`
//                },
//                "name": "Image"
//            },
//            {
//                "render": function (data, type, row) {
//                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '"> Delete </a> <a href="#" class="btn btn-primary btn-update" data-id="' + row.id + '"> Update </a>';
//                },
//                "orderable": false
//            }

//        ]
//    });

//    // Event handler for Delete button
//    $('#events').on('click', '.btn-delete', function (e) {
//        e.preventDefault();
//        var eventId = $(this).data('id');
//        var deleteUrl = '/Admin/Event/Delete/' + eventId; // Replace with your actual Delete route URL
//        window.location.href = deleteUrl;
//    });

//    // Event handler for Update button
//    $('#events').on('click', '.btn-update', function (e) {
//        e.preventDefault();
//        var eventId = $(this).data('id');
//        var updateUrl = '/Admin/Event/Update/' + eventId; // Replace with your actual Update route URL
//        window.location.href = updateUrl;
//    });



//});

$(document).ready(function () {
    $('#events').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Event/AllData",
            "type": "POST",
            "datatype": "JSON"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return `<a href="#" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details" title="Show Details"  data-id="${row.id}">${row.title}</a>`
                },
                "name": "Title"
            },
            { "data": "price", "name": "Price", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return `<img src="/EventImages/${row.imageName}" style="width:60px; height:60px;">`
                },
                "name": "Image"
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '"> Delete </a> <a href="#" class="btn btn-primary btn-update" data-bs-toggle="modal" data-bs-target="#kt_modal_update"  data-id="' + row.id + '"> Update </a>';
                },
                "orderable": false
            }

        ]
    });

    

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

    // Event handler for Update button
    //$('#events').on('click', '.btn-update', function (e) {
    //    e.preventDefault();
    //    var eventId = $(this).data('id');
    //    var updateUrl = '/Admin/Event/Update/' + eventId; // Replace with your actual Update route URL
    //    window.location.href = updateUrl;
    //});

});



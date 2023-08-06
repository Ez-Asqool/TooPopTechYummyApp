$(document).ready(function () {
    $('#meals').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Chef/Meal/AllData",
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
                targets: 4, // Index of the Actions column (zero-based index)
                width: '200px', // Adjust the width as needed
                orderable: false // Disable sorting on the Actions column
            }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return `<a href="#" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details" title="Show Details"  data-id="${row.id}">${row.name}</a>`
                },
                "name": "Name"
            },
            { "data": "price", "name": "Price", "autowidth": true },
            {
                "data": "category",
                "name": "Category",
                "autowidth": true,

                render: function (data, type, row) {
                    return '<div style="font-size: 16px;">' + data + '</div>';
                }
            },
            {
                "render": function (data, type, row) {
                    return `<img src="/MealImages/${row.imageName}" style="width:60px; height:60px;">`
                },
                "name": "Image"
            },
            {
                "render": function (data, type, row) {
                    return '<a href="#" class="btn btn-danger btn-delete" data-id="' + row.id + '"> Delete </a> <a href="#" class="btn btn-primary btn-update" data-bs-toggle="modal" data-bs-target="#kt_modal_update"  data-id="' + row.id + '"> Update </a>';
                },
                "name": "Actions",
                "orderable": false
            }

        ]
    });

});



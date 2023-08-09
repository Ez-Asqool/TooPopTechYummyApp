$(document).ready(function () {
    $('#testimonials').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Admin/Testimonial/AllData",
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
                "render": function (data, type, row) {
                    return `<a href="#" style="font-size: 18px;" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  title="Show Details" data-id="${row.id}">${row.name}</a>`
                },
                "name": "Name"
            },
            {
                "render": function (data, type, row) {
                    return `<a href="#" style="font-size: 18px;" class=" btn-details text-dark fw-bold text-hover-primary mb-1 fs-6 "  data-bs-toggle="modal" data-bs-target="#kt_modal_details"  data-id="${row.id}">${row.jobTitle}</a>`
                },
                "name": "JobTitle"
            },
            {
                data: 'stars',
                name: 'Stars',
                autowidth: true,
                render: function (data, type, row) {
                    // Set the font size inline for the "Email" column
                    return '<div style="font-size: 16px;">' + data + '</div>';
                }
            },
            {
                "render": function (data, type, row) {
                    return `<img src="/TestimonialsImages/${row.imageName}" style="width:60px; height:60px;">`
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

});



$(document).ready(function () {
    "use strict";
    $("#guests-datatable").DataTable({
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            },
            info: "Mostrando invitados _START_ a _END_ de _TOTAL_",
            infoEmpty: "Mostrando 0 a 0 de 0 entradas",
            infoFiltered: "(filtrado de _MAX_ entradas totales)",
            lengthMenu: 'Mostrar <select class=\'form-select form-select-sm ms-1 me-1\'><option value="5">5</option><option value="10">10</option><option value="20">20</option><option value="-1">Todos</option></select> invitados',
            search: "Buscar",
            emptyTable: "No hay datos disponibles en la tabla"
        },
        pageLength: 5,
        columns: [
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !0
            },
            {
                orderable: !1
            }],
        select: { style: "multi" },
        order: [[1, "asc"]],
        drawCallback: function () {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded"), $("#products-datatable_length label").addClass("form-label"), document.querySelector(".dataTables_wrapper .row").querySelectorAll(".col-md-6").forEach(function (e) {
                e.classList.add("col-sm-6"), e.classList.remove("col-sm-12"), e.classList.remove("col-md-6")
            })
        },
        oLanguage: {
            sSearch: "Quick Search:"
        }
    })
});
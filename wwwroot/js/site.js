// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();



});

var listaProductos = [];

    function AgregarAlCarrito(IdProducto) {
        var IdCantidadInput = 'cantidad' + IdProducto
        var cantidad = document.getElementById(IdCantidadInput).value;
        listaProductos.push({
            Key: IdProducto,
            Value: cantidad
        });
        alert(IdCantidadInput);
}

            function IrAlCarrito() {
                $.ajax({
                    type: "POST",
                    data: { productos : listaProductos},
                    dataType: "json",
                    url: "/Productos/CarritoDeCompras",
                    success: function (message) {
                        alert(message);
                    }
                });

        }
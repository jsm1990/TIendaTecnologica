// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
});

function ObtenerCantidad(IdProducto) {
    var IdCantidadInput = 'cantidad' + IdProducto
    var cantidad = document.getElementById(IdCantidadInput).value;
    return cantidad;
}

function IrAlCarrito(cantidad)
{
    var div = document.getElementById('alertCarrito');
    if (cantidad != 0) {
        window.location.href = "/Productos/CarritoDeCompras";
    }
    else
    {
        // show
        div.style.display = "block";
    } 
}
$(function () {
    $('a#ModificarCarrito').click(function () {
        $('form#CarritoForm').submit();
    });
});
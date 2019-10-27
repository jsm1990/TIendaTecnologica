
            $(document).ready(function () {
                ObtenerProvincias();
            });

function ObtenerProvincias() {
                $.ajax({
                    dataType: "json",
                    url: "https://ubicaciones.paginasweb.cr/provincias.json",
                    data: {},
                    success: function (data) {
                        var html = "";
                        for (key in data) {
                            html += "<option value='" + key + "'>" + data[key] + "</option>";
                        }
                        $('#selectProvincias').html(html);
                        var provincia = $('#Provincia').val();
                        if (provincia != undefined) {
                            $("#selectProvincias option:contains(" + provincia + ")").prop('selected', true);
                        }
                        $('#selectProvincias').change();
                    }
                });
   }
   function ObtenerCantones(provincia)
   {   
                this.provincia = provincia;
                var urlCantones="https://ubicaciones.paginasweb.cr/provincia/"+provincia+"/cantones.json";
                $.ajax({
                dataType: "json",
                url: urlCantones,
                data: {},
                success: function (data) {
                            var html = "";
                            for(key in data) {
                            html += "<option value='" + key + "'>" + data[key] + "</option>";
                         }
                    $('#selectCantones').html(html);

                    var canton = $('#Canton').val();
                    if (canton != undefined) {
                        $("#selectCantones option:contains(" + canton + ")").prop('selected', true);
                    }
                    $('#selectCantones').change();
                    //$('#selectCantones').val(1).change();
        }
                });
}
function ObtenerDistritos(provincia, canton)
           {
                this.provincia = provincia;
                this.canton = canton;
                var urlDistritos="https://ubicaciones.paginasweb.cr/provincia/"+provincia+"/canton/"+canton+"/distritos.json";
                $.ajax({
                    dataType: "json",
                    url: urlDistritos,
                    data: {},
                    success: function (data) {
                                 var html = "";
                                 for(key in data) {
                                 html += "<option value='" + key + "'>" + data[key] + "</option>";
                            }
                        $('#selectDistritos').html(html);
                        var distrito = $('#Distrito').val();
                        if (distrito != undefined) {
                            $("#selectDistritos option:contains(" + distrito + ")").prop('selected', true);
                        }
                        $('#selectDistritos').change();
                    }
                });
    var distrito = $('#Distrito').val();
    if (distrito != undefined) {
        $("#selectDistritos option:contains(" + distrito + ")").attr('selected', 'selected');
    }
}
$('#selectProvincias').on('change', function() {
    var provincia = this.value;

    ObtenerCantones(provincia);
       });

$('#selectCantones').on('change', function() {
    var provincia = $('#selectProvincias').val();
    var canton = this.value;
    ObtenerDistritos(provincia, canton);
    //$('#Canton').val(this.value);
});
$('#selectDistritos').on('change', function () {
   // $('#Distrito').val()
});

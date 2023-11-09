function MostrarInfoDestinosAjax(ID_Viaje) {
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/MostrarInfoDestinosAjax',
            data: { ID_Viaje: ID_Viaje },
            success: function (response) {
                var contenido = "";
                response.forEach(viaje => {
                    contenido += "<li>" + viaje.nombre + "</li>";
                });
                $("#contenidoModal").html(contenido);
            }            
        }
    )
}

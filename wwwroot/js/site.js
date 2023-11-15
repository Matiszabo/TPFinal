function MostrarInfoDestinosAjax(ID_V) {
    $.ajax({
        type: 'POST',
        dataType: 'html',
        url: '/Home/MostrarInfoDestinosAjax',
        data: { ID_Viaje: ID_V },
        success: function (response) {
            $("#DescripcionContainer").html(response);
            $('#ModalViaje').modal('show'); // Para mostrar el modal después de cargar la información
        },
        error: function (error) {
            console.log(error);
        }
    });
}
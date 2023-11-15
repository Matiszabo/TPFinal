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

function DarLike(idV, element) {
    let h6CantLikes = element.parentNode.children[2];
    let elementIsLiked = element.src.includes('CorazonBlanco.jpg');
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/LikesAjax',
        data:
        {
            ID_Viaje: idV,
            Likes: !elementIsLiked ? -1 : 1  // Cambiado de CantLikes a Likes
        },
        success: function (response) {
            console.log(response);
            if (elementIsLiked) element.src = '/CorazonRojo.jpg';
            else element.src = '/CorazonBlanco.jpg';
            h6CantLikes.innerText = response;
        }
    });
}



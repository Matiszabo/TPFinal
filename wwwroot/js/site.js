function MostrarInfoDestinosAjax(ID_V) {
    $.ajax({
        type: 'POST',
        dataType: 'html',
        url: '/Home/MostrarInfoDestinosAjax',
        data: { ID_Viaje: ID_V },
        success: function (response) {
            $("#DescripcionContainer").html(response);
            // Wait for the description to be loaded before displaying the modal
            $('#ModalViaje').on('shown.bs.modal', function () {
                $(this).modal('hide');
                $('#ModalViaje').modal('show');
            });
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
            element.attr('src', elementIsLiked ? '/CorazonRojo.jpg' : '/CorazonBlanco.jpg');
            h6CantLikes.innerText = response;
        }
    });
}





function MostrarInfoDestinosAjax(id) {
    console.log(0);
    
    $.ajax({
        url: '/Home/MostrarInfoDestinosAjax', 
        type: 'GET',
        datatype: 'JSON',
        data: {ID_Viaje: id},
        success: 
        function (response) {
            console.log(1)
            contenido="";
            response.forEach(Viaje => {
                contenido += "<b>" + Viaje.descripcion + "</b>";
            });
            console.log(contenido)
            $("#DescripcionContainer").html(contenido);
        }     
    
    });
    console.log(1);
}   


function DarLike(id, element) {
    let h6CantLikes = element.parentNode.children[2];
    let elementIsLiked = element.src.includes('CorazonBlanco.jpg');
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/LikesAjax',
        data:
        {
            ID_Viaje: id,
            Likes: !elementIsLiked ? -1 : 1  // Cambiado de CantLikes a Likes
        },
        success: function (response) {
            console.log(response);
            element.attr('src', elementIsLiked ? '/CorazonRojo.jpg' : '/CorazonBlanco.jpg');
            h6CantLikes.innerText = response;
        }
    });
}
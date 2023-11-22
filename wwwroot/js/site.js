function MostrarMasInfo(idJ) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/MostrarMasInfoAjax',
        data: { IdJuego: idJ },
        success: function (response) {
            console.log(response);
            $("#FechaCreacion").html("Fecha de lanzamiento: " + response.fechaCreacion.substr(0, response.fechaCreacion.length - 10));
            $("#Descripcion").html(response.descripcion);
        }

    })
}

function Likes(idJ, element) {
    let h6CantLikes = element.parentNode.children[2];
    let elementIsLiked = element.src.includes('CorazonBlanco.jpg');
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/LikesAjax',
        data:
        {
            IdJuego: idJ,
            CantLikes: !elementIsLiked ? -1 : 1 
        },
        success: function (response) {
            console.log(response);
            if (elementIsLiked) element.src = '/CorazonRojo.jpg';
            else element.src = '/CorazonBlanco.jpg';
            h6CantLikes.innerText = response;
        }

    })
    //console.log(element);
}

function CrearCuenta() {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/CrearCuentaAjax',
        //data: { IdUsuario: idU },
        success: function (response) {
            let content = "Nombre de usuario: <input type='text' class='play' id='player' name='Nombre' placeholder='Ingrese su nombre'></input>"
            $("#CrearCuenta").html(content);
        }

    })
}
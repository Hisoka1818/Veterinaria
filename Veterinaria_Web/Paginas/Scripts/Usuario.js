class Usuario {
    constructor(ID_Usuario, ID_Propietario, userName, Clave) {
        this.ID_Usuario = ID_Usuario;
        this.ID_Propietario = ID_Propietario;
        this.userName = userName;
        this.Clave = Clave;
    }
}
jQuery(function () {
    //Se ejecuta al cargar la página
    LlenarComboXServicios("https://localhost:44362/api/Perfiles/LlenarCombo", "#cboPerfil");
    LlenarTabla();
});
function Editar(ID_Usuario, ID_Propietario, Nombre, Usuario, Perfil, idUsuarioPerfil) {
    $("#txtNombre").val(Nombre)
    $("#txtID_Usuario").val(ID_Usuario);
    $("#txtID_Propietario").val(ID_Propietario);
    $("#txtUsuario").val(Usuario);
    $("#cboPerfil").val(Perfil);
    $("#txtID_Usuario").val(ID_Usuario);
    $("#txtIdUsuarioPerfil").val(idUsuarioPerfil);
}
function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Usuarios/ListarUsuarios", "#tblUsuarios");
}
//Holaa
async function EjecutarComando(Metodo, Funcion) {
    let ID_Perfil = $("#cboPerfil").val();
    let Clave = $("#txtClave").val();
    let RepitaClave = $("#txtConfirmaClave").val();
    if (Clave != RepitaClave) {
        $("#dvMensaje").html("Las claves no son iguales");
        return;
    }
    let URL = "https://localhost:44362/api/Usuarios/" + Funcion + "?Perfil=" + ID_Perfil;
    const usuario = new Usuario($("#txtID_Usuario").val(), $("#txtID_Propietario").val(), $("#txtUsuario").val(), Clave);
    await EjecutarComandoServicio(Metodo, URL, usuario);
    LlenarTabla();
}

async function Activar(idUsuarioPerfil, Activo, Usuario) {
    let Mensaje = Activo ? "Está seguro de activar el usuario: " + Usuario + "?" : "Está seguro de inactivar el usuario: " + Usuario + "?";

    if (window.confirm(Mensaje)) {
        let URL = "https://localhost:44362/api/Usuarios/Activar?idUsuarioPerfil=" + idUsuarioPerfil + "&Activo=" + Activo;
        await EjecutarComandoServicio("PUT", URL, null);
        LlenarTabla();
    }
    else {
        alert("Se canceló el proceso");
    }
}

async function BuscarPropietario() {
    let ID = $('#txtID_Propietario').val();
    URL = "https://localhost:44362/api/Propietarios/ConsultarXID?ID=" + ID;
    const propietario = await ConsultarServicio(URL);
    if (propietario != null) {
        $("#txtNombre").val(propietario.Nombre);
        /*$("#txtMascota").val(propietario[0].Mascota)*/
        
    }
    else {
        $('#dvMensaje').html("El Propietario no existe en la base de datos");
        $("#txtNombre").val("");
        
    }
}

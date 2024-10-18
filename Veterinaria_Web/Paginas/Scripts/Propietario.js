jQuery(function () {
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Propietarios/LlenarTabla", "#tblPropietarios");
}

class Propietario {
    constructor(ID_Propietario, Nombre, Apellido, Direccion, Correo, Celular) {
        this.ID_Propietario = ID_Propietario;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Direccion = Direccion;
        this.Correo = Correo;
        this.Celular = Celular;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const propietario = new Propietario($("#txtPropietarioID").val(), $("#txtNombre").val(), $("#txtApellido").val(),
                                    $("#txtDireccion").val(), $("#txtCorreo").val(), $("#txtCelular").val());
    let URL = "https://localhost:44362/api/Propietarios/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, propietario);
    LlenarTabla();
}

async function Consultar() {
    let ID = $('#txtPropietarioID').val();
    URL = "https://localhost:44362/api/Propietarios/ConsultarXID?ID=" + ID;
    const propietario = await ConsultarServicio(URL);
    if (propietario != null) {
        $("#txtPropietarioID").val(propietario.ID_Propietario);
        $("#txtNombre").val(propietario.Nombre);
        $("#txtApellido").val(propietario.Apellido);
        $("#txtDireccion").val(propietario.Direccion);
        $("#txtCorreo").val(propietario.Correo);
        $("#txtCelular").val(propietario.Celular)
        $('#dvMensaje').html("");
    }
    else {
        $('#dvMensaje').html("El Propietario no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtDireccion").val("");
        $("#txtCorreo").val("");
        $("#txtCelular").val("");
    }
}
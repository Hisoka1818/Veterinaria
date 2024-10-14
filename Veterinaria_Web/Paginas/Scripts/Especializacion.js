jQuery(function () {
    LlenarTabla();
});


function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Especializacion/LlenarTabla", "#tblespecializacion");
}

class ESPECIALIZACION {
    constructor(ID_Especializacion, Nombre, Descripcion) {
        this.ID_Especializacion = ID_Especializacion;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;

    }
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = "https://localhost:44362/api/Especializacion/" + Funcion;
    const especializacion = new ESPECIALIZACION($("#txtCodigo").val(), $("#txtNombre").val(), $("#txtDescripcion").val());
    await EjecutarServicio(Metodo, URL, especializacion);
    LlenarTabla();
}
async function Consultar() {
    let Codigo = $("#txtCodigo").val();
    let URL = "https://localhost:44362/api/Especializacion/ConsultarxCodigo?codigo=" + Codigo;
    const especializacion = await ConsultarServicio(URL);
    if (especializacion == null) {
        $("#dvMensaje").html("El código de la especializacion no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");

    }
    else {
        //Escribir las respuestas 
        $("#txtNombre").val(especializacion.Nombre);
        $("#txtDescripcion").val(especializacion.Descripcion);

    }
}
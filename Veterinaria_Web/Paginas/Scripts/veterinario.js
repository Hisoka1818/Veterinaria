$(function () {
    //Se ejecuta al cargar la página 
    LlenarComboXServicios("https://localhost:44362/api/especializacion/llenarCombo", "#cboEspecializacion");
    LlenarTabla();
});


function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/veterinarios/Listarveterinarios", "#tblEspecializacion");
}

class VETERINARIO {
    constructor(ID_Veterinario, Nombre, Apellido, Celular, ID_Especializacion) {
        this.ID_Veterinario = ID_Veterinario;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Celular = Celular;
        this.ID_Especializacion = ID_Especializacion;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = "https://localhost:44362/api/veterinarios/" + Funcion;
    const veterinario = new VETERINARIO($("#txtID_Veterinario").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtCelular").val(), $("#cboEspecializacion").val());
    await EjecutarServicio(Metodo, URL, veterinario);
    LlenarTabla();
}
async function Consultar() {
    let Codigo = $("#txtID_Veterinario").val();
    let URL = "https://localhost:44362/api/veterinarios/consultar?codigo=" + Codigo;
    const veterinario = await ConsultarServicio(URL);
    if (veterinario == null) {
        $("#dvMensaje").html("El código del veterinario no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtCelular").val("");
        $("#cboEspecializacion").val("");
    }
    else {
        //Escribir las respuestas 
        $("#txtNombre").val(veterinario.Nombre);
        $("#txtApellido").val(veterinario.Apellido);
        $("#txtCelular").val(veterinario.Celular);
        $("#cboEspecializacion").val(veterinario.ID_Especializacion);
        $("#dvMensaje").html("");
    }
}
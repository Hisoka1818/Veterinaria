$(function () {
    //Se ejecuta al cargar la página 
    LlenarComboXServicios("https://localhost:44362/api/consultas/Listarveterinarios", "#cboVeterinario");
    LlenarTabla();
});


function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/consultas/Listar", "#tblconsulta");
}

class CONSULTAMEDICA {
    constructor(ID_ConsultaMedica, Fecha_Cita, Estado, ID_Veterinario, ID_Mascota) {
        this.ID_ConsultaMedica = ID_ConsultaMedica;
        this.Fecha_Cita = Fecha_Cita;
        this.Estado = Estado;
        this.ID_Veterinario = ID_Veterinario;
        this.ID_Mascota = ID_Mascota;
    }
}
async function BuscarMascota() {
    let ID = $("#txtIDMascota").val();
    let URL = "https://localhost:44362/api/consultas/Buscarmascota?id=" + ID;
    const mascota = await ConsultarServicio(URL);
    if (mascota == null) {
        $("#dvMensaje").html("El codigo de la mascota no existe en la base de datos, o no tiene información completa");
        $("#txtNombre").val("");
    }
    else {
        $("#dvMensaje").html("");
        $("#txtNombre").val(mascota[0].nombre);
    }
}
async function EjecutarComando(Metodo, Funcion) {
    let URL = "https://localhost:44362/api/consultas/" + Funcion;
    const consulta = new CONSULTAMEDICA($("#txtCodigo").val(), $("#txtFecha").val(), $("#txtEstado").val(), $("#cboVeterinario").val(), $("#txtIDMascota").val());
    await EjecutarComandoServicio(Metodo, URL, consulta);
    LlenarTabla();
}
async function Consultar() {
    let Codigo = $("#txtCodigo").val();
    let URL = "https://localhost:44362/api/consultas/consulta?id=" + Codigo;
    const consulta = await ConsultarServicio(URL);
    if (consulta == null) {
        $("#dvMensaje").html("El código de la consulta no existe en la base de datos");
        $("#txtFecha").val("");
        $("#txtEstado").val("");
        $("#cboVeterinario").val("");
        $("#txtIDMascota").val("");
    }
    else {
        //Escribir las respuestas 
        $("#txtFecha").val(consulta.Fecha_Cita);
        $("#txtEstado").val(consulta.Estado);
        $("#cboVeterinario").val(consulta.ID_Veterinario);
        $("#txtIDMascota").val(consulta.ID_Mascota);
        $("#dvMensaje").html("");
    }
}
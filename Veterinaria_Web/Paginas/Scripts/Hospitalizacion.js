jQuery(function () {
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Hospitalizaciones/LlenarTabla", "#tblHospitalizacion");
}

class Hospitalizacion {
    constructor(ID_Hospitalizacion, Diagnostico, FechaIngreso, ID_Mascota) {
        this.ID_Hospitalizacion = ID_Hospitalizacion;
        this.Diagnostico = Diagnostico;
        this.FechaIngreso = FechaIngreso;
        this.ID_Mascota = ID_Mascota;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const hospitalizacion = new Hospitalizacion($("#txtHospitalizacionID").val(), $("#txtDiagnostico").val(), $("#txtFechaIngreso").val(),
        $("#txtMascotaID").val());
    let URL = "https://localhost:44362/api/Hospitalizaciones/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, hospitalizacion);
    LlenarTabla();
}

async function Consultar() {
    let ID = $('#txtHospitalizacionID').val();
    URL = "https://localhost:44362/api/Hospitalizaciones/ConsultarXID?ID=" + ID;
    const hospitalizacion = await ConsultarServicio(URL);
    if (hospitalizacion != null) {
        $("#txtHospitalizacionID").val(hospitalizacion.ID_Hospitalizacion);
        $("#txtDiagnostico").val(hospitalizacion.Diagnostico);

        let fechaIngreso = hospitalizacion.FechaIngreso;
        if (fechaIngreso != null) { $('#txtFechaIngreso').val(fechaIngreso.split('T')[0]); };
        $("#txtMascotaID").val(hospitalizacion.ID_Mascota);
    }
    else {
        $('#dvMensaje').html("La hospitalización no existe en la base de datos");
        $("#txtHospitalizacionID").val("");
        $("#txtDiagnostico").val("");
        $("#txtFechaIngreso").val("");
        $("#txtMascotaID").val("");
    }
}

async function ConsultarMascotaParaHospitalizacion() {
    let ID = $('#txtMascotaID').val();
    URL = "https://localhost:44362/api/Mascotas/ConsultarXID?ID=" + ID;
    const mascota = await ConsultarServicio(URL);
    if (mascota != null) {
        $("#txtNombreMascota").val(mascota.Nombre);
        $('#dvMensaje').html("");
    }
    else {
        $('#dvMensaje').html("La mascota no existe en la base de datos");
        $("#txtNombreMascota").val("");
    }
}
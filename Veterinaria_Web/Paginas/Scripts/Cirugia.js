jQuery(function () {
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Cirugias/LlenarTabla", "#tblCirugia");
}

class Cirugia {
    constructor(ID_Cirugia, Fecha_Cirugia, Tipo_Cirugia, Descripcion, ID_Mascota, ID_Veterinario) {
        this.ID_Cirugia = ID_Cirugia;
        this.Fecha_Cirugia = Fecha_Cirugia;
        this.Tipo_Cirugia = Tipo_Cirugia;
        this.Descripcion = Descripcion;
        this.ID_Mascota = ID_Mascota;
        this.ID_Veterinario = ID_Veterinario;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const cirugia = new Cirugia($("#txtCirugiaID").val(), $("#txtFechaCirugia").val(), $("#txtTipoCirugía").val(),
        $("#txtDescricion").val(), $("#txtMascotaID").val(), $("#txtVeterinarioID").val());
    let URL = "https://localhost:44362/api/Cirugias/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, cirugia);
    LlenarTabla();
}
async function ConsultarVeterinarioParaCirugia() {
    let ID = $('#txtVeterinarioID').val();
    URL = "https://localhost:44362/api/Veterinario/Consultar?codigo=" + ID;
    const veterinario = await ConsultarServicio(URL);
    if (veterinario != null) {
        $("#txtNombreVeterinario").val(veterinario.Nombre);
        $('#dvMensaje').html("");
    }
    else {
        $('#dvMensaje').html("El veterinario no existe en la base de datos");
        $("#txtNombreVeterinario").val("");
    }
}

async function ConsultarMascotaParaCirugia() {
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

async function Consultar() {
    let ID = $('#txtCirugiaID').val();
    URL = "https://localhost:44362/api/Cirugias/ConsultarXID?ID=" + ID;
    const cirugia = await ConsultarServicio(URL);
    if (cirugia != null) {
        $('#dvMensaje').html("");
        $("#txtVeterinarioID").val(cirugia.ID_Veterinario);
        $("#txtMascotaID").val(cirugia.ID_Mascota);
        $("#txtCirugiaID").val(cirugia.ID_Cirugia);

        let fechaCirugia = cirugia.Fecha_Cirugia;
        if (fechaCirugia != null) { $('#txtFechaCirugia').val(fechaCirugia.split('T')[0]); };
        $("#txtTipoCirugía").val(cirugia.Tipo_Cirugia);
        $("#txtDescricion").val(cirugia.Descripcion);
        await ConsultarVeterinarioParaCirugia();
        await ConsultarMascotaParaCirugia();
    }
    else {
        $('#dvMensaje').html("La cirugía no existe en la base de datos");
        $("#txtVeterinarioID").val("");
        $("#txtNombreVeterinario").val("");
        $("#txtMascotaID").val("");
        $("#txtNombreMascota").val("");
        $("#txtCirugiaID").val("");
        $("#txtFechaCirugia").val("");
        $("#txtTipoCirugía").val("");
        $("#txtDescricion").val("");
    }
}


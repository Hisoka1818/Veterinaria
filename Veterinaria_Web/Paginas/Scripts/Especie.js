jQuery(function () {
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Especies/LlenarTabla", "#tblEspecies");
}

class Especie {
    constructor(ID_Especie, Nombre, Descripcion) {
        this.ID_Especie = ID_Especie;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const especie = new Especie($("#txtIdEspecie").val(), $("#txtNombre").val(), $("#txtDescripcion").val());
    let URL = "https://localhost:44362/api/Especies/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, especie);
    LlenarTabla();
}

async function Consultar() {
    let ID = $('#txtIdEspecie').val();
    URL = "https://localhost:44362/api/Especies/ConsultarXID?ID=" + ID;
    const especie = await ConsultarServicio(URL);
    if (especie != null) {
        $("#txtNombre").val(especie.Nombre);
        $("#txtDescripcion").val(especie.Descripcion);
        $('#dvMensaje').html("");
    }
    else {
        $('#dvMensaje').html("La especie no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
    }
}
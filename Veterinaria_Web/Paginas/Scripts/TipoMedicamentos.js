jQuery(function () {
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/TipoMedicamentos/LlenarTabla", "#tbltipoMedicamentos");
}

class Tipo_Medicamento {
    constructor(ID_TipoMedicamento, Nombre, Descripcion) {
        this.ID_TipoMedicamento = ID_TipoMedicamento;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const tipoMedicamento = new Tipo_Medicamento($("#txtID_TipoMedicamento").val(), $("#txtNombre").val(), $("#txtDescripcion").val());
    let URL = "https://localhost:44362/api/TipoMedicamentos/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, tipoMedicamento);
    LlenarTabla();
}

async function Consultar() {
    let ID = $("#txtID_TipoMedicamento").val();
    let URL = "https://localhost:44362/api/TipoMedicamentos/ConsultarxCodigo?id_tipoMed=" + ID;
    const tipoMedicamento = await ConsultarServicio(URL);
    if (tipoMedicamento != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(tipoMedicamento.Nombre);
        $("#txtDescripcion").val(tipoMedicamento.Descripcion);
    }
    else {
        $("#dvMensaje").html("El tipo de medicamento no existe en la DB");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
    }
}
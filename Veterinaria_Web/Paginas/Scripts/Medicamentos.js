jQuery(function () {
    LlenarComboXServicios("https://localhost:44362/api/TipoMedicamentos/LlenarCombo", "#cboTipoMedicamentos");
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/Medicamentos/LlenarTabla", "#tblMedicamentos");
}

class Medicamento {
    constructor(ID_Medicamento, Nombre, Descripcion, Dosis, Stock, Precio, ID_TipoMedicamento) {
        this.ID_Medicamento = ID_Medicamento;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Dosis = Dosis;
        this.Stock = Stock;
        this.Precio = Precio;
        this.ID_TipoMedicamento = ID_TipoMedicamento;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const medicamento = new Medicamento($("#txtID_Medicamento").val(), $("#txtNombre").val(), $("#txtDescripcion").val(),
        $("#txtDosis").val(), $("#txtStock").val(), $("#txtPrecio").val(), $("#cboTipoMedicamentos").val());
    let URL = "https://localhost:44362/api/Medicamentos/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, medicamento);
    LlenarTabla();
}

async function Consultar() {
    let ID = $("#txtID_Medicamento").val();
    let URL = "https://localhost:44362/api/Medicamentos/ConsultarxCodigo?id_medi=" + ID;
    const medicamento = await ConsultarServicio(URL);
    if (medicamento != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(medicamento.Nombre);
        $("#txtDescripcion").val(medicamento.Descripcion);
        $("#txtDosis").val(medicamento.Dosis);
        $("#txtStock").val(medicamento.Stock);
        $("#txtPrecio").val(medicamento.Precio);
        $("#cboTipoMedicamentos").val(medicamento.ID_TipoMedicamento);
    }
    else {
        $("#dvMensaje").html("El medicamento no existe en la DB");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
        $("#txtDosis").val("");
        $("#txtStock").val("");
        $("#txtPrecio").val("");
    }
}


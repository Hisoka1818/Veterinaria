jQuery(function () {
    LlenarComboXServiciosAuth("https://localhost:44362/api/Especies/LlenarCombo", "#cboEspecieId");
    LlenarComboXServiciosAuth("https://localhost:44362/api/Propietarios/LlenarCombo", "#cboPropietarioId");
    LlenarTabla();
});

function LlenarTabla() {
    LlenarTablaXServiciosAuth("https://localhost:44362/api/Mascotas/LlenarTabla", "#tblMascota");
}

class Mascota {
    constructor(ID_Mascota, Nombre, Raza, FechaNacimiento, ID_Especie, ID_Propietario) {
        this.ID_Mascota = ID_Mascota;
        this.Nombre = Nombre;
        this.Raza = Raza;
        this.FechaNacimiento = FechaNacimiento;
        this.ID_Especie = ID_Especie;
        this.ID_Propietario = ID_Propietario;
    }
}

async function EjecutarComando(Metodo, Funcion) {
    const mascota = new Mascota($("#txtMascotaID").val(), $("#txtNombre").val(), $("#txtRaza").val(),
                                $("#txtFechaNacimiento").val(), $("#cboEspecieId").val(), $("#cboPropietarioId").val());
    let URL = "https://localhost:44362/api/Mascotas/" + Funcion;
    await EjecutarComandoServicioAuth(Metodo, URL, mascota);
    LlenarTabla();
}

async function Consultar() {
    let ID = $('#txtMascotaID').val();
    URL = "https://localhost:44362/api/Mascotas/ConsultarXID?ID=" + ID;
    const mascota = await ConsultarServicioAuth(URL);
    if (mascota != null) {
        $("#txtMascotaID").val(mascota.ID_Mascota);
        $("#txtNombre").val(mascota.Nombre);
        $("#txtRaza").val(mascota.Raza);

        let fechaNacimiento = mascota.FechaNacimiento;
        if (fechaNacimiento != null) { $('#txtFechaNacimiento').val(fechaNacimiento.split('T')[0]); };
        $("#cboEspecieId").val(mascota.ID_Especie);
        $("#cboPropietarioId").val(mascota.ID_Propietario);
        $('#dvMensaje').html("");
    }
    else {
        $('#dvMensaje').html("El Propietario no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtRaza").val("");
        $("#txtFechaNacimiento").val("");
        $("#cboEspecieId").val("");
        $("#cboPropietarioId").val("");
    }
}
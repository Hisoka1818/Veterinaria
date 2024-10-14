async function EjecutarServicio(Metodo, url, objeto) {
    try {
        const Resultado = await fetch(url,
            {
                method: Metodo,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(objeto)
            });
        const Respuesta = await Resultado.json();
        $("#dvMensaje").html(Respuesta);
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function ConsultarServicio(url) {
    try {
        const Resultado = await fetch(url,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Respuesta = await Resultado.json();
        return Respuesta;
    } catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarComboXServicios(URLServicio, ComboLlenar) {
    //Debe ir a la base de datos y llenar la información del combo de tipo producto 
    //Invocamos el servicio a través del fetch, usando el método fetch de javascript 
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo 
        $(ComboLlenar).empty();
        //Se recorre en un ciclo para llenar el select con la información 
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Codigo + '>' + Rpta[i].Nombre + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje 
        $("#dvMensaje").html(error);
    }
}


async function LlenarTablaXServicios(URLServicio, TablaLlenar) {
    //Invocamos el servicio a través del fetch, usando el método fetch de javascript 
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Rpta = await Respuesta.json();
        //Se recorre en un ciclo para llenar la tabla, con encabezados y los campos 
        //Llena el encabezado 
        var Columnas = [];
        NombreColumnas = Object.keys(Rpta[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }
        //Llena los datos 
        $(TablaLlenar).DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje 
        $("#dvMensaje").html(error);
    }
}
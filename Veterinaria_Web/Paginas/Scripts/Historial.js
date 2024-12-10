$(function () {
    //Se ejecuta al cargar la página 
  
    LlenarTabla();
});


function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44362/api/historias/Listar", "#tblhistoria");
}

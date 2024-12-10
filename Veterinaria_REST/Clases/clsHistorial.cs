using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace vet.servicio.clases
{
    public class clsHistorial
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public HISTORIA_MEDICA historia { get; set; }
        public string Insertar()
        {
            try
            {
                dbSuper.HISTORIA_MEDICA.Add(historia);
                dbSuper.SaveChanges();
                return " se inserto la historia : " + historia.ID_Historia;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public HISTORIA_MEDICA consultar(int id)
        {
            return dbSuper.HISTORIA_MEDICA.FirstOrDefault(x => x.ID_Historia == id);
        }
        public IQueryable Listar()
        {
            return from h in dbSuper.Set<HISTORIA_MEDICA>()
                   join m in dbSuper.Set<MASCOTA>()
                   on h.ID_Mascota equals m.ID_Mascota
                   select new
                   {
                       ID = h.ID_Mascota,
                       fecha = h.Fecha_Historia,
                       diagnostico = h.Diagnostico,
                       tratamiento = h.Tratamiento,
                       observacion = h.Observacion,
                       mascota = m.Nombre
                   };
        }

    }
}
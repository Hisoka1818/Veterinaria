using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsHospitalizacion
    {
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public HOSPITALIZACION hospitalizacion { get; set; }

        public IQueryable Consultar()
        {
            return from p in dbSuper.Set<HOSPITALIZACION>()
                   orderby p.Diagnostico
                   select p;
        }

        public IQueryable LlenarTabla()
        {
            return from h in dbSuper.Set<HOSPITALIZACION>()
                   orderby h.Diagnostico
                   select new
                   {
                       h.ID_Hospitalizacion,
                       h.Diagnostico,
                       h.FechaIngreso,
                       h.ID_Mascota
                   };

        }

        public string Insertar()
        {
            try
            {
                HOSPITALIZACION EntidadInsertada = dbSuper.HOSPITALIZACIONs.Add(hospitalizacion);
                dbSuper.SaveChanges();
                return $"Se grabó la hospitalización {EntidadInsertada.Diagnostico} con ID {EntidadInsertada.ID_Hospitalizacion}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public HOSPITALIZACION Consultar(int ID)
        {
            return dbSuper.HOSPITALIZACIONs.FirstOrDefault(h => h.ID_Hospitalizacion == ID);
        }

        public string Actualizar()
        {
            try
            {
                HOSPITALIZACION productoExistente = Consultar(hospitalizacion.ID_Hospitalizacion);
                if (productoExistente != null)
                {
                    dbSuper.HOSPITALIZACIONs.AddOrUpdate(hospitalizacion);
                    dbSuper.SaveChanges();
                    return $"Se actualizaron los datos de la hospitalización con ID: {hospitalizacion.ID_Hospitalizacion}";
                }
                else
                {
                    return $"La hospitalización con ID {hospitalizacion.ID_Hospitalizacion} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                HOSPITALIZACION entidadExistente = Consultar(hospitalizacion.ID_Hospitalizacion);
                if (entidadExistente != null)
                {
                    dbSuper.HOSPITALIZACIONs.Remove(entidadExistente);
                    dbSuper.SaveChanges();
                    return $"Se eliminó la hospitalización con ID: {entidadExistente.ID_Hospitalizacion}"; ;
                }
                else
                {
                    return $"La hospitalización con ID {hospitalizacion.ID_Hospitalizacion} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
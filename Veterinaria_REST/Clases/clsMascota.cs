using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsMascota
    {
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public MASCOTA mascota { get; set; }

        public IQueryable LlenarTabla()
        {
            return from m in dbSuper.Set<MASCOTA>()
                   orderby m.Nombre
                   select new
                   {
                       m.ID_Mascota,
                       m.Nombre,
                       m.Raza,
                       m.FechaNacimiento,
                       m.ID_Especie,
                       m.ID_Propietario,
                   };

        }

        public string Insertar()
        {
            try
            {
                MASCOTA mascotaInsertada = dbSuper.MASCOTAs.Add(mascota);
                dbSuper.SaveChanges();
                return $"Se grabó la mascota {mascotaInsertada.Nombre} con ID {mascotaInsertada.ID_Mascota}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public MASCOTA Consultar(int ID)
        {
            return dbSuper.MASCOTAs.FirstOrDefault(e => e.ID_Mascota == ID);
        }

        public string Actualizar()
        {
            try
            {
                MASCOTA productoExistente = Consultar(mascota.ID_Mascota);
                if (productoExistente != null)
                {
                    dbSuper.MASCOTAs.AddOrUpdate(mascota);
                    dbSuper.SaveChanges();
                    return $"Se actualizaron los datos de la mascota con ID: {mascota.ID_Mascota}";
                }
                else
                {
                    return $"La mascota con ID {mascota.ID_Mascota} no existe en la base de datos";
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
                MASCOTA mascotaExistente = Consultar(mascota.ID_Mascota);
                if (mascotaExistente != null)
                {
                    dbSuper.MASCOTAs.Remove(mascotaExistente);
                    dbSuper.SaveChanges();
                    return $"Se eliminó la mascota con ID: {mascotaExistente.ID_Mascota}"; ;
                }
                else
                {
                    return $"La mascota con ID {mascota.ID_Mascota} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
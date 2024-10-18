using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsPropietario
    {
        public VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public PROPIETARIO propietario { get; set; }

        public IQueryable LlenarCombo()
        {
            return from p in dbSuper.Set<PROPIETARIO>()
                   orderby p.Nombre
                   select new
                   {
                       Codigo =p.ID_Propietario,
                       p.Nombre,
                   };
        }

        public IQueryable LlenarTabla()
        {
            return from p in dbSuper.Set<PROPIETARIO>()
                   orderby p.Nombre
                   select new
                   {
                       p.ID_Propietario,
                       p.Nombre,
                       p.Apellido,
                       p.Direccion,
                       p.Correo,
                       p.Celular,
                   };

        }

        public string Insertar()
        {
            try
            {
                PROPIETARIO propietarioInsertado = dbSuper.PROPIETARIOs.Add(propietario);
                dbSuper.SaveChanges();
                return $"Se grabó el propietario {propietarioInsertado.Nombre} con ID {propietarioInsertado.ID_Propietario}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public PROPIETARIO Consultar(int ID)
        {
            return dbSuper.PROPIETARIOs.FirstOrDefault(e => e.ID_Propietario == ID);
        }

        public string Actualizar()
        {
            try
            {
                PROPIETARIO productoExistente = Consultar(propietario.ID_Propietario);
                if (productoExistente != null)
                {
                    dbSuper.PROPIETARIOs.AddOrUpdate(propietario);
                    dbSuper.SaveChanges();
                    return $"Se actualizaron los datos del propietario con ID: {propietario.ID_Propietario}";
                }
                else
                {
                    return $"El propietario con ID {propietario.ID_Propietario} no existe en la base de datos";
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
                PROPIETARIO propietarioExistente = Consultar(propietario.ID_Propietario);
                if (propietarioExistente != null)
                {
                    dbSuper.PROPIETARIOs.Remove(propietarioExistente);
                    dbSuper.SaveChanges();
                    return $"Se eliminó el propietario con ID: {propietarioExistente.ID_Propietario}"; ;
                }
                else
                {
                    return $"El propietario con ID {propietario.ID_Propietario} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
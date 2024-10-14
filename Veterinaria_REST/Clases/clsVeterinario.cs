using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Veterinaria_REST.Clases;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsVeterinario
    {
        public VETERINARIAPROJECTEntities DBSuper = new VETERINARIAPROJECTEntities();
        public VETERINARIO veterinario {  get; set; }

        public string Insertar() 
        {
            try
            {
                DBSuper.VETERINARIOs.Add(veterinario);
                DBSuper.SaveChanges();
                return "se inserto el veterinario: "+veterinario.Nombre;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public string Actualizar() 
        {
            try
            {
                DBSuper.VETERINARIOs.AddOrUpdate(veterinario);
                DBSuper.SaveChanges();
                return "se actualizo el veterinario: "+veterinario.Nombre;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public VETERINARIO Consultar (int codigo)
        {
            return DBSuper.VETERINARIOs.FirstOrDefault(e => e.ID_Veterinario == codigo);
        }
        public string Eliminar() 
        {
            try
            {
                VETERINARIO _veterinario = Consultar (veterinario.ID_Veterinario);

                if (_veterinario == null) 
                {
                    return "el codigo del veterinario no existe";
                }

                DBSuper.VETERINARIOs.Remove(_veterinario);
                DBSuper.SaveChanges();
                return "se elimino el veterinario " +veterinario.Nombre+" "+veterinario.Apellido;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public IQueryable Llenartablaconespecializacion() 
        {
            return from V in DBSuper.Set<VETERINARIO>()
                   join E in DBSuper.Set<ESPECIALIZACION>()
                   on V.ID_Especializacion equals E.ID_Especializacion
                   orderby V.Nombre
                   select new
                   {
                       ID_VETERINARIO = V.ID_Veterinario,
                       NOMBRE_VETERINARIO = V.Nombre + " " + V.Apellido,
                       CELULAR = V.Celular,
                       ID_ESPECIALIZACION = V.ID_Especializacion,
                       NOMBRE_ESPECIALIZACION = E.Nombre,
                       DESCRIPCION_ESPECIALIZACION = E.Descripcion
                   };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Clases
{
    public class clsPerfil
    {
        private VETERINARIAPROJECTEntities dbSuper = new VETERINARIAPROJECTEntities();
        public PERFIL perfil { get; set; }
        public IQueryable LlenarCombo()
        {
            return from P in dbSuper.Set<PERFIL>()
                   orderby P.Nombre
                   select new
                   {
                       Codigo = P.ID_Perfil,
                       Nombre = P.Nombre
                   };
        }
    }
}
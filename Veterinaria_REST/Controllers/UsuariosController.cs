using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Veterinaria_REST.Clases;
using Veterinaria_REST.Models;

namespace Veterinaria_REST.Controllers
{
    [EnableCors(origins: "https://localhost:44322", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpGet]
        [Route("ListarUsuarios")]
        public IQueryable ListarUsuarios()
        {
            clsUsuario usuario = new clsUsuario();
            return usuario.ListarUsuarios();
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] USUARIO usuario, int Perfil)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usuario;
            return Usuario.Insertar(Perfil);
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] USUARIO usuario, int Perfil)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usuario;
            return Usuario.Actualizar(Perfil);
        }
        [HttpPut]
        [Route("Activar")]
        public string Activar(int idUsuarioPerfil, bool Activo)
        {
            clsUsuario Usuario = new clsUsuario();
            return Usuario.Activar(idUsuarioPerfil, Activo);
        }

    }
}
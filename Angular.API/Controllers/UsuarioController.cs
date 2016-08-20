using Angular.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Angular.API.Controllers
{
    public class UsuarioController : Controller
    {
        //Esto debería venir desde el servidor.
        private static List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Usuario { Id=1, Apellido="Lopez", Nombre="Juan", NombreDeUsuario="jlopez", FechaNacimiento=new DateTime(1980, 3,25) },
            new Usuario { Id=2, Apellido="Perez", Nombre="Carlos", NombreDeUsuario="cperez", FechaNacimiento=new DateTime(1980, 3,25) },
            new Usuario { Id=3, Apellido="Gutierrez", Nombre="Camila", NombreDeUsuario="cgutierrez" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=4, Apellido="Damilo", Nombre="Lucia", NombreDeUsuario="ldamilo" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=5, Apellido="Vallejos", Nombre="Diego", NombreDeUsuario="dvallejos" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=6, Apellido="Guerra", Nombre="Fernando", NombreDeUsuario="fguerra" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=7, Apellido="Hernandez", Nombre="Romina", NombreDeUsuario="rhernandez" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=8, Apellido="Castro", Nombre="Matias", NombreDeUsuario="mcastro" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=9, Apellido="Del Potro", Nombre="Ignacio", NombreDeUsuario="idelpo" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=10, Apellido="Messi", Nombre="Gabriel", NombreDeUsuario="gmessi", FechaNacimiento=new DateTime(1980, 3,25) },
            new Usuario { Id=11, Apellido="Phelps", Nombre="Rodrigo", NombreDeUsuario="rphelps" , FechaNacimiento=new DateTime(1980, 3,25)},
            new Usuario { Id=12, Apellido="Tomada", Nombre="Franco", NombreDeUsuario="ftomada" , FechaNacimiento=new DateTime(1980, 3,25)},
        };

        [System.Web.Http.HttpGet]
        public ActionResult Get(int id)
        {
            try
            {
                Usuario usuario = listaUsuarios.FirstOrDefault(x => x.Id == id);

                return new JsonResult { Data = usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(resp);
            }
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetAll(string orderby)
        {
            try
            {
                bool asc = orderby.StartsWith("+") ? true : false;
                orderby = orderby.Substring(1, orderby.Length - 1);
                List<Usuario> listaOrdenada = new List<Usuario>();

                switch (orderby)
                {
                    case "Id":
                        if (asc)
                            listaOrdenada = listaUsuarios.OrderBy(x => x.Id).ToList();
                        else
                            listaOrdenada = listaUsuarios.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "NombreDeUsuario":
                        if (asc)
                            listaOrdenada = listaUsuarios.OrderBy(x => x.NombreDeUsuario).ToList();
                        else
                            listaOrdenada = listaUsuarios.OrderByDescending(x => x.NombreDeUsuario).ToList();
                        break;
                    case "Nombre":
                        if (asc)
                            listaOrdenada = listaUsuarios.OrderBy(x => x.Nombre).ToList();
                        else
                            listaOrdenada = listaUsuarios.OrderByDescending(x => x.Nombre).ToList();
                        break;
                    case "Apellido":
                        if (asc)
                            listaOrdenada = listaUsuarios.OrderBy(x => x.Apellido).ToList();
                        else
                            listaOrdenada = listaUsuarios.OrderByDescending(x => x.Apellido).ToList();
                        break;
                    default:
                        listaOrdenada = listaUsuarios.OrderBy(x => x.Id).ToList();
                        break;
                }

                return new JsonResult { Data = listaOrdenada, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(resp);
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult Add([FromBody] Usuario usuario)
        {
            try
            {
                //Obtengo el máximo id:
                int id = listaUsuarios.Max(x => x.Id);
                usuario.Id = id + 1;

                //Lo agrego a la base de datos:
                listaUsuarios.Add(usuario);

                return new JsonResult { Data = usuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(resp);
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult Edit([FromBody] Usuario usuario)
        {
            try
            {
                //Obtengo el máximo id:
                Usuario usuarioDB = listaUsuarios.FirstOrDefault(x => x.Id == usuario.Id);
                listaUsuarios.Remove(usuarioDB);

                usuarioDB.Apellido = usuario.Apellido;
                usuarioDB.Nombre = usuario.Nombre;
                usuarioDB.NombreDeUsuario = usuario.NombreDeUsuario;

                listaUsuarios.Add(usuarioDB);

                return new JsonResult { Data = usuarioDB, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(resp);
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult Remove(Int32 usuarioId)
        {
            try
            {
                //Obtengo el máximo id:
                Usuario usuarioDB = listaUsuarios.FirstOrDefault(x => x.Id == usuarioId);
                listaUsuarios.Remove(usuarioDB);


                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}

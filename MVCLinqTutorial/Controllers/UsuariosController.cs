using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//IMPORTAMOS LA CARPETA Models
using MVCLinqTutorial.Models;

namespace MVCLinqTutorial.Controllers
{
    public class UsuariosController : Controller
    {
        //CREAMOS LA VARIABLE ModeloUsuarios
        ModeloUsuarios modelo;

        public UsuariosController()
        {
            //INICIALIZAMOS LA VARIABLE COMO OBJETO
            modelo = new ModeloUsuarios();
        }

        // GET: Lista
        public ActionResult Lista()
        {
            //LLAMAMOS AL MÉTODO GetUsuarios() Y LO ALMACENAMOS EN LA VARIABLE listausu
            List<USUARIOS> listausu = modelo.GetUsuarios();

            return View(listausu);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(String NOMBRE, String APELLIDO)
        {
            modelo.InsertarUsuario(NOMBRE, APELLIDO);

            return RedirectToAction("Lista");
        }

        //GET: Delete
        public ActionResult Delete(int ID)
        {
            modelo.EliminarUsuario(ID);

            return RedirectToAction("Lista");
        }

        //GET: Edit
        public ActionResult Edit(int ID)
        {
            USUARIOS usuario = modelo.DetallesUsuario(ID);

            return View(usuario);
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(int ID, String NOMBRE, String APELLIDO)
        {
            modelo.EditarUsuario(ID, NOMBRE, APELLIDO);

            return RedirectToAction("Lista");
        }

        //GET: Details
        public ActionResult Details(int ID)
        {
            USUARIOS usuario = modelo.DetallesUsuario(ID);

            return View(usuario);
        }
    }
}
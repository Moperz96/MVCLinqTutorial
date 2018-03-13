using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLinqTutorial.Models
{
    public class ModeloUsuarios
    {
        //CREAMOS LA VARIABLE ContextoLINQTutorial
        ContextoLINQTutorial contexto;

        public ModeloUsuarios()
        {
            //INICIALIZAMOS LA VARIABLE COMO OBJETO
            contexto = new ContextoLINQTutorial();
        }

        //MÉTODO PARA RECOGER LOS USUARIOS
        public List<USUARIOS> GetUsuarios()
        {
            //ALMACENAMOS LOS DATOS RECOGIDOS MEDIANTE LA CONSULTA EN LA VARIABLE listausu
            var listausu = (from datos in contexto.USUARIOS
                           select datos).ToList();

            //DEVOLVEMOS LOS DATOS DE LA CONSULTA PARA POSTERIORMENTE SER USADA EN UsuariosController
            return listausu;
        }

        //MÉTODO PARA INSERTAR USUARIOS
        public void InsertarUsuario(String nombre, String apellido)
        {
            //CREAMOS EL OBJETO usuario
            USUARIOS usuario = new USUARIOS();

            //DAMOS VALORES A SUS COLUMNAS
            usuario.ID = (from datos in contexto.USUARIOS
                          select datos.ID).Max() + 1;
            usuario.NOMBRE = nombre;
            usuario.APELLIDO = apellido;

            //AÑADIMOS EL USUARIO AL CONTEXTO
            contexto.USUARIOS.Add(usuario);

            //GUARDAMOS LOS CAMBIOS
            contexto.SaveChanges();
        }

        //MÉTODO PARA ELIMINAR USUARIOS
        public void EliminarUsuario(int id)
        {
            //BUSCAMOS EL USUARIO QUE QUEREMOS BORRAR
            var usuario = (from datos in contexto.USUARIOS
                           where datos.ID == id
                           select datos).FirstOrDefault();

            //ELIMINAMOS AL USAURIO DEL CONTEXTO
            contexto.USUARIOS.Remove(usuario);

            //GUARDAMOS LOS CAMBIOS
            contexto.SaveChanges();
        }

        //MÉTODO PARA EDITAR USUARIOS
        public void EditarUsuario(int id, String nombre, String apellido)
        {
            //BUSCAMOS EL USUARIO QUE QUEREMOS EDITAR
            USUARIOS usuario = this.DetallesUsuario(id);

            //ACTUALIZAMOS LOS DATOS ACTUALES POR LOS PARÁMETROS RECIBIDOS
            usuario.NOMBRE = nombre;
            usuario.APELLIDO = apellido;

            //GUARDAMOS LOS CAMBIOS
            contexto.SaveChanges();
        }

        //MÉTODO PARA VER DETALLES DE USUARIOS
        public USUARIOS DetallesUsuario(int id)
        {
            //BUSCAMOS EL USUARIO DEL QUE QUEREMOS VER LOS DETALLES
            var usuario = (from datos in contexto.USUARIOS
                           where datos.ID == id
                           select datos).FirstOrDefault();

            //DEVOLVEMOS EL USUARIO
            return usuario;

            //return contexto.USUARIOS.Find(id);
        }
    }
}
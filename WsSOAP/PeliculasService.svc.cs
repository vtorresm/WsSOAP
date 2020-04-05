using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WsSOAP.Domain;
using WsSOAP.Exception;
using WsSOAP.Persintence;

namespace WsSOAP
{

    public class PeliculasService : IPeliculasService
    {
        private PeliculaDAO peliculaDAO = new PeliculaDAO();

        public Pelicula CrearPelicula(Pelicula peliculaACrear)
        {
            if (peliculaDAO.Obtener(peliculaACrear.idPelicula) != null)
            {
                throw new FaultException<PeliculaException>(
                    new PeliculaException()
                    {
                        Codigo = "101",
                        Descripcion = "El pelicula ya existe"
                    },
                    new FaultReason("Error al intentar crear pelicula")
                );
            }

            return peliculaDAO.Crear(peliculaACrear);
        }

        public Pelicula ObtenerPelicula(int idPelicula)
        {
            if (peliculaDAO.Obtener(idPelicula) == null)
            {
                throw new FaultException<PeliculaException>(
                     new PeliculaException()
                     {
                         Codigo = "102",
                         Descripcion = "La pelicula no existe"
                     },
                     new FaultReason("Error al intentar obtener pelicula")
                );
            }
            return peliculaDAO.Obtener(idPelicula);
        }


        public Pelicula ModificarPelicula(Pelicula peliculaAModificar)
        {
            if (peliculaAModificar.estado == "I")
            {
                throw new FaultException<PeliculaException>(
                    new PeliculaException()
                    {
                        Codigo = "103",
                        Descripcion = "No se puede modificar pelicula con estado Inactivo"
                    }, new FaultReason("Error al intentar modificar pelicula")
               );
            }
            return peliculaDAO.Modificar(peliculaAModificar);
        }

        public void EliminarPelicula(int id) { peliculaDAO.Eliminar(id); }

        public List<Pelicula> ListaPeliculas() { return peliculaDAO.Listar(); }

    }
}

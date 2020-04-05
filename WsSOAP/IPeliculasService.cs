using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WsSOAP.Domain;
using WsSOAP.Exception;

namespace WsSOAP
{
    
    [ServiceContract]
    public interface IPeliculasService
    {
        [FaultContract(typeof(PeliculaException))]
        [OperationContract]
        Pelicula CrearPelicula(Pelicula peliculaACrear);

        [OperationContract]
        Pelicula ObtenerPelicula(int idPelicula);

        [OperationContract]
        Pelicula ModificarPelicula(Pelicula peliculaAModificar);

        [OperationContract]
        void EliminarPelicula(int idPelicula);

        [OperationContract]
        List<Pelicula> ListaPeliculas();
    }
}

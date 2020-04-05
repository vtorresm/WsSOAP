using System.Runtime.Serialization;

namespace WsSOAP.Exception
{
    [DataContract]
    public class PeliculaException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
using System.Runtime.Serialization;

namespace WsSOAP.Domain
{
    [DataContract]
    public class Pelicula
    {
        [DataMember]
        public int idPelicula { get; set; }
        [DataMember]
        public string titulo { get; set; }
        [DataMember]
        public string duracion { get; set; }
        [DataMember]
        public string genero { get; set; }
        [DataMember]
        public string clasificacion { get; set; }
        [DataMember]
        public string formato { get; set; }
        [DataMember(IsRequired = false)]
        public string estado { get; set; } 
    }
}
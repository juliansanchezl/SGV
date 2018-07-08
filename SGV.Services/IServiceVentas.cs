using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SGV.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceVentas
    {

        [OperationContract]
        List<Ciudad> GetDataCiudadesAll();


        [OperationContract]
        Persona CreatePersona(Persona persona);

        [OperationContract]
        Persona UpdatePersona(Persona persona);

        [OperationContract]
        bool DeletePersona(int id);

        [OperationContract]
        List<Persona> GetDataPersonasAll();

        [OperationContract]
        Persona GetDataPersona(int id);
    }

    [DataContract]
    public class Ciudad
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public Nullable<int> departamentoid { get; set; }
        [DataMember]
        public string departamentonombre { get; set; }
    }

    [DataContract]
    public partial class Persona
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nombres { get; set; }
        [DataMember]
        public string apellidos { get; set; }
        [DataMember]
        public System.DateTime fechanacimiento { get; set; }
        [DataMember]
        public Nullable<int> ciudadid { get; set; }
        [DataMember]
        public string ciudadnombre { get; set; }
    }

}

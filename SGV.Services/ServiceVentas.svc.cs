using SGV.DAL;
using SGV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SGV.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceVentas : IServiceVentas
    {
        public Persona CreatePersona(Persona persona)
        {
            IRepository<SGV.Models.Persona> repository = new Repository<SGV.Models.Persona>();
            var restultado = repository.Create(TranslatePersonaEntityToEntityTable(persona));
            repository.SaveChanges();
            persona.id = restultado.id;
            return persona;
        }

        public Persona UpdatePersona(Persona persona)
        {
            IRepository<SGV.Models.Persona> repository = new Repository<SGV.Models.Persona>();
            var restultado = repository.Update(TranslatePersonaEntityToEntityTable(persona));
            repository.SaveChanges();
            persona.id = restultado.id;
            return persona;
        }

        public bool DeletePersona(int id)
        {
            IRepository<SGV.Models.Persona> repository = new Repository<SGV.Models.Persona>();
            repository.Delete(id);
            repository.SaveChanges();
            return true;
        }
        
        public List<Persona> GetDataPersonasAll()
        {
            List<Persona> lista = new List<Persona>();
            IRepository<SGV.Models.Persona> repository = new Repository<SGV.Models.Persona>();
            var res = repository.FindAll();
            foreach (var item in res)
            {
                lista.Add(TranslatePersonaTableToPersonaEntity(item));
            }
            return lista;
        }

        public Persona GetDataPersona(int id)
        {
            Persona persona = new Persona();
            IRepository<SGV.Models.Persona> repository = new Repository<SGV.Models.Persona>();
            var res = repository.Find(id);
            
            persona = TranslatePersonaTableToPersonaEntity(res);
            
            return persona;
        }

        public List<Ciudad> GetDataCiudadesAll()
        {
            List<Ciudad> lista = new List<Ciudad>();
            IRepository<SGV.Models.Ciudad> repository = new Repository<SGV.Models.Ciudad>();
            var res = repository.FindAll();
            foreach (var item in res)
            {
                lista.Add(TranslateCiudadTableToCiudadEntity(item));
            }
            return lista;
        }        

        private Models.Persona TranslatePersonaEntityToEntityTable(Persona item)
        {
            return new Models.Persona()
            {
                id = item.id,
                nombres = item.nombres,
                apellidos = item.apellidos,
                ciudadid = item.ciudadid,
                fechanacimiento = item.fechanacimiento
            };
        }

        private Persona TranslatePersonaTableToPersonaEntity(Models.Persona item)
        {
            return new Persona()
            {
                id = item.id,                
                nombres = item.nombres,
                apellidos = item.apellidos,
                ciudadid = item.ciudadid,
                ciudadnombre = item.Ciudad.nombre,
                fechanacimiento = item.fechanacimiento
            };
        }

        private Ciudad TranslateCiudadTableToCiudadEntity(SGV.Models.Ciudad item)
        {
            return new Ciudad()
            {
                id = item.id,
                departamentoid = item.departamentoid,
                departamentonombre = item.Departamento.nombre,
                nombre = item.nombre
            };
        }
    }
}

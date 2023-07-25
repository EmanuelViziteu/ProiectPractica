using WebApiPractica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.UI.WebControls.WebParts;
using System.Web.Http.Description;

namespace WebApiPractica.Controllers
{
    /// <summary>
    /// Aici gasiti toate informatiile despre persoanele din lista
    /// </summary>
    public class PersoanaController : ApiController
    {

        // Lista de persoane
        private static List<Persoana> Persoane = new List<Persoana>();


        /// <summary>
        /// Metoda GET pentru a obtine toate persoanele din lista
        /// </summary>
        /// <returns>Lista completa a persoanelor</returns>
        // GET: api/Persoana
        [HttpGet]
        [Route("api/Persoane")]
        public List<Persoana> GetPersoana()
        {
            return Persoane;
        }


        /// <summary>
        /// Metoda POST pentru inserarea unei persoane noi in lista
        /// </summary>
        /// <param name="persoanaRequest">Tastati valorile pe care doriti sa le introduceti</param>
        // POST: api/Persoana/Inserare 
        [HttpPost]
        [Route("api/Persoana/Inserare")]
        public void PostPersoana([FromBody] PersoanaRequest persoanaRequest)
        {
            var persoana = new Persoana
            {
                Id = GetNextId(), // Atribuim valoarea ID-ului prin metoda GetNextId()
                Nume = persoanaRequest.Nume,
                Prenume = persoanaRequest.Prenume,
                Adresa = persoanaRequest.Adresa,
                Email = persoanaRequest.Email
            };

            Persoane.Add(persoana);

            // Actualizam NextId pentru a evita conflictele de ID-uri
            Persoana.UpdateNextId(Persoane);
        }


        /// <summary>
        /// Metoda PUT pentru modificarea unei persoane deja existente in lista
        /// </summary>
        /// <param name="id">ID-ul persoanei la care doriti sa faceti modificari</param>
        /// <param name="persoanaRequest">Tastati valorile pe care doriti sa le modificati</param>
        // PUT: api/Persoana/Modificare 
        [HttpPut]
        [Route("api/Persoana/Modificare")]
        public void PutPersoana(int id, [FromBody] PersoanaRequest persoanaRequest)
        {
            // Cautam persoana cu ID-ul specificat
            var existingPersoana = Persoane.FirstOrDefault(x => x.Id == id);

            // Daca persoana cu ID-ul specificat exista, modificam valorile vechi cu cele noi
            existingPersoana.Nume = persoanaRequest.Nume;
            existingPersoana.Prenume = persoanaRequest.Prenume;
            existingPersoana.Adresa = persoanaRequest.Adresa;
            existingPersoana.Email = persoanaRequest.Email;
        }


        /// <summary>
        /// Metoda DELETE pentru a sterge persoane din lista
        /// </summary>
        /// <param name="id">ID-ul persoanei pe care doriti sa o stergeti din lista</param>
        // DELETE: api/Persoana/Stergere 
        [HttpDelete]
        [Route("api/Persoana/Stergere")]
        public void DeletePersoana(int id)
        {
            var persoanaToDelete = Persoane.FirstOrDefault(x => x.Id == id);

            if (persoanaToDelete != null)
            {
                Persoane.Remove(persoanaToDelete);

                // Actualizam ID-ul pentru persoanele care au ID-ul mai mare decât cel al persoanei șterse
                foreach (var persoana in Persoane)
                {
                    if (persoana.Id > id)
                    {
                        persoana.Id--;
                    }
                }

                // Actualizam NextId pentru a evita conflictele de ID-uri
                Persoana.UpdateNextId(Persoane);
            }
        }

        private int GetNextId()
        {
            return Persoane.Count + 1;
        }

    }
}

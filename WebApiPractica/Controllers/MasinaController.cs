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
    /// Aici gasiti toate informatiile despre masinile din lista
    /// </summary>
    public class MasinaController : ApiController
    {
        // Lista de masini
        private static List<Masina> Masini = new List<Masina>();

        /// <summary>
        /// Metoda GET pentru a obtine toate masinile din lista
        /// </summary>
        /// <returns>Lista completa a masinilor</returns>
        // GET: api/Masina
        [HttpGet]
        [Route("api/Masini")]
        public List<Masina> GetMasina()
        {
            return Masini;
        }

        /// <summary>
        /// Metoda POST pentru inserarea unei masini noi in lista
        /// </summary>
        /// <param name="masinaRequest">Tastati valorile pe care doriti sa le introduceti</param>
        // POST: api/Masina/Inserare 
        [HttpPost]
        [Route("api/Masina/Inserare")]
        public void PostMasina([FromBody] MasinaRequest masinaRequest)
        {
            var masina = new Masina
            {
                Marca = masinaRequest.Marca,
                Model = masinaRequest.Model,
                An = masinaRequest.An,
                Motor = masinaRequest.Motor
            };

            Masini.Add(masina);

            // Actualizam NextId pentru a evita conflictele de ID-uri
            Masina.UpdateNextId(Masini);
        }

        /// <summary>
        /// Metoda PUT pentru modificarea unei masini deja existente in lista
        /// </summary>
        /// <param name="id">ID-ul masinii la care doriti sa faceti modificari</param>
        /// <param name="masinaRequest">Tastati valorile pe care doriti sa le modificati</param>
        // PUT: api/Masina/Modificare 
        [HttpPut]
        [Route("api/Masina/Modificare")]
        public void PutMasina(int id, [FromBody] MasinaRequest masinaRequest)
        {
            // Cautam masina cu ID-ul specificat
            var existingMasina = Masini.FirstOrDefault(x => x.Id == id);

            // Daca masina cu ID-ul specificat exista, modificam valorile vechi cu cele noi
            if (existingMasina != null)
            {
                existingMasina.Marca = masinaRequest.Marca;
                existingMasina.Model = masinaRequest.Model;
                existingMasina.An = masinaRequest.An;
                existingMasina.Motor = masinaRequest.Motor;
            }
        }

        /// <summary>
        /// Metoda DELETE pentru a sterge masini din lista
        /// </summary>
        /// <param name="id">ID-ul masinii pe care doriti sa o stergeti din lista</param>
        // DELETE: api/Masina/Stergere 
        [HttpDelete]
        [Route("api/Masina/Stergere")]
        public void DeleteMasina(int id)
        {
            var masinaToDelete = Masini.FirstOrDefault(x => x.Id == id);

            if (masinaToDelete != null)
            {
                Masini.Remove(masinaToDelete);

                // Actualizam ID-ul pentru masinile care au ID-ul mai mare decât cel al masinii șterse
                foreach (var masina in Masini)
                {
                    if (masina.Id > id)
                    {
                        masina.Id--;
                    }
                }

                // Actualizam NextId pentru a evita conflictele de ID-uri
                Masina.UpdateNextId(Masini);
            }
        }

        private int GetNextId()
        {
            return Masini.Count + 1;
        }
    }
}

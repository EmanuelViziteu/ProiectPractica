using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.UI.WebControls.WebParts;
using System.Web.Http.Description;
using WebApiPractica.Models;

namespace WebApiPractica.Controllers
{
    /// <summary>
    /// Aici gasiti toate informatiile despre produsele din lista
    /// </summary>
    public class ProdusController : ApiController
    {

        // Lista de produse
        private static List<Produs> Produse = new List<Produs>();


        /// <summary>
        /// Metoda GET pentru a obtine toate produsele din lista
        /// </summary>
        /// <returns>Lista completa a produselor</returns>
        // GET: api/Produs
        [HttpGet]
        [Route("api/Produse")]
        public List<Produs> GetProdus()
        {
            return Produse;
        }


        /// <summary>
        /// Metoda POST pentru inserarea unui produs nou in lista
        /// </summary>
        /// <param name="produsRequest">Tastati valorile pe care doriti sa le introduceti</param>
        // POST: api/Produs/Inserare 
        [HttpPost]
        [Route("api/Produs/Inserare")]
        public void PostProdus([FromBody] ProdusRequest produsRequest)
        {
            var produs = new Produs
            {
                Denumire = produsRequest.Denumire,
                Stoc = produsRequest.Stoc,
                Pret = produsRequest.Pret
            };

            Produse.Add(produs);

            // Actualizam NextId pentru a evita conflictele de ID-uri
            Produs.UpdateNextId(Produse);
        }


        /// <summary>
        /// Metoda PUT pentru modificarea unui produs deja existent in lista
        /// </summary>
        /// <param name="id">ID-ul produsului la care doriti sa faceti modificari</param>
        /// <param name="produsRequest">Tastati valorile pe care doriti sa le modificati</param>
        // PUT: api/Produs/Modificare 
        [HttpPut]
        [Route("api/Produs/Modificare")]
        public void PutProdus(int id, [FromBody] ProdusRequest produsRequest)
        {
            // Cautam produsul cu ID-ul specificat
            var existingProdus = Produse.FirstOrDefault(x => x.Id == id);

            // Daca produsul cu ID-ul specificat exista, modificam valorile vechi cu cele noi
            if (existingProdus != null)
            {
                existingProdus.Denumire = produsRequest.Denumire;
                existingProdus.Stoc = produsRequest.Stoc;
                existingProdus.Pret = produsRequest.Pret;
            }
        }


        /// <summary>
        /// Metoda DELETE pentru a sterge un produs din lista
        /// </summary>
        /// <param name="id">ID-ul produsului pe care doriti sa-l stergeti din lista</param>
        // DELETE: api/Produs/Stergere 
        [HttpDelete]
        [Route("api/Produs/Stergere")]
        public void DeleteProdus(int id)
        {
            var produsToDelete = Produse.FirstOrDefault(x => x.Id == id);

            if (produsToDelete != null)
            {
                Produse.Remove(produsToDelete);

                // Actualizam NextId pentru a evita conflictele de ID-uri
                Produs.UpdateNextId(Produse);
            }
        }

        private int GetNextId()
        {
            return Produse.Count + 1;
        }

    }
}

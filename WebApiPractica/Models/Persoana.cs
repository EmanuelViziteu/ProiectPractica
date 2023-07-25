using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{

    /// <summary>
    /// Toate datele unei persoane din lista
    /// </summary>
    public class Persoana
    {

        private static int NextId = 1;


        /// <summary>
        /// ID-ul din lista a persoanei
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Numele persoanei
        /// </summary>
        public string Nume { get; set; }
        /// <summary>
        /// Prenumele persoanei
        /// </summary>
        public string Prenume { get; set; }
        /// <summary>
        /// Adresa persoanei
        /// </summary>
        public string Adresa { get; set; }
        /// <summary>
        /// Email-ul persoanei
        /// </summary>
        public string Email { get; set; }


        public Persoana()
        {
            Id = NextId;
            NextId++;
        }


        // Metoda de actualizare a Id-ului
        public static void UpdateNextId(List<Persoana> persoane)
        {
            if (persoane.Count > 0)
            {
                // Gasim cel mai mare Id
                int maxId = persoane.Max(p => p.Id);

                // Actualizam NextId cu valoarea urmatoare
                NextId = maxId + 1;
            }
            else
            {
                // Daca lista este goală,NextId primeste 1
                NextId = 1;
            }
        }


    }
}

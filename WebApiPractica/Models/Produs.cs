using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{
    /// <summary>
    /// Toate datele unui produs din lista
    /// </summary>
    public class Produs
    {
        private static int NextId = 1;

        /// <summary>
        /// ID-ul din lista a produsului
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Denumirea produsului
        /// </summary>
        public string Denumire { get; set; }
        /// <summary>
        /// Cantitatea de stoc a produsului
        /// </summary>
        public int Stoc { get; set; }
        /// <summary>
        /// Pretul produsului
        /// </summary>
        public double Pret { get; set; }

        public Produs()
        {
            Id = NextId;
            NextId++;
        }

        // Metoda de actualizare a Id-ului
        public static void UpdateNextId(List<Produs> produse)
        {
            if (produse.Count > 0)
            {
                // Gasim cel mai mare Id
                int maxId = produse.Max(p => p.Id);

                // Actualizam NextId cu valoarea urmatoare
                NextId = maxId + 1;
            }
            else
            {
                // Daca lista este goală, NextId primeste 1
                NextId = 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{

    /// <summary>
    /// Toate datele unei masini din lista
    /// </summary>
    public class Masina
    {

        private static int NextId = 1;


        /// <summary>
        /// ID-ul din lista a masinii
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Marca masinii
        /// </summary>
        public string Marca { get; set; }
        /// <summary>
        /// Modelul masinii
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Anul fabricatiei masinii
        /// </summary>
        public int An { get; set; }
        /// <summary>
        /// Motorul masinii (capacitatea in centimetri cubi)
        /// </summary>
        public int Motor { get; set; }


        public Masina()
        {
            Id = NextId;
            NextId++;
        }


        // Metoda de actualizare a Id-ului
        public static void UpdateNextId(List<Masina> masini)
        {
            if (masini.Count > 0)
            {
                // Gasim cel mai mare Id
                int maxId = masini.Max(m => m.Id);

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

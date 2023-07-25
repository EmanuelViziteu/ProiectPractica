using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{
    /// <summary>
    /// Datele de introducere/modificare pentru un produs
    /// </summary>
    public class ProdusRequest
    {
        /// <summary>
        /// Denumirea produsului
        /// </summary>
        public string Denumire { get; set; }

        /// <summary>
        /// Stocul disponibil pentru produs
        /// </summary>
        public int Stoc { get; set; }

        /// <summary>
        /// Pretul produsului
        /// </summary>
        public double Pret { get; set; }
    }
}

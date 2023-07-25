using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{
    /// <summary>
    /// Datele de introducere/modificare
    /// </summary>
    public class PersoanaRequest
    {
        /// <summary>
        /// Numele persoanei care trebuie introdusa/stearsa
        /// </summary>
        public string Nume { get; set; }
        /// <summary>
        /// Prenumele persoanei care trebuie introdusa/stearsa
        /// </summary>
        public string Prenume { get; set; }
        /// <summary>
        /// Adresa persoanei care trebuie introdusa/stearsa
        /// </summary>
        public string Adresa { get; set; }
        /// <summary>
        /// Email-ul persoanei care trebuie introdusa/stearsa
        /// </summary>
        public string Email { get; set; }
    }
}

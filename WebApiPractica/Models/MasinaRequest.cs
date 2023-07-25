using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPractica.Models
{
    /// <summary>
    /// Datele de introducere/modificare pentru Masina
    /// </summary>
    public class MasinaRequest
    {
        /// <summary>
        /// Marca masinii care trebuie introdusa/modificata
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Modelul masinii care trebuie introdus/modificat
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Anul masinii care trebuie introdus/modificat
        /// </summary>
        public int An { get; set; }

        /// <summary>
        /// Capacitatea motorului masinii care trebuie introdusa/modificata
        /// </summary>
        public int Motor { get; set; }
    }
}

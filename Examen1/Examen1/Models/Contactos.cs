using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Examen1.Models
{
    public class Contactos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        public int Telefono { get; set; }

        public int Edad { get; set; }

        public string Pais { get; set; }

        [MaxLength(50)]
        public string Nota { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }
    }
}

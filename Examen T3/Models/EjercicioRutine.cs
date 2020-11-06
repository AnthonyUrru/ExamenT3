using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models
{
    public class EjercicioRutine
    {
        public int Id { get; set; }
        public int RutineId { get; set; }
        public int EjercicioId { get; set; }
        public int tiempo { get; set; }
        public int Usserid { get; set; }
        public Ejercicio ejercicio { get; set; }
        public Rutine rutine { get; set; }
    }
}

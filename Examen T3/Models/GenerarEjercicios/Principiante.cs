using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.GenerarEjercicios
{

    public class Principiante : InterfaceGenerar
    {
        public int rnd;
        public int generar()
        {
            
           
                Random random = new Random();
                rnd = random.Next(1, 5);
            
            
            return rnd;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _olc1_proyecto1
{
    class Fila
    {
        public String nombre;
        public List<String> columnas;

        public Fila(String n, List<String> c)
        {
            this.nombre = n;
            this.columnas = c;
        }
    }
}

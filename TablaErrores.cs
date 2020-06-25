using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _olc1_proyecto1
{
    class TablaErrores
    {

        LinkedList<Token> lista_error = new LinkedList<Token>();
        private static TablaErrores instancia = null;

        public static TablaErrores getInstancia()
        {
            if (instancia == null)
            {
                instancia = new TablaErrores();
            }
            return instancia;
        }

        public void insertar_lista_error(String tk_tipo, String tk_cadena, int fila, int columna)
        {

            lista_error.AddLast(new Token(tk_tipo, tk_cadena, fila, columna));
        }

        public void Imprimir_errores()
        {

            foreach (Token tkn in lista_error)
            {
                Console.WriteLine(tkn.getTipo() + ", " + tkn.getToken());
            }
        }

        public void Limpiar_errores()
        {
            lista_error.Clear();
        }

    }
}

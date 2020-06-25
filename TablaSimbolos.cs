using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _olc1_proyecto1
{
    class TablaSimbolos
    {
        LinkedList<Token> lista_token = new LinkedList<Token>();
        private static TablaSimbolos instancia=null;

        public static TablaSimbolos getInstancia()
        {
            if (instancia == null)
            {
                instancia = new TablaSimbolos();
            }
                return instancia;
        }

        public void insertar_lista(String tk_tipo, String tk_cadena, int fila, int columna)
        {

            lista_token.AddLast(new Token(tk_tipo,tk_cadena,fila,columna));

        }

        public void Imprimir()
        {
            foreach(Token item in lista_token)
            {
                Console.WriteLine(item.getTipo() + ", " + item.getToken());
            }
            
        }

        public void vaciar_lista_token()
        {
            lista_token.Clear();
        }

        public LinkedList<Token> get_simbolo()
        {
            return lista_token;
        }
    }
}

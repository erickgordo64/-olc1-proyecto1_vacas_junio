using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _olc1_proyecto1
{
    class TablaSimbolos
    {
        LinkedList<Token> lista_token = new LinkedList<Token>();
        private static TablaSimbolos instancia=null;
        string nombre_archivo, direccion;

        internal Token Token
        {
            get => default;
            set
            {
            }
        }

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
            

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "archivo html|*.html";
            guardar.Title = "reporte tablas html";
            guardar.FileName = nombre_archivo + ".html";
            var resultado = guardar.ShowDialog();
            int columnas = 0;

            if (resultado == DialogResult.OK)
            {
                nombre_archivo = Path.GetFileNameWithoutExtension(guardar.FileName);
                direccion = Path.GetDirectoryName(guardar.FileName);
                StreamWriter escribir = new StreamWriter(guardar.FileName);

                escribir.WriteLine("<html>\n<head>\n<title>Tokens</title>\n</head>\n<body>\n<center>\n");
                escribir.WriteLine("\n<h1>Reporte Simbolos</h1>\n<table border=\"2px\">\n");
                foreach (Token item in lista_token)
                {
                    Console.WriteLine(item.getTipo() + ", " + item.getToken());
                    escribir.WriteLine("<tr><td> " +item.getTipo()+ "</td>\n<td>"+item.getToken()+ "</td>\n<td>" + item.getFila() + "</td>\n<td>" + item.getColumna() + "</td></tr>");
                }
                escribir.WriteLine("</table></center></body>\n</html>");
                escribir.Close();
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

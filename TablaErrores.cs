using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _olc1_proyecto1
{
    class TablaErrores
    {

        LinkedList<Token> lista_error = new LinkedList<Token>();
        private static TablaErrores instancia = null;
        string nombre_archivo, direccion;
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
                foreach (Token item in lista_error)
                {
                    Console.WriteLine(item.getTipo() + ", " + item.getToken());
                    escribir.WriteLine("<tr><td> " + item.getTipo() + "</td>\n<td>" + item.getToken() + "</td>\n<td>" + item.getFila() + "</td>\n<td>" + item.getColumna() + "</td></tr>");
                }
                escribir.WriteLine("</table></center></body>\n</html>");
                escribir.Close();
            }
        }

        public void Limpiar_errores()
        {
            lista_error.Clear();
        }

    }
}

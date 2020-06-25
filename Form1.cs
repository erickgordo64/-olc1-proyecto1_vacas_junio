using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _olc1_proyecto1
{
    public partial class Form1 : Form
    {

        int contarPestana;
        ArrayList ListaPestana = new ArrayList();
        Lexico lex;
        Sintactico sintactico = new Sintactico();
        ejecutar ej = new ejecutar();
        TablaSimbolos lista;
        TablaErrores lsita_error;
        LinkedList<Token> listaTok;
        public Form1()
        {
            InitializeComponent();
        }

        internal ejecutar ejecutar
        {
            get => default;
            set
            {
            }
        }

        internal Sintactico Sintactico
        {
            get => default;
            set
            {
            }
        }

        internal Lexico Lexico
        {
            get => default;
            set
            {
            }
        }

        private void nueboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPestana("");
        }

        private void CrearPestana(string texto)
        {
            TabPage nuevaPestana = new TabPage("Entrada " + contarPestana);
            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Both;
            richTextBox1.SetBounds(3, 3, 577, 427);
            richTextBox1.Name = "cajaTxt";
            richTextBox1.Text = texto;
            nuevaPestana.Controls.Add(richTextBox1);
            ListaPestana.Add(nuevaPestana);
            tabControl1.TabPages.Add(nuevaPestana);
            contarPestana++;
            tabControl1.SelectedTab = nuevaPestana;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = "";
            string filePath = "";

            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.InitialDirectory = "C:\\";
            abrirArchivo.Filter = "Archivos SQLE (*.SQLE)(*.sqle)| *.SQLE;*.sqle";
            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = abrirArchivo.FileName;
                //Read the contents of the file into a stream
                var fileStream = abrirArchivo.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    texto = reader.ReadToEnd();

                    CrearPestana(texto);
                }


            }
        }

        private void cargarTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = "";
            string filePath = "";

            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.InitialDirectory = "C:\\";
            abrirArchivo.Filter = "Archivos SQLE (*.SQLE)(*.sqle)| *.SQLE;*.sqle";
            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = abrirArchivo.FileName;
                //Read the contents of the file into a stream
                var fileStream = abrirArchivo.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    texto = reader.ReadToEnd();

                    CrearPestana(texto);
                }


            }
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = TablaSimbolos.getInstancia();
            lista.vaciar_lista_token();
            string txt;
            txt = ObtenerTexto();
            lex = new Lexico();
            lex.A_Lexico(txt);
            lista.insertar_lista("ultimo", "ultimo", 0, 0);
            sintactico.Analisis_sintactico(lista.get_simbolo());
            ej.ejecutar_comando(lista.get_simbolo());
            pintar();

        }

        

        private void pintar()
        {
            lista = TablaSimbolos.getInstancia();
            listaTok = lista.get_simbolo();

            RichTextBox nuevorich = new RichTextBox();
            nuevorich = (RichTextBox)tabControl1.SelectedTab.Controls.Cast<Control>()
                                .FirstOrDefault(x => x is RichTextBox);
            
            
            nuevorich.SelectionStart = 0;
            nuevorich.SelectionLength = nuevorich.TextLength;
            nuevorich.SelectionColor = nuevorich.ForeColor;


            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("fecha"))
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo()+" token a pintar: "+tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {

                        
                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.Orange;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("entero") || tkn.getTipo().Equals("flotante"))
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo() + " token a pintar: " + tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {


                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.Blue;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("cadena") )
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo() + " token a pintar: " + tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {


                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.Green;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("ID"))
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo() + " token a pintar: " + tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {


                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.Brown;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("comentario_u") || tkn.getTipo().Equals("comentario_multi"))
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo() + " token a pintar: " + tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {


                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.LightGray;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            foreach (Token tkn in listaTok)
            {

                if (tkn.getTipo().Equals("reservada_tabla") || tkn.getTipo().Equals("reservada_insertar") || tkn.getTipo().Equals("reservada_eliminar") || tkn.getTipo().Equals("reservada_modificar") || tkn.getTipo().Equals("reservada_actualizar"))
                {
                    Console.WriteLine("tipo token a pintar: " + tkn.getTipo() + " token a pintar: " + tkn.getToken());
                    int index = 0;
                    while (index <= nuevorich.Text.LastIndexOf(tkn.getToken()))
                    {


                        nuevorich.Find(tkn.getToken(), index, nuevorich.TextLength, RichTextBoxFinds.WholeWord);
                        nuevorich.SelectionColor = Color.Purple;
                        index = nuevorich.Text.IndexOf(tkn.getToken(), index) + 1;


                    }
                }
                continue;
            }

            nuevorich.SelectionStart = nuevorich.TextLength;
            nuevorich.SelectionColor = nuevorich.ForeColor;



        }

        private string ObtenerTexto()
        {
            string TextoEnCaja = " ";
            RichTextBox nuevorich = new RichTextBox();
            nuevorich = (RichTextBox)tabControl1.SelectedTab.Controls.Cast<Control>()
                                .FirstOrDefault(x => x is RichTextBox);
            TextoEnCaja = nuevorich.Text;
            return TextoEnCaja;
        }

        private void imprmirTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = TablaSimbolos.getInstancia();
            lista.Imprimir();
        }

        private void verArbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sintactico.crear_arbol();
        }

        private void verTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ej.imprimirtabla();
        }

        private void imprimirErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsita_error = TablaErrores.getInstancia();
            lsita_error.Imprimir_errores();
        }
    }
}

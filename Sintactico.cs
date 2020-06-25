using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _olc1_proyecto1
{
    class Sintactico
    {
        TablaSimbolos simbolo = TablaSimbolos.getInstancia();
        TablaErrores error = TablaErrores.getInstancia();
        Token tokenactual;
        LinkedList<Token> listaTok;
        int control_token;
        string graphviz;
        string direccion;
        string nombre_grafo;
        int contenido_crear = 0, crear=0,tipo_tipo=0,insertar=0,contenido_insertar=0, tipo_campo=0,condiciones=0;
        int cadena = 0, entero = 0, flotante = 0, fecha = 0;
        int actualizar = 0, contenido_actualizar = 0, establecer = 0, contenido_establece = 0, modificar = 0, eliminar = 0, contenido_eliminar=0;
        int seleccionar = 0, contenido_seleccionar = 0, donde_seleccion = 0, tabla_seleccion = 0, tipo_seleccion = 0, condicion = 0, tabla_seleccion_columna = 0;
        public void Analisis_sintactico(LinkedList<Token> tokens)
        {
            this.listaTok = tokens;
            control_token = 0;
            tokenactual = listaTok.ElementAt(control_token);
            Console.WriteLine("inicia sintactico");
            graphviz = "graph arbol{\n";

            INICIO();
            graphviz+="}";
            
        }

        public void crear_arbol()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "archivo grafo|*.graphviz";
            guardar.Title = "grafo";
            guardar.FileName = nombre_grafo+".graphviz";
            var resultado = guardar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                nombre_grafo = Path.GetFileNameWithoutExtension(guardar.FileName);
                direccion = Path.GetDirectoryName(guardar.FileName);
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                escribir.WriteLine(graphviz);
                escribir.Close();

                string creargrafo;
                creargrafo = "dot -Tpng " + direccion + @"\" + nombre_grafo + ".graphviz -o " + direccion + @"\" + nombre_grafo + ".png";
                Console.WriteLine(creargrafo);
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + creargrafo);
                //indicamos que la salida de un proceso se redireccione en un stream
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                //indica que el proceso no despliegue una pantalla negra
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                Console.WriteLine("la imagen ya fue creada");
            }

           
        }

        private void INICIO()
        {
            graphviz += "\"INICIO\";\n";
            if (tokenactual.getTipo() == "reservada_crear")
            {
                CrearTabla();
            }
            if (tokenactual.getTipo() == "reservada_insertar")
            {
                Insertar_tabla();
            }
            if (tokenactual.getTipo() == "reservada_seleccionar")
            {
                
                Seleccionar_tabla();
            }
            if (tokenactual.getTipo() == "reservada_eliminar")
            {
                Eliminar_tabla();
            }
            if (tokenactual.getTipo() == "reservada_modificar")
            {
                Modificar_tabla();
            }
            if (tokenactual.getTipo() == "reservada_actualizar")
            {
                Actualizar_tabla();
            }
            if (tokenactual.getTipo() == "comentario_u")
            {
                emparejar("comentario_u");
                INICIO();   
            }
            if (tokenactual.getTipo() == "comentario_multi")
            {
                emparejar("comentario_multi");
                INICIO();
            }
        }

        private void Actualizar_tabla()
        {
            graphviz += "\"ACTUALIZAR"+actualizar+"\"\n";
            graphviz += "\"INICIO\"--\"ACTUALIZAR"+actualizar+"\"\n";
            actualizar++;
            emparejar("reservada_actualizar");
            CONTENIDO_ACTUALIZAR(1);
            emparejar("punto_coma");
            INICIO();
        }

        private void CONTENIDO_ACTUALIZAR(int actua)
        {
            
            if (actua == 1)
            {
                graphviz += "\"CONTENIDO_ACTUALIZAR" + contenido_actualizar + "\"\n";
                graphviz += "\"ACTUALIZAR" + (actualizar - 1) + "\"--\"CONTENIDO_ACTUALIZAR" + contenido_actualizar + "\"\n";
                contenido_actualizar++;
            }
            else
            {
                graphviz += "\"CONTENIDO_ACTUALIZAR" + contenido_actualizar + "\"\n";
                graphviz += "\"MODIFICAR" + (modificar - 1) + "\"--\"CONTENIDO_ACTUALIZAR" + contenido_actualizar + "\"\n";
                contenido_actualizar++;
            }

            
            emparejar("ID");
            ESTABLECER();
            DONDE_SELECCION(1);
        }

        private void ESTABLECER()
        {
            graphviz += "\"ESTABLECER"+establecer+"\"\n";
            graphviz += "\"CONTENIDO_ACTUALIZAR"+(contenido_actualizar-1)+"\"--\"ESTABLECER"+establecer+"\"\n";
            establecer++;
            emparejar("reservada_establecer");
            emparejar("parentesis_a");
            CONTENIDO_ESTABLECER();
            emparejar("parentesis_c");
        }

        private void CONTENIDO_ESTABLECER()
        {
            graphviz += "\"CONTENIDO_ESTABLECER"+contenido_establece+"\"\n";
            graphviz += "\"ESTABLECER"+(establecer-1)+"\"--\"CONTENIDO_ESTABLECER"+contenido_establece+"\"\n";
            contenido_establece++;
            emparejar("ID");
            emparejar("igual");
            TIPO_CAMPO(3);
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                CONTENIDO_ESTABLECER();
            }
        }

        private void Modificar_tabla()
        {
            graphviz += "\"MODIFICAR"+modificar+"\"\n";
            graphviz += "\"INICIO\"--\"MODIFICAR"+modificar+"\"\n";
            modificar++;
            emparejar("reservada_modificar");
            CONTENIDO_ACTUALIZAR(2);
            emparejar("punto_coma");
            INICIO();
        }

        private void Eliminar_tabla()
        {
            graphviz += "\"ELIMINAR"+eliminar+"\"\n";
            graphviz += "\"INICIO\"--\"ELIMINAR"+eliminar+"\"\n";
            eliminar++;
            emparejar("reservada_eliminar");
            emparejar("reservada_de");
            CONTENIDO_ELIMINAR();
            emparejar("punto_coma");
            INICIO();
        }

        private void CONTENIDO_ELIMINAR()
        {
            graphviz += "\"CONTENIDO_ELIMINAR"+contenido_eliminar+"\"\n";
            graphviz += "\"ELIMINAR"+(eliminar-1)+"\"--\"CONTENIDO_ELIMINAR"+contenido_eliminar+"\"\n";
            contenido_eliminar++;
            emparejar("ID");
            DONDE_SELECCION(2);
        }

        private void Seleccionar_tabla()
        {
            graphviz += "\"SELECCIONAR"+seleccionar+"\"\n";
            graphviz += "\"INICIO\"--\"SELECCIONAR"+seleccionar+"\"\n";
            seleccionar++;
            emparejar("reservada_seleccionar");
            CONTENIDO_SELECCIONAR();
            emparejar("punto_coma");
            INICIO();
        }

        private void CONTENIDO_SELECCIONAR()
        {
            graphviz += "\"CONTENIDO_SELECCIONAR"+contenido_seleccionar+"\"\n";
            graphviz += "\"SELECCIONAR"+(seleccionar-1)+"\"--\"CONTENIDO_SELECCIONAR"+contenido_seleccionar+"\"\n";
            contenido_seleccionar++;
            TIPO_SELECCION();
            emparejar("reservada_de");
            TABLA_SELECCION();
            DONDE_SELECCION(3);
        }

        private void DONDE_SELECCION(int donde)
        {
            if (donde == 1)
            {
                graphviz += "\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                graphviz += "\"CONTENIDO_ACTUALIZAR" + (contenido_actualizar - 1) + "\"--\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                donde_seleccion++;
            }
            else if (donde == 2)
            {
                graphviz += "\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                graphviz += "\"CONTENIDO_ELIMINAR" + (contenido_eliminar - 1) + "\"--\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                donde_seleccion++;
            }
            else if (donde == 3)
            {
                graphviz += "\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                graphviz += "\"CONTENIDO_SELECCIONAR" + (contenido_seleccionar - 1) + "\"--\"DONDE_SELECCION" + donde_seleccion + "\"\n";
                donde_seleccion++;
            }

            if (tokenactual.getTipo() == "reservada_donde")
            {
                emparejar("reservada_donde");
                CONDICIONES();
            }
        }

        private void CONDICIONES()
        {
            graphviz += "\"CONDICIONES" + condiciones + "\"\n";
            graphviz += "\"DONDE_SELECCION" + (donde_seleccion - 1) + "\"--\"CONDICIONES" + condiciones + "\"\n";
            condiciones++;

            emparejar("ID");
            CONDICION();
            TIPO_CAMPO(2);
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                CONDICIONES();
            }else if (tokenactual.getTipo() == "reservada_y")
            {
                emparejar("reservada_y");
                CONDICIONES();
            }else if (tokenactual.getTipo() == "reservada_O")
            {
                emparejar("reservada_O");
                CONDICIONES();
            }
        }

        private void CONDICION()
        {
            graphviz += "\"CONDICION" + condicion + "\"\n";
            graphviz += "\"CONDICIONES" + (condiciones - 1) + "\"--\"CONDICION" + condicion + "\"\n";
            condicion++;



            if (tokenactual.getTipo() == "comparador")
            {
                graphviz += "\"CONDICION" + (condicion - 1) + "\"--\""+tokenactual.getToken()+"\"\n";
                emparejar("comparador");
            }else if (tokenactual.getTipo() == "mayor_que")
            {
                graphviz += "\"CONDICION" + (condicion - 1) + "\"--\"" + tokenactual.getToken() + "\"\n";
                emparejar("mayor_que");
            }else if (tokenactual.getTipo()=="menor_que")
            {
                graphviz += "\"CONDICION" + (condicion - 1) + "\"--\"" + tokenactual.getToken() + "\"\n";
                emparejar("menor_que");
            }else if (tokenactual.getTipo() == "igual")
            {
                graphviz += "\"CONDICION" + (condicion - 1) + "\"--\"" + tokenactual.getToken() + "\"\n";
                emparejar("igual");
            }
            else
            {
                emparejar("condicional");
            }

        }

        private void TIPO_SELECCION()
        {
            graphviz += "\"TIPO_SELECCION" + tipo_seleccion + "\"\n";
            graphviz += "\"CONTENIDO_SELECCIONAR" + (contenido_seleccionar - 1) + "\"--\"TIPO_SELECCION" + tipo_seleccion + "\"\n";
            tipo_seleccion++;

            if (tokenactual.getTipo() == "asterisco")
            {
                emparejar("asterisco");
            }
            else
            {
                TABLA_SELECCION_COLUMNA();
            } 
        }

        private void TABLA_SELECCION_COLUMNA()
        {
            graphviz += "\"TABLA_SELECCION_COLUMNA" + tabla_seleccion_columna + "\"\n";
            graphviz += "\"TIPO_SELECCION" + (tipo_seleccion - 1) + "\"--\"TABLA_SELECCION_COLUMNA" + tabla_seleccion_columna + "\"\n";
            tabla_seleccion_columna++;
            emparejar("id");
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                TABLA_SELECCION_COLUMNA();
            }else if (tokenactual.getTipo() == "punto")
            {
                emparejar("punto");
                TABLA_SELECCION_COLUMNA();
            }else if (tokenactual.getTipo() == "reservada_como")
            {
                emparejar("reservada_como");
                TABLA_SELECCION_COLUMNA();
            }
        }

        private void TABLA_SELECCION()
        {
            graphviz += "\"TABLA_SELECCION" + tabla_seleccion + "\"\n";
            graphviz += "\"CONTENIDO_SELECCIONAR" + (contenido_seleccionar - 1) + "\"--\"TABLA_SELECCION" + tabla_seleccion + "\"\n";
            tabla_seleccion++;
            emparejar("ID");
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                TABLA_SELECCION();
            }
        }

        private void Insertar_tabla()
        {
            graphviz += "\"INSERTAR"+insertar+"\"\n";
            graphviz += "\"INICIO\"--\"INSERTAR"+insertar+"\"\n";
            insertar++;

            emparejar("reservada_insertar");
            emparejar("reservada_en");
            emparejar("ID");
            emparejar("reservada_valores");
            emparejar("parentesis_a");
            CONTENIDO_INSERTAR();
            emparejar("parentesis_c");
            emparejar("punto_coma");
            INICIO();
        }

        private void CONTENIDO_INSERTAR()
        {
            graphviz += "\"CONTENIDO_INSERTAR"+ contenido_insertar + "\"\n";
            graphviz += "\"INSERTAR"+(insertar-1)+"\"--\"CONTENIDO_INSERTAR" + contenido_insertar + "\"\n";
            contenido_insertar++;

            TIPO_CAMPO(1);
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                CONTENIDO_INSERTAR();
            }
        }

        private void TIPO_CAMPO(int procedencia)
        {
            if (procedencia == 1)
            {
                graphviz += "\"TIPO_CAMPO" + tipo_campo + "\"\n";
                graphviz += "\"CONTENIDO_INSERTAR" + (contenido_insertar - 1) + "\"--\"TIPO_CAMPO" + tipo_campo + "\"\n";
                tipo_campo++;
            }
            else if (procedencia == 3)
            {
                graphviz += "\"TIPO_CAMPO" + tipo_campo + "\"\n";
                graphviz += "\"CONTENIDO_ESTABLECER" + (contenido_establece - 1) + "\"--\"TIPO_CAMPO" + tipo_campo + "\"\n";
                tipo_campo++;
            }
            else if (procedencia == 2)
            {
                graphviz += "\"TIPO_CAMPO" + tipo_campo + "\"\n";
                graphviz += "\"CONDICIONES" + (condiciones - 1) + "\"--\"TIPO_CAMPO" + tipo_campo + "\"\n";
                tipo_campo++;
            }
            /*******************************************************************************************/
            if (tokenactual.getTipo() == "cadena")
            {
                graphviz += "\"TIPO_CAMPO" + (tipo_campo - 1) + "\"--\"cadena"+cadena+"\"\n";
                graphviz += "cadena"+cadena+"[label="+tokenactual.getToken()+"]\n";
                cadena++;
                emparejar("cadena");
            }
            else if (tokenactual.getTipo() == "entero")
            {
                graphviz += "\"TIPO_CAMPO" + (tipo_campo - 1) + "\"--\"entero" + entero + "\"\n";
                graphviz += "entero" + entero + "[label=\"" + tokenactual.getToken() + "\"]\n";
                entero++;
                emparejar("entero");
            }
            else if (tokenactual.getTipo() == "flotante")
            {
                graphviz += "\"TIPO_CAMPO" + (tipo_campo - 1) + "\"--\"flotante" + flotante + "\"\n";
                graphviz += "flotante" + flotante + "[label=\"" + tokenactual.getToken() + "\"]\n";
                flotante++;
                emparejar("flotante");
            }
            else if (tokenactual.getTipo() == "fecha")
            {
                graphviz += "\"TIPO_CAMPO" + (tipo_campo - 1) + "\"--\"fecha" + fecha + "\"\n";
                graphviz += "fecha" + fecha + "[label=\"" + tokenactual.getToken() + "\"]\n";
                fecha++;
                emparejar("fecha");
            }
            else
            {
                emparejar("asignacion de valor");
            }
            
        }

        private void CrearTabla()
        {
            graphviz += "\"CREAR" + crear + "\"\n";
            graphviz += "\"INICIO\"--\"CREAR"+crear+"\"\n";
            crear++;
            emparejar("reservada_crear");
            emparejar("reservada_tabla");
            emparejar("ID");
            emparejar("parentesis_a");
            CONTENIDO_CREAR();
            emparejar("parentesis_c");
            emparejar("punto_coma");
            INICIO();
        }

        private void CONTENIDO_CREAR()
        {
            graphviz += "\"CONTENIDO_CREAR"+contenido_crear+"\"\n";
            graphviz += "\"CREAR"+(crear-1)+"\"--\"CONTENIDO_CREAR"+contenido_crear+"\"\n";
            contenido_crear++;
            emparejar("ID");
            TIPO_TIPO();
            if (tokenactual.getTipo() == "coma")
            {
                emparejar("coma");
                CONTENIDO_CREAR();
            }
        }

        private void TIPO_TIPO()
        {

            graphviz += "\"TIPO_TIPO"+tipo_tipo+"\"\n";
            graphviz += "\"CONTENIDO_CREAR"+(contenido_crear-1)+"\"--\"TIPO_TIPO"+tipo_tipo+"\"\n";
            tipo_tipo++;
            if (tokenactual.getTipo() == "reservada_cadena")
            {
                graphviz += "\"TIPO_TIPO"+(tipo_tipo-1)+"\"--\"reservada_cadena\"\n";
                emparejar("reservada_cadena");
            }else if (tokenactual.getTipo() == "reservada_entero")
            {
                graphviz += "\"TIPO_TIPO" + (tipo_tipo - 1) + "\"--\"reservada_entero\"\n";
                emparejar("reservada_entero");
            }else if (tokenactual.getTipo() == "reservada_flotante")
            {
                graphviz += "\"TIPO_TIPO" + (tipo_tipo - 1) + "\"--\"reservada_flotante\"\n";
                emparejar("reservada_flotante");
            }else if (tokenactual.getTipo() == "reservada_fecha")
            {
                graphviz += "\"TIPO_TIPO" + (tipo_tipo - 1) + "\"--\"reservada_fecha\"\n";
                emparejar("reservada_fecha");
            }
        }

        private void emparejar(String tok)
        {
            if (tokenactual.getTipo() != tok)
            {
                Console.WriteLine("Error se esperaba " + tok);
                error.insertar_lista_error("error_sintactico", tokenactual.getToken(), tokenactual.getFila(), tokenactual.getColumna());
            }

            Console.WriteLine("se analizo token: " + tok);

            if (tokenactual.getTipo() != "ultimo")
            {
                control_token += 1;
                tokenactual = listaTok.ElementAt(control_token);

                if (tokenactual.getTipo() == "comentario_u" || tokenactual.getTipo() == "comentario_u")
                {
                    control_token += 1;
                    tokenactual = listaTok.ElementAt(control_token);
                }
            }
        }
    }
}

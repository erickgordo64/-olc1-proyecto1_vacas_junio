using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _olc1_proyecto1
{

    class Lexico
    {
        int contador;
        int fila;
        int columna;
        int estado;
        string token;
        string[] palabras_reservadas;
        char[] vectorChar;
        public TablaSimbolos lista;
        public TablaErrores lista_error;

        public Lexico()
        {
            palabras_reservadas = new string[20] {"establecer","como","insertar","valores","de","seleccionar","tabla","crear","eliminar","modificar","donde","en","como","actualizar","entero","cadena","flotante","fecha","y","o"};
            contador = 0;
            fila = 0;
            columna = 0;
            estado = 0;
            token = "";
        }

        public void A_Lexico(string cadena)
        {
            //limpio listas
            limpiarlistas();
            //SEPARA LO DE LA CAJA DE TEXTO EN UN VECTOR DE CHARS
            vectorChar = cadena.ToCharArray();
            Console.WriteLine("largo vercto char " + vectorChar.Length);
            for (contador = 0; contador < vectorChar.Length; contador++)
            {
                Automata(vectorChar[contador]);
                //Console.WriteLine("simbolo: " + vectorChar[contador]);
            }
            Console.WriteLine("termino lexico");
        }

        

        private void Automata(char simbolo)
        {
            switch (estado)
            {
                case 0:
                    if (Char.IsLetter(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 1;
                    } else if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 26;
                    } else if (simbolo == 39)
                    {
                        token += simbolo;
                        columna++;
                        estado = 2;
                    } else if (simbolo == 34)
                    {
                        token += simbolo;
                        columna++;
                        estado = 14;
                    } else if (simbolo == 45)//guion medio
                    {
                        token += simbolo;
                        columna++;
                        estado = 16;
                    } else if (simbolo == 47)//diagonal 
                    {
                        token += simbolo;
                        columna++;
                        estado = 18;
                    } else if (simbolo == 33)
                    {
                        token += simbolo;
                        columna++;
                        estado = 22;
                    } else if (simbolo == 60)//mayor
                    {
                        token += simbolo;
                        columna++;
                        estado = 24;
                    } else if (simbolo == 62)//menor 
                    {
                        token += simbolo;
                        columna++;
                        estado = 25;
                    } 
                    else
                    {
                        contador--;
                        estado = 29;
                    }
                    break;
                case 1:
                    if (Char.IsLetter(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 1;
                    } else if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 1;
                    } else if (simbolo == 95)
                    {
                        token += simbolo;
                        columna++;
                        estado = 1;
                    }
                    else
                    {
                        verificar_tipo(token);
                        token = "";
                        contador--;
                        estado = 0;
                    }
                    break;
                case 2:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 3;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 2;
                    }
                    break;
                case 3:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 4;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 3;
                    }
                    break;
                case 4:
                    if (simbolo == 47)
                    {
                        token += simbolo;
                        columna++;
                        estado = 5;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 4;
                    }
                    break;
                case 5:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 6;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 5;
                    }
                    break;
                case 6:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 7;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 6;
                    }
                    break;
                case 7:
                    if (simbolo == 47)
                    {
                        token += simbolo;
                        columna++;
                        estado = 8;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 7;
                    }
                    break;
                case 8:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 9;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 8;
                    }
                    break;
                case 9:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 10;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 9;
                    }
                    break;
                case 10:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 11;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 10;
                    }
                    break;
                case 11:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 12;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 11;
                    }
                    break;
                case 12:
                    if (simbolo == 39)
                    {
                        token += simbolo;
                        columna++;
                        estado = 13;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 12;
                    }
                    break;
                case 13:
                    insertar("fecha", token, fila, columna);
                    token = "";
                    contador--;
                    estado = 0;
                    break;
                case 14:
                    if (simbolo == 34)//comillas
                    {
                        token += simbolo;
                        columna++;
                        estado = 15;
                    }
                    else
                    {
                        token += simbolo;
                        columna++;
                        estado = 14;
                    }
                    break;
                case 15:
                    insertar("cadena", token, fila, columna);
                    token = "";
                    contador--;
                    estado = 0;
                    break;
                case 16:
                    if (simbolo == 45)
                    {
                        token += simbolo;
                        columna++;
                        estado = 17;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 16;
                    }
                    break;
                case 17:
                    if (simbolo == 10)
                    {
                        insertar("comentario_u", token, fila, columna);
                        token = "";
                        columna = 0;
                        fila++;
                        estado = 0;
                    }
                    else
                    {
                        token += simbolo;
                        columna++;
                        estado = 17;
                    }
                    break;
                case 18:
                    if (simbolo == 42)
                    {
                        token += simbolo;
                        columna++;
                        estado = 19;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 18;
                    }
                    break;
                case 19:
                    if (simbolo == 42)
                    {
                        token += simbolo;
                        columna++;
                        estado = 20;
                    }
                    else
                    {
                        token += simbolo;
                        columna++;
                        estado = 19;
                    }
                    break;
                case 20:
                    if (simbolo == 47)
                    {
                        token += simbolo;
                        columna++;
                        estado = 21;
                    }
                    else
                    {
                        token += simbolo;
                        columna++;
                        estado = 19;
                    }
                    break;
                case 21:
                    insertar("comentario_multi", token, fila, columna);
                    token = "";
                    contador--;
                    estado = 0;
                    break;
                case 22:
                    if (simbolo == 61)//igual
                    {
                        token += simbolo;
                        columna++;
                        estado = 23;
                    }
                    else
                    {
                        string error = " ";
                        error += simbolo;
                        Insertar_error("error lexico", error, fila, columna);
                        columna++;
                        estado = 22;
                    }
                    break;
                case 23:
                    insertar("comparador", token, fila, columna);
                    token = "";
                    contador--;
                    estado = 0;
                    break;
                case 24:
                    if (simbolo == 61)// igual
                    {
                        token += simbolo;
                        columna++;
                        estado = 23;
                    }
                    else
                    {
                        insertar("menor_que", token, fila, columna);
                        token = "";
                        contador--;
                        estado = 0;
                    }
                    break;
                case 25:
                    if (simbolo == 61)// igual
                    {
                        token += simbolo;
                        columna++;
                        estado = 23;
                    }
                    else
                    {
                        insertar("mayor_que", token, fila, columna);
                        token = "";
                        contador--;
                        estado = 0;
                    }
                    break;
                case 26:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 26;
                    } else if (simbolo == 46)//punto
                    {
                        token += simbolo;
                        columna++;
                        estado = 27;
                    }
                    else
                    {
                        insertar("entero", token, fila, columna);
                        token = "";
                        contador--;
                        estado = 0;
                    }
                    break;
                case 27:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 28;
                    }
                    else
                    {
                        String error="";
                        error += simbolo;
                        Insertar_error("error_lexico", error, fila, columna);
                        columna++;
                        estado = 27;
                    }
                    break;
                case 28:
                    if (Char.IsDigit(simbolo))
                    {
                        token += simbolo;
                        columna++;
                        estado = 28;
                    }
                    else
                    {
                        insertar("flotante", token, fila, columna);
                        token = "";
                        contador--;
                        estado = 0;
                    }
                    break;
                case 29:
                    if (simbolo == 10)//salto
                    {
                        fila++;
                        columna = 0;
                        estado = 0;
                    }
                    else if (simbolo == 32)//espacio
                    {
                        columna++;
                        estado = 0;
                    }
                    else if (simbolo == 9)//tab
                    {
                        columna += 2;
                        estado = 0;
                    }
                    else if (simbolo == 40)//parentesis abre
                    {
                        token += simbolo;
                        columna++;
                        insertar("parentesis_a", token, fila, columna);
                        token = "";
                        estado = 0;
                    }
                    else if (simbolo == 41)//parentesis cierra
                    {
                        token += simbolo;
                        columna++;
                        insertar("parentesis_c", token, fila, columna);
                        token = "";
                        estado = 0;
                    }
                    else if (simbolo == 59)//punto y coma
                    {
                        token += simbolo;
                        columna++;
                        insertar("punto_coma", token, fila, columna);
                        token = "";
                        estado = 0;
                    }else if (simbolo == 46)//punto
                    {
                        token += simbolo;
                        columna++;
                        insertar("punto", token, fila, columna);
                        token = "";
                        estado = 0;
                    }else if (simbolo == 44)//coma
                    {
                        token += simbolo;
                        columna++;
                        insertar("coma", token, fila, columna);
                        token = "";
                        estado = 0;
                    }else if (simbolo == 61)//igual
                    {
                        token += simbolo;
                        columna++;
                        insertar("igual", token, fila, columna);
                        token = "";
                        estado = 0;
                    }else if (simbolo == 42)
                    {
                        token += simbolo;
                        columna++;
                        insertar("asterisco", token, fila, columna);
                        token = "";
                        estado = 0;
                    }
                    else
                    {
                        token += simbolo;
                        columna++;
                        Insertar_error("error lexico", token, fila, columna);
                        columna++;
                        estado = 0;
                    }
                    break;
            }
        }

        private void verificar_tipo(string token)
        {
            Boolean bandera=false;
            String sense = token.ToLower();
            for(int i = 0; i < palabras_reservadas.Length; i++)
            {
                if (sense.Equals(palabras_reservadas[i]))
                {
                    insertar("reservada_"+palabras_reservadas[i], token, fila, columna);
                    bandera = true;
                    break;
                }
            }

            if (bandera == false)
            {
                insertar("ID", token, fila, columna);
            }
        }

        public void insertar(String tipo, String texto, int fila, int columna)
        {
            lista = TablaSimbolos.getInstancia();
            lista.insertar_lista(tipo,texto,fila,columna);
        }

        public void Insertar_error(String tipo, String texto, int fila, int columna)
        {
            lista_error = TablaErrores.getInstancia();
            lista_error.insertar_lista_error(tipo, texto, fila, columna);
        }

        public void imprimir_list_error()
        {
            lista_error = TablaErrores.getInstancia();
            lista_error.Imprimir_errores();
        }

        public void imprimir_list()
        {
            lista = TablaSimbolos.getInstancia();
            lista.Imprimir();
        }

        private void limpiarlistas()
        {
            lista = TablaSimbolos.getInstancia();
            lista_error = TablaErrores.getInstancia();
            lista.vaciar_lista_token();
            lista_error.Limpiar_errores();
        }
    }
}

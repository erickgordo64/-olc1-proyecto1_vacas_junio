using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _olc1_proyecto1
{
    class ejecutar
    {
        int contadortoken = 0;
        int contadorlista = 0;
        private List<Tabla> tablas = new List<Tabla>();
        int temporal = 0;
        int fila = 0;
        int columna = 0;
        int contadoro = 0;
        List<Condicion> condiciones;
        List<Seleccion> seleccion;
        public List<Tabla> tablasaux;
        public List<Fila> filasconsulta;
        LinkedList<Token> listaTok;
        Token tokenactual;
        int control_token;
        public void ejecutar_comando(LinkedList<Token> tokens)
        {
            control_token = 0;
            listaTok = tokens;
            tokenactual = listaTok.ElementAt(control_token);
            INICIO();
        }

        private void INICIO()
        {

            if (control_token < listaTok.Count - 1)
            {
                if (tokenactual.getTipo() == "reservada_crear")
                {
                    CrearTabla();
                }
                else
           if (tokenactual.getTipo() == "reservada_insertar")
                {
                    Insertar_tabla();
                }
                else
           if (tokenactual.getTipo() == "reservada_seleccionar")
                {

                    Seleccionar_tabla();
                }
                else
           if (tokenactual.getTipo() == "reservada_eliminar")
                {
                    Eliminar_tabla();
                }
                else
           if (tokenactual.getTipo() == "reservada_modificar")
                {
                    Modificar_tabla();
                }
                else
           if (tokenactual.getTipo() == "reservada_actualizar")
                {
                    Actualizar_tabla();
                }
                else
                {
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    INICIO();
                }
            }

           
            
        }

        private void CrearTabla()
        {
            contadorlista++;
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            if (tokenactual.getTipo() == "reservada_tabla")
            {
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "ID")
                {
                    List<Fila> n = new List<Fila>();
                    tablas.Add(new Tabla(tokenactual.getToken(), n));
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "parentesis_a")
                    {
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);
                        declaracion();

                    }

                }

            }
            INICIO();
        }

        private void declaracion()
        {
            List<String> n = new List<String>();
            if (tokenactual.getTipo() == "ID")
            {
                tablas[contadorlista - 1].filas.Add(new Fila(tokenactual.getToken(), n));
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "reservada_entero" || tokenactual.getTipo() == "reservada_cadena" || tokenactual.getTipo() == "reservada_fecha" || tokenactual.getTipo() == "reservada_flotante")
                {
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "coma")
                    {
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);
                        declaracion();
                    }
                    else
                    {

                    }
                }
            }
        }

        private void Insertar_tabla()
        {
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            if (tokenactual.getTipo() == "reservada_en")
            {
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "ID")
                {
                    for (int i = 0; i < tablas.Count; i++)
                    {
                        if (tablas[i].nombre == tokenactual.getToken())
                        {
                            //Console.WriteLine("la tabla actual es: " + tokenactual.getToken());
                            temporal = i;
                        }
                    }
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "reservada_valores")
                    {
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);

                        if (tokenactual.getTipo() == "parentesis_a")
                        {
                            control_token++;
                            tokenactual = listaTok.ElementAt(control_token);
                            insertando(0);

                        }

                    }

                }

            }
            INICIO();
        }

        private void insertando(int i)
        {
            if (tokenactual.getTipo() == "entero" || tokenactual.getTipo() == "cadena" || tokenactual.getTipo() == "fecha" || tokenactual.getTipo() == "flotante")
            {
                tablas[temporal].filas[i].columnas.Add(tokenactual.getToken());
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "coma")
                {
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    insertando(i + 1);
                }
                else
                {

                }
            }
        }

        private void Seleccionar_tabla()
        {
            throw new NotImplementedException();
        }

        private void Eliminar_tabla()
        {
            
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            if (tokenactual.getTipo() == "reservada_de")
            {
                
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "ID")
                {
                    for (int i = 0; i < tablas.Count; i++)
                    {
                        if (tablas[i].nombre == tokenactual.getToken())
                        {
                            
                            temporal = i;
                        }
                    }
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);

                    if (tokenactual.getTipo() == "reservada_donde")
                    {
                        
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);

                        borrardonde();

                    }
                    else if (tokenactual.getTipo() == "punto_coma")
                    {

                        for (int j = 0; j < tablas[temporal].filas.Count; j++)
                        {
                            for (int k = 0; k < tablas[temporal].filas[j].columnas.Count; k++)
                            {
                                tablas[temporal].filas[j].columnas = new List<string>();
                            }
                        }

                    }


                }

            }

            INICIO();
        }

        private void borrardonde()
        {
            String lex = "";
            String fila = "";
            String comparador = "";
            if (tokenactual.getTipo() == "ID")
            {
                lex = tokenactual.getToken();
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);

                if (tokenactual.getTipo() == "comparador" || tokenactual.getTipo() == "igual"  || tokenactual.getTipo() == "mayor_que" || tokenactual.getTipo() == "menor_que")
                {
                    
                    comparador = tokenactual.getToken();
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "entero" || tokenactual.getTipo() == "cadena" || tokenactual.getTipo() == "fecha" || tokenactual.getTipo() == "flotante" || tokenactual.getTipo() == "ID")
                    {
                        
                        fila = tokenactual.getToken();
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);

                        if (tokenactual.getTipo() == "reservada_y")
                        {
                            control_token++;
                            tokenactual = listaTok.ElementAt(control_token);
                            if (tokenactual.getTipo() == "punto_coma")
                            {
                                eliminardato(lex, comparador, fila);
                            }
                            else
                            {
                                eliminardato(lex, comparador, fila);
                                borrardonde();
                            }
                        }
                        else if (tokenactual.getTipo() == "reservada_o")
                        {
                            if (contadoro == 0)
                            {

                                control_token++;
                                tokenactual = listaTok.ElementAt(control_token);
                                if (tokenactual.getTipo() == "punto_coma")
                                {
                                    eliminardato(lex, comparador, fila);
                                }
                                else
                                {
                                    eliminardato(lex, comparador, fila);
                                    borrardonde();
                                }
                            }
                        }
                        else if (tokenactual.getTipo() == "punto_coma")
                        {
                            
                            eliminardato(lex, comparador, fila);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void eliminardato(string lex, string com, string fi)
        {
            
            try
            {
                
                for (int i = 0; i < tablas[temporal].filas.Count; i++)
                {
                    
                    if (tablas[temporal].filas[i].nombre == lex)
                    {
                        
                        for (int j = 0; j < tablas[temporal].filas[i].columnas.Count; j++)
                        {
                            
                            if (com.Equals("="))
                            {
                                
                                if (tablas[temporal].filas[i].columnas[j] == fi)
                                {
                                    for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                    {
                                        tablas[temporal].filas[k].columnas.RemoveAt(j);

                                    }
                                }
                                else
                                {

                                }
                            }
                            else if (com.Equals("!="))
                            {
                                try
                                {
                                    if (tablas[temporal].filas[i].columnas[j] != fi)
                                    {
                                        //Console.WriteLine("entro a menor o igual  "+tablas[temporal].filas[i].columnas[j]);

                                        for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                        {
                                            tablas[temporal].filas[k].columnas.RemoveAt(j);

                                        }
                                        eliminardato(lex, com, fi);
                                    }
                                }
                                catch (Exception o)
                                {

                                }
                            }
                            else if (com.Equals(">="))
                            {
                                try
                                {
                                    if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) >= Int32.Parse(fi))
                                    {
                                        //Console.WriteLine("entro a menor o igual  "+tablas[temporal].filas[i].columnas[j]);

                                        for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                        {
                                            tablas[temporal].filas[k].columnas.RemoveAt(j);

                                        }
                                        eliminardato(lex, com, fi);
                                    }
                                }
                                catch (Exception o)
                                {

                                }
                            }
                            else if (com.Equals(">"))
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) > Int32.Parse(fi))
                                {

                                    for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                    {
                                        tablas[temporal].filas[k].columnas.RemoveAt(j);

                                    }
                                }
                                else
                                {

                                }
                            }
                            else if (com.Equals("<="))
                            {
                                try
                                {
                                    if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) <= Int32.Parse(fi))
                                    {
                                        //Console.WriteLine("entro a menor o igual  "+tablas[temporal].filas[i].columnas[j]);

                                        for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                        {
                                            tablas[temporal].filas[k].columnas.RemoveAt(j);

                                        }
                                        eliminardato(lex, com, fi);
                                    }
                                }
                                catch (Exception o)
                                {

                                }
                            }
                            else if (com.Equals("<"))
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) < Int32.Parse(fi))
                                {

                                    for (int k = 0; k < tablas[temporal].filas.Count; k++)
                                    {
                                        tablas[temporal].filas[k].columnas.RemoveAt(j);

                                    }
                                }
                                else
                                {

                                }
                            }


                        }

                    }
                }
            }
            catch (Exception o)
            {

            }
        }

        private void Modificar_tabla()
        {
            condiciones = new List<Condicion>();
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            if (tokenactual.getTipo() == "ID")
            {
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "reservada_establecer")
                {
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "parentesis_a")
                    {

                        condi();
                    }
                }
            }
            INICIO();
        }

        private void Actualizar_tabla()
        {
            condiciones = new List<Condicion>();
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            if (tokenactual.getTipo() == "ID")
            {
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "reservada_establecer")
                {
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "parentesis_a")
                    {

                        condi();
                    }
                }
            }
            INICIO();
        }

        private void condi()
        {
            control_token++;
            tokenactual = listaTok.ElementAt(control_token);
            String n = "";
            String c = "";
            String v = "";
            if (tokenactual.getTipo() == "ID")
            {
                n = tokenactual.getToken();
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);
                if (tokenactual.getTipo() == "igual")
                {
                    c = tokenactual.getTipo();
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "entero" || tokenactual.getTipo() == "cadena" || tokenactual.getTipo() == "fecha" || tokenactual.getTipo() == "flotante")
                    {
                        v = tokenactual.getToken();
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);
                        if (tokenactual.getTipo() == "coma")
                        {
                            condiciones.Add(new Condicion(n, c, v));
                            condi();
                        }
                        else if (tokenactual.getTipo() == "parentesis_c")
                        {
                            condiciones.Add(new Condicion(n, c, v));
                            control_token++;
                            tokenactual = listaTok.ElementAt(control_token);

                            if (tokenactual.getTipo() == "reservada_donde")
                            {
                                control_token++;
                                tokenactual = listaTok.ElementAt(control_token);
                                actualizarcampos();
                            }
                        }

                    }
                }
            }
        }

        private void actualizarcampos()
        {
            String lex = "";
            String fila = "";
            String comparador = "";
            Console.WriteLine("entro al y");
            if (tokenactual.getTipo() == "ID")
            {
                lex = tokenactual.getToken();
                control_token++;
                tokenactual = listaTok.ElementAt(control_token);

                if (tokenactual.getTipo() == "comparador" || tokenactual.getTipo() == "igual" || tokenactual.getTipo() == "mayor_que" || tokenactual.getTipo() == "menor_que")
                {
                    comparador = tokenactual.getToken();
                    control_token++;
                    tokenactual = listaTok.ElementAt(control_token);
                    if (tokenactual.getTipo() == "entero" || tokenactual.getTipo() == "cadena" || tokenactual.getTipo() == "fecha" || tokenactual.getTipo() == "flotante" || tokenactual.getTipo() == "ID")
                    {
                        fila = tokenactual.getToken();
                        control_token++;
                        tokenactual = listaTok.ElementAt(control_token);

                        if (tokenactual.getTipo() == "reservada_y")
                        {
                            control_token++;
                            tokenactual = listaTok.ElementAt(control_token);
                            if (tokenactual.getTipo() == "punto_coma")
                            {
                                cambiardato(lex, comparador, fila);
                            }
                            else
                            {
                                cambiardato(lex, comparador, fila);
                                actualizarcampos();
                            }
                        }
                        else if (tokenactual.getTipo() == "reservada_o")
                        {
                            if (contadoro == 0)
                            {

                                control_token++;
                                tokenactual = listaTok.ElementAt(control_token);
                                if (tokenactual.getTipo() == "punto_coma")
                                {
                                    cambiardato(lex, comparador, fila);
                                }
                                else
                                {
                                    cambiardato(lex, comparador, fila);
                                    actualizarcampos();
                                }
                            }
                        }
                        else if (tokenactual.getTipo() == "punto_coma")
                        {
                            cambiardato(lex, comparador, fila);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void cambiardato(string lex, string com, string fi)
        {
            for (int i = 0; i < tablas[temporal].filas.Count; i++)
            {
                if (tablas[temporal].filas[i].nombre == lex)
                {
                    for (int j = 0; j < tablas[temporal].filas[i].columnas.Count; j++)
                    {

                        if (com == "=")
                        {
                            try
                            {
                                if (tablas[temporal].filas[i].columnas[j] == fi)
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                                else
                                {

                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }
                        else if (com == "!=")
                        {
                            try
                            {
                                if (tablas[temporal].filas[i].columnas[j] != fi)
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }
                        else if (com == ">=")
                        {
                            try
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) >= Int32.Parse(fi))
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }
                        else if (com == ">")
                        {
                            try
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) > Int32.Parse(fi))
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }
                        else if (com == "<=")
                        {
                            try
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) <= Int32.Parse(fi))
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }
                        else if (com == "<")
                        {
                            try
                            {
                                if (Int32.Parse(tablas[temporal].filas[i].columnas[j]) < Int32.Parse(fi))
                                {
                                    for (int k = 0; k < condiciones.Count; k++)
                                    {

                                        for (int h = 0; h < tablas[temporal].filas.Count; h++)
                                        {
                                            if (tablas[temporal].filas[h].nombre == condiciones[k].campo)
                                            {
                                                tablas[temporal].filas[h].columnas[j] = condiciones[k].valor;
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception o)
                            {

                            }
                        }


                    }

                }
            }
        }

        public void imprimirtabla()
        {
            Console.WriteLine("Tablas_____________________________________________________");

            for (int i = 0; i < tablas.Count; i++)
            {
                Console.WriteLine(tablas[i].nombre);
                for (int j = 0; j < tablas[i].filas.Count; j++)
                {
                    Console.WriteLine(tablas[i].filas[j].nombre);
                    for (int k = 0; k < tablas[i].filas[j].columnas.Count; k++)
                    {
                        Console.WriteLine(tablas[i].filas[j].columnas[k]);

                    }
                }
            }

        }


        public List<Tabla> gettabla()
        {
            return tablas;
        }

        internal class Condicion
        {
            public String campo;
            public String signo;
            public String valor;
            public Condicion(String c, String s, String v)
            {
                this.campo = c;
                this.signo = s;
                this.valor = v;
            }
        }

        internal class Seleccion
        {
            public String tabla;
            public String atributo;
            public String nuevo;
            public Seleccion(String c, String s, String v)
            {
                this.tabla = c;
                this.atributo = s;
                this.nuevo = v;
            }
        }

    }
}

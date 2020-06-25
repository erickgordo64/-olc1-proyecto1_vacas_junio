using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _olc1_proyecto1
{
    class Token
    {

        private String tipo, token;
        private int fila, columna;

        public Token(String tipo,String token,int fila,int columna)
        {
            this.tipo = tipo;
            this.token = token;
            this.fila = fila;
            this.columna=columna;
        }
        
        public String getTipo()
        {
            return tipo;
        }

        public String getToken()
        {
            return token;
        }

        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }

    }
}

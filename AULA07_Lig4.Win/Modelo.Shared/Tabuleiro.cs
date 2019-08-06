using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Shared
{
    public class Tabuleiro
    {
        private Peca[,] pecas;
        private int[] alturaDasColunas;

        #region Propriedades
        public Peca GetPeca(int lin,int col)
        {
            return pecas[lin, col];
        }
        public int Altura
        {
            get { return pecas.GetLength(0); }
        }
        public int Largura
        {
            get { return pecas.GetLength(1); }
        }
        #endregion

        public Tabuleiro()
        {
            this.pecas = new Peca[8, 8];
            this.alturaDasColunas = new int[8];
            for (int i = 0; i < this.Altura; i++)
            {
                this.alturaDasColunas[i] = 0;
            }
        }

        public bool colocarPeca(Peca peca,int col)
        {
            bool ok = false;
           
            //Se a coluna é válida

            if(col>=0 && col < this.Largura)
            {
                //Se coluna não tiver "Cheia"
                if (alturaDasColunas[col] < this.Altura)
                {
                    int lin = alturaDasColunas[col];
                    pecas[lin, col] = peca;
                    peca.Linha = lin;
                    peca.Coluna = col;
                    alturaDasColunas[col]++;
                    ok = true;
                }
            }

            return ok;
        }
    }
}

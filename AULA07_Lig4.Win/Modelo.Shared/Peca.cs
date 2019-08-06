using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Shared
{   public enum corPeca { Azul, Vermelho, Branca}

    public class Peca
    {
        public static int Tamanho = 40;
        #region Atributos
        private corPeca cor;
        private int linha;
        private int coluna;

        public corPeca Cor { get => cor; }
        public int Linha { get => linha; set => linha = value; }
        public int Coluna { get => coluna; set => coluna = value; }
        #endregion

        public Peca(corPeca _cor)
        {
            this.cor = _cor;
            this.linha = -1;
            this.coluna = -1;
        }
    }
}

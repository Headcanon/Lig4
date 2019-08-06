using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Modelo.Shared;
namespace Lig4.Win
{
    class DrawObjeto
    {
        public static void drawPeca(Peca peca, SpriteBatch sp, Texture2D textura)
        {
            int Linha = 7 * Peca.Tamanho - peca.Linha * Peca.Tamanho;
            int Coluna = peca.Coluna * Peca.Tamanho;

            Rectangle rect = new Rectangle(Coluna,Linha ,Peca.Tamanho, Peca.Tamanho);
            Color cor = Color.White;

            if (peca.Cor == corPeca.Azul)
            {
                cor = Color.Blue;
            }
            else if (peca.Cor == corPeca.Vermelho)
            {
                cor = Color.Red;
            }

            sp.Draw(textura, rect, cor);
        }

        public static void drawTabuleiro(Tabuleiro tabuleiro, SpriteBatch sp,
                                    Texture2D textura, SpriteFont fonte)
        {
            Peca fakePeca = new Peca(corPeca.Branca);

            if (tabuleiro != null)
            {
                for (int lin = 0; lin < tabuleiro.Altura; lin++)
                {
                    for (int col = 0; col < tabuleiro.Largura; col++)
                    {
                        Peca peca = tabuleiro.GetPeca(lin, col);
                        if (peca != null)
                        {
                            DrawObjeto.drawPeca(peca, sp, textura);
                        }else
                        {
                            fakePeca.Linha = lin;
                            fakePeca.Coluna = col;
                            DrawObjeto.drawPeca(fakePeca, sp, textura);
                        }
                    }
                }
                String texto = "   0  |  1   |  2   |  3  |  4  |  5  |  6   |  7  |";
                sp.DrawString(fonte, texto, new Vector2(0, 8 * Peca.Tamanho), Color.Yellow);
            }

        }
    }
}

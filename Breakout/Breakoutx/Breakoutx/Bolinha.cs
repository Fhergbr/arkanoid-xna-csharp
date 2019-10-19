using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Breakoutx
{
    
    public class Bolinha : Sprite_Grafico
    {
        int velocidadeHorizontal = 4;
        int velocidadeVertical = 4;

        public Bolinha(Color color,GraphicsDevice gd)
            : base(color, gd){ }
            public Bolinha(){ }

        public override void Atualizar()
        {
            int resultadoX = (int)this.localizacao.X + velocidadeHorizontal;
            int resultadoY = (int)this.localizacao.Y + velocidadeVertical;

            if (!(resultadoX >= Limite.X && resultadoX + this.Tamanho.X <= Limite.Width))
            {
                velocidadeHorizontal *= -1;
            }
           if (!(resultadoY >= Limite.Y && resultadoY + this.Tamanho.Y <= Limite.Height))
                {
                velocidadeVertical *= -1;
            }

            this.localizacao = new Vector2(resultadoX,resultadoY);
        }
            public void DetectarColisao(Sprite_Grafico objeto)
        {
            if (objeto is Jogar && objeto.Dimensao.Intersects(this.Dimensao))
            {
                this.velocidadeVertical *= -1;
            }
            else if (objeto is Ladrilho && objeto.Dimensao.Intersects(this.Dimensao)) 
            {
                this.velocidadeVertical *= -1;
                ((Ladrilho)objeto).Destruir();
            }

        }
        //
        public void vidas(Sprite_Grafico colisao)
        {
            if (colisao is paletafixa && colisao.Dimensao.Intersects(this.Dimensao))
            {
                this.velocidadeVertical = 0;
                this.velocidadeHorizontal = 0;
            }
        }


    }
}

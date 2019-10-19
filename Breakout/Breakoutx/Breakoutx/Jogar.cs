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
    public class Jogar : Sprite_Grafico
    {
        public Jogar() 
        {
        
        }
        public Jogar(Color color,GraphicsDevice gd)
            : base(color,gd)
        {
        
        }
        private int velocidade = 0;

       /* private int pontos;

        public int Pontos
        {
            get { return pontos; }
            
        }
        private int vidas;

        public int Vidas
        {
            get { return vidas; }

        }*/
        

        void Lerentrada() 
        {
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Left))
            {
                velocidade = -10;
            }
            else if (kb.IsKeyDown(Keys.Right))
            {
                velocidade = 10;
            }
            else
            {
                velocidade = 0;
            }

        }
        public override void Atualizar()
        {
            Lerentrada();
            
             // ARRUMAR AJUSTE DE TELA
             int resultado = (int)this.localizacao.X + velocidade;
             
            if(Limite.X <= resultado && Limite.X + Limite.Width >= resultado + this.Tamanho.X)
            
            {
                this.localizacao = new Vector2(resultado, this.localizacao.Y);
            } 
          //  this.localizacao = new Vector2((int)this.localizacao.X + velocidade, this.localizacao.Y);
         }

    }
}

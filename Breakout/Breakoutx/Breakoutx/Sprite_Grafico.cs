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
    public class Sprite_Grafico : Sprite
    {
        private Rectangle limite;

        public Rectangle Limite
        {
            get { return limite; }
            set { limite = value; }
        }

        public Sprite_Grafico()
        {

        }
        public Sprite_Grafico(Color color, GraphicsDevice gd)
        {
              textura = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
              textura.SetData<Color>(new Color[] { color });
        }

        private Texture2D textura;

        public Texture2D Textura
        {
            get { return textura; }
            set { textura = value; }
        }
        public override void Desenhar(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            Rectangle miLocalizacao = new Rectangle((int)this.localizacao.X, (int)this.localizacao.Y, (int)this.Tamanho.X, (int)this.Tamanho.Y);
            sb.Draw(textura, miLocalizacao, Color.White);
        }



        public override void Atualizar()
        {

        }
    } 
}

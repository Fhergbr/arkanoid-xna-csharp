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
    public class Ladrilho : Sprite_Grafico
    {
        public Ladrilho(Color color, GraphicsDevice gd)
            : base(color, gd) { }
        private bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private int resistencia;

        public int Resistencia
        {
            get { return resistencia; }
            set { resistencia = value; }
        }
        
        public void Destruir()
        {
            resistencia --;
   
            if (resistencia == 0)
            {
                this.visible = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Breakoutx
{
    public class paletafixa : Sprite_Grafico
    {
       public paletafixa() { }
       public paletafixa(Color color,GraphicsDevice dg)
            : base(color, dg)
        {

        }
    }
}
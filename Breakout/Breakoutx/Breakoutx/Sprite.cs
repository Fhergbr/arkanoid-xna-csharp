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
    public abstract class Sprite
    {
        public Rectangle Dimensao
        {
            get {
                return new Rectangle((int) this.localizacao.X, (int) this.localizacao.Y, (int) this.tamanho.X, (int) this.tamanho.Y);
            }
        
        
        }


        protected ContentManager content;
        protected Vector2 localizacao;
        public Vector2 Localizacao
        {
            get
            { return localizacao; }
            set
            { localizacao = value; }
        }
        private Vector2 tamanho;

        public Vector2 Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        public int CentroX
        { 
            get
            {
                return (int)(localizacao.X + (localizacao.X + tamanho.X))/2;
            }
        }
        public int CentroY
        {
            get
            {
                return (int)(localizacao.Y + (localizacao.Y + tamanho.Y)) / 2;
            }
        }
        public abstract void Desenhar(SpriteBatch sb);

        public abstract void Atualizar();

        public void CarregarContent(ContentManager cm) 
        {
            content = cm;
        }

    }
}

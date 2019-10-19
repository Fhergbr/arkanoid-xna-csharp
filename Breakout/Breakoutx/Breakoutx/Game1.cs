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

    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public enum State
        {
            Menu,
            Jogar,
            GameOver
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont Fonte;
        SpriteFont Fonte2;
        int contador = 0;
        int contador2 = 0;
      

        paletafixa fixa = new paletafixa();
        paletafixa fixa2 = new paletafixa(); 

        
        Song somfundo;
        Song zoeira;
        Sprite_Grafico fundo;       


        Jogar jogador;
        Bolinha bolinha;
        List<Ladrilho> ladrilhos = new List<Ladrilho>();

        State gameState = State.Menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


            
            Fonte = Content.Load<SpriteFont>("Font1");
            Fonte2 = Content.Load<SpriteFont>("Font2");

           
            somfundo = Content.Load<Song>("Fundomusical");
            zoeira = Content.Load<Song>("zoeira");
            MediaPlayer.Play(zoeira);
            //MediaPlayer.Play(somfundo);

            fundo = new Sprite_Grafico(Color.DarkSlateBlue, GraphicsDevice);
            fundo.Tamanho = new Vector2(this.GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Height - 20);
            fundo.Localizacao = new Vector2(10, 10);
            fundo.CarregarContent(Content);

            fixa = new paletafixa(Color.DarkSlateBlue, GraphicsDevice);
            fixa.CarregarContent(Content);
            fixa.Tamanho = new Vector2(480,1); 
            fixa.Localizacao = new Vector2(10,460);


            jogador = new Jogar(Color.White, GraphicsDevice);
            jogador.CarregarContent(Content);
            jogador.Tamanho = new Vector2(70, 1);
            jogador.Localizacao = new Vector2(fundo.CentroX, fundo.Tamanho.Y - 15);
            jogador.Limite = fundo.Dimensao;

            bolinha = new Bolinha(Color.Red, GraphicsDevice);
            bolinha.CarregarContent(Content);
            bolinha.Tamanho = new Vector2(8, 8);
            bolinha.Localizacao = new Vector2(10,120);
            bolinha.Limite = fundo.Dimensao;

            DesenharLadrilhos();
        }


        protected override void UnloadContent()
        {
             
        }
        protected override void Update(GameTime gameTime)
        {
           
            switch (gameState)
            {
                case State.Jogar:
                    {
                        jogando();
                        KeyboardState keyState = Keyboard.GetState();
                        if (keyState.IsKeyDown(Keys.Escape))
                        {
                            gameState = State.GameOver;
                            MediaPlayer.Pause();
                        }
                            break;
                    }
                case State.Menu:
                    {
                        KeyboardState keyState = Keyboard.GetState();
                        if (keyState.IsKeyDown(Keys.Enter))
                        {
                            gameState = State.Jogar;
                            MediaPlayer.Play(somfundo);
                        }
                        break;
                    }
                case State.GameOver:
                    {
                        KeyboardState keyState = Keyboard.GetState();
                        
                        if (keyState.IsKeyDown(Keys.Enter))
                        {
                            base.Update(gameTime);
                            gameState = State.Jogar;
                            MediaPlayer.Play(somfundo);


                        }
                            break;
                    }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();          
            fundo.Desenhar(spriteBatch);


            if (gameState == State.GameOver)
            {
                
                spriteBatch.DrawString(Fonte2, "Pressione para continuar", new Vector2(60, 270), Color.White);
            }                
            if(gameState == State.Menu)
            {
                telaMenu();
            }
            if (gameState == State.Jogar)
            {
                spriteBatch.DrawString(Fonte, "Pause ( Esc )  ", new Vector2(550, 30), Color.White);
                spriteBatch.DrawString(Fonte, "Pontos " + contador.ToString(), new Vector2(550, 200), Color.White);
                spriteBatch.DrawString(Fonte, "Stage 1 ", new Vector2(550, 250), Color.White);
                if (contador2 == 1)
                {
                    spriteBatch.DrawString(Fonte, "You Win!!", new Vector2(200, 270), Color.Red);
                }
            }
              fixa.Desenhar(spriteBatch);
              jogador.Desenhar(spriteBatch);
              bolinha.Desenhar(spriteBatch);

                        foreach (Ladrilho ladrilho in ladrilhos)
                            {
                                ladrilho.Desenhar(spriteBatch);
                            }

            if (contador2 == 1)
                        {
                            foreach(Ladrilho ladrilho in ladrilhos)
                                {
                                    ladrilho.Desenhar(spriteBatch);
                                }
                        }
            spriteBatch.End();

            base.Draw(gameTime);
        }
        void Liberar()
        {
            for (int ind = ladrilhos.Count - 1; ind >= 0; ind--)
            {
                if (!ladrilhos[ind].Visible)
                {
                    ladrilhos.Remove(ladrilhos[ind]);
                    contador += 10;
                }else if(ladrilhos.Count == 0)
                {
                    contador2 = 1;
                }
            }
        }
        void DesenharLadrilhos()
        {
            int tamanhoLadrilho = (int)(fundo.Dimensao.Width / 20);
            for (int i = 0; i < 20; i++)
            {
                Ladrilho ladrilho = new Ladrilho(Color.BlueViolet, GraphicsDevice);
                ladrilho.CarregarContent(Content);
                ladrilho.Tamanho = new Vector2(tamanhoLadrilho, 20);
                ladrilho.Localizacao = new Vector2(ladrilhos.Count * tamanhoLadrilho + 10, 10);
                ladrilhos.Add(ladrilho);
                ladrilho.Resistencia = 1;

            }
            for (int i = 0; i < 20; i++)
            {
                Ladrilho ladrilho2 = new Ladrilho(Color.Yellow, GraphicsDevice);
                ladrilho2.CarregarContent(Content);
                ladrilho2.Tamanho = new Vector2(tamanhoLadrilho, 20);
                ladrilho2.Localizacao = new Vector2(ladrilhos.Count * tamanhoLadrilho + -470, 31);
                ladrilhos.Add(ladrilho2);
                ladrilho2.Resistencia = 1;
            }
            for (int i = 0; i < 20; i++)
            {
                Ladrilho ladrilho3 = new Ladrilho(Color.Red, GraphicsDevice);
                ladrilho3.CarregarContent(Content);
                ladrilho3.Tamanho = new Vector2(tamanhoLadrilho, 20);
                ladrilho3.Localizacao = new Vector2(ladrilhos.Count * tamanhoLadrilho + -950, 52);
                ladrilhos.Add(ladrilho3);
                ladrilho3.Resistencia = 1;
            }
            for (int i = 0; i < 20; i++)
            {
                Ladrilho ladrilho4 = new Ladrilho(Color.Green, GraphicsDevice);
                ladrilho4.CarregarContent(Content);
                ladrilho4.Tamanho = new Vector2(tamanhoLadrilho, 20);
                ladrilho4.Localizacao = new Vector2(ladrilhos.Count * tamanhoLadrilho + -1430, 73);
                ladrilhos.Add(ladrilho4);
                ladrilho4.Resistencia = 1;
            }
            for (int i = 0; i < 20; i++)
            {
                Ladrilho ladrilho5 = new Ladrilho(Color.Tomato, GraphicsDevice);
                ladrilho5.CarregarContent(Content);
                ladrilho5.Tamanho = new Vector2(tamanhoLadrilho, 20);
                ladrilho5.Localizacao = new Vector2(ladrilhos.Count * tamanhoLadrilho + -1910, 94);
                ladrilhos.Add(ladrilho5);
                ladrilho5.Resistencia = 1;
            }
        }
        void jogando()
        {
            fixa.Atualizar();
            jogador.Atualizar();
            bolinha.Atualizar();
            bolinha.DetectarColisao(jogador);
            bolinha.vidas(fixa);

            foreach (Ladrilho ladrilho in ladrilhos)
            {
                bolinha.DetectarColisao(ladrilho);
            }
            Liberar();
           
        }
        void telaMenu()
        {
            spriteBatch.DrawString(Fonte, "Pressione Enter ", new Vector2(160,230), Color.White);
            spriteBatch.DrawString(Fonte, "para comecar", new Vector2(170, 270), Color.White);
        }
    }
}

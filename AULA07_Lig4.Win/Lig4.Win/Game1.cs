using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Modelo.Shared;

namespace Lig4.Win
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Peca peca;
        Texture2D texturaPeca;
        Tabuleiro tabuleiro;
        SpriteFont fonteArial;
        int coluna = -1;
        bool keypressed = false;
        corPeca[] jogador;
        int jogadorAtual;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            peca = new Peca(corPeca.Azul);
            peca.Coluna = 5;
            peca.Linha = 4;
            tabuleiro = new Tabuleiro();
            jogador = new corPeca[2];
            jogador[0] = corPeca.Azul;
            jogador[1] = corPeca.Vermelho;
            jogadorAtual = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texturaPeca = Content.Load<Texture2D>("Peca");
            fonteArial = Content.Load<SpriteFont>("Arial");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            requisitarJogada();

            if (coluna != -1 && !keypressed)
            {
                peca = new Peca(jogador[jogadorAtual]);
                if (tabuleiro.colocarPeca(peca, coluna))
                {
                    jogadorAtual = (jogadorAtual + 1) % 2;
                    coluna = -1;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //DrawObjeto.drawPeca(peca, spriteBatch, texturaPeca);
            DrawObjeto.drawTabuleiro(tabuleiro, spriteBatch, texturaPeca, fonteArial);
            spriteBatch.DrawString(fonteArial, "Jogador Atual:" + jogador[jogadorAtual].ToString(),
                                   new Vector2(0, 9 * Peca.Tamanho), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void requisitarJogada()
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.GetPressedKeys().Length == 0)
            {
                keypressed = false;
            }

            if (keys.IsKeyDown(Keys.D0)) { keypressed = true; coluna = 0; }
            else if (keys.IsKeyDown(Keys.D1)) { keypressed = true; coluna = 1; }
            else if (keys.IsKeyDown(Keys.D2)) { keypressed = true; coluna = 2; }
            else if (keys.IsKeyDown(Keys.D3)) { keypressed = true; coluna = 3; }
            else if (keys.IsKeyDown(Keys.D4)) { keypressed = true; coluna = 4; }
            else if (keys.IsKeyDown(Keys.D5)) { keypressed = true; coluna = 5; }
            else if (keys.IsKeyDown(Keys.D6)) { keypressed = true; coluna = 6; }
            else if (keys.IsKeyDown(Keys.D7)) { keypressed = true; coluna = 7; }

        }
    }
}

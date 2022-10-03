using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lab03
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        Texture2D myTexture;
        Vector2 spritePosition = Vector2.Zero;
        int frame = 3;
        Texture2D cloudTexture;
        Vector2[] scaleCloud;
        Vector2[] cloudPos;
        int[] speed;
        Random r = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("NatureSprite");
            cloudTexture = Content.Load<Texture2D>("Cloud_sprite");
            // TODO: use this.Content to load your game content here
            cloudPos = new Vector2[4];
            scaleCloud = new Vector2[4];
            speed = new int[4];



            for (int i = 0; i < 4; i++)
            {
                cloudPos[i].Y = r.Next(0, GraphicsDevice.Viewport.Height - cloudTexture.Height);
                scaleCloud[i].X = r.Next(1, 3);
                scaleCloud[i].Y = scaleCloud[i].X;
                speed[i] = r.Next(3, 7);
            }

        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < 4; i++)
            {
                cloudPos[i].X = cloudPos[i].X + speed[i];
                if (cloudPos[i].X > _graphics.GraphicsDevice.Viewport.Width)
                {
                    cloudPos[i].X = 0;
                    cloudPos[i].Y = r.Next(0, GraphicsDevice.Viewport.Height - cloudTexture.Height);
                    scaleCloud[i].X = r.Next(1, 3);
                    scaleCloud[i].Y = scaleCloud[i].X;
                }
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(85, 133, 50));
            spriteBatch.Begin();
            // small tree
            spriteBatch.Draw (myTexture, new Vector2(64*3,64*3), new Rectangle(64 *1, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*3,64*4), new Rectangle(64 * 1, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*3,64*5), new Rectangle(64 * 1, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*8, 64 * 3), new Rectangle(64 * 1, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*8, 64 * 4), new Rectangle(64 * 1, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*8, 64 * 5), new Rectangle(64 * 1, 0, 64, 64), Color.White);
            //Big tree
            spriteBatch.Draw (myTexture, new Vector2(64*4, 0), new Rectangle(64 *4,64*2 , 64*4, 64*4), Color.White);         
            //M Tree
            spriteBatch.Draw(myTexture, new Vector2(64*1,64*5), new Rectangle(64 * 2, 64 * 4, 64 * 2, 64 *2), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*9,64*5), new Rectangle(64 * 2, 64 * 4, 64 * 2, 64 * 2), Color.White);
            //Sm tree
            spriteBatch.Draw(myTexture, new Vector2(64*3,64*6), new Rectangle(64*0,64*0,64,64 ), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*8,64*6), new Rectangle(64 * 0, 64 * 0, 64, 64), Color.White);
            //flower
            spriteBatch.Draw(myTexture, new Vector2(64*6,64*6), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*6,64*5), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*6,64*4), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*5,64*6), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64*5,64*5), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(64 * 5, 64 * 4), new Rectangle(64 * 3, 64 * 3, 64, 64), Color.White);
            //Sign
            spriteBatch.Draw(myTexture, new Vector2(64*4,64*6), new Rectangle(64*0,64*1,64,64), Color.White);
            //cloud

            {
            }                    
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }    
}
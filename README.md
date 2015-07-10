#Battle Pong

This game is a twist on the classic game Pong. The twist is that the players can earn bullets to shoot the opposing player.

### How is the bullet gained

The bullet is earned when the player hits the ball 2 times during a run, so if the ball goes out then the player will not
receive a bullet. When a player earns a point they also earn a bullet

### About The engine

The game will be created in C# by using a framework called [monogame](https://github.com/mono/MonoGame) which is an open source port of Microsofts XNA. The physics will be very basic and not include things like rotation.

### Graphics

The game does not require any complex graphical work, all the sprites are colours resized to form the shapes.

### Sound

The sound effects are very minimal, simple beeps when the ball is hit or a shot is fired. The shooting effect is from Kenny's asset pack

The engine
==

### GameObject [Link](https://github.com/EverlessDrop41/MonoPong/blob/master/MonoPong/Objects/GameObject.cs)

This is the basic object for all the things in my game

All object have the following Variables:
  - Position `Microsoft.Xna.Framework.Vector2`
  - Size `Microsoft.Xna.Framework.Vector2`
  - Texture (Sprite) `Microsoft.Xna.Framework.Graphics.Texture2D`

And the following methods
  - Constructor `GamObject()` and `GameObject (Vector2 _Position, Vector2 _Size)`
  - Start `virtual void Start()` - Called when the object is created
  - Update `virtual void Update(GameTime time)` - Called in MonoGames update function
  - Draw `virtual void Draw(SpriteBatch spriteBatch, GameTime time)`
  - GetRect `Rectangle GetRect()` - Returns a rectangle by combining `Position` and `Size`
  - SetFromRect `void SetFromRect(Rectangle Rect)` - The opposite of `GetRect`

In the methods some of them have the `virtual` keyword is used. This allows the method to be overriden by inherriting classes. Using this feature when can then go on to create the ball and bat objects

### Level [Link](https://github.com/EverlessDrop41/MonoPong/blob/master/MonoPong/Levels/Level.cs)

This class defines the basic variables and methods that are needed for a level in the game. The levels in this game are:
 - Main Menu
 - Instructions (Planned)
 - Gameplay
 - Game Over
 
It uses the following methods: 
 - Intialize `public virtual void Intialize()` - The method to set up all the required content for the game, a bit like a secondary contructor.
 - LoadContent `public virtual void LoadContent()` - The method to load all of the required content
 - UnloadContent `public virtual void UnloadContent()` - The method to unload any content that is not loaded using the content manager
 - Update `public virtual void Update(GameTime gameTime)` - This method is called on every frame, it should handle user input and physics.
 - Draw `public virtual void Update(GameTime gameTime)` - This method draws the level and all that is in it.

As you may have noticed, a level uses very similar methods to an `MonoGame` Game class, this is because the levels are creating using a state manger. The state manage lists all of the levels and then decides which ones to call `Update` and `Draw` on. All levels have `Initialize`, `LoadContent` and `UnloadContent` called because they do not effect the gameplay. As the game scales it may be praticle to seperate the content loading method to when a level is switched to. Due to this state manging system, the class will only need one variable, which is the game: `public Pong Game`

The state is manged by a `public enum GameState`, this is a list of all the possible level types and needs to be updated if a new level is added.
 
### Bat (Paddle) [Link](https://github.com/EverlessDrop41/MonoPong/blob/master/MonoPong/Objects/Bat.cs)

This object is the paddle the the player controls, it inherits from `GameObject`

It overrides the following methods:
  - Draw
  - Update

It uses 3 extra variables
 - UpKey `public Keys` - The key that is pressed to move the paddle up
 - DownKey `public Keys` - The key that is pressed to move the paddle down
 - Speed `public float` - The speed the bat should move at

There are new constructors to utilise these variables

### Ball [Link](https://github.com/EverlessDrop41/MonoPong/blob/master/MonoPong/Objects/Ball.cs)

This is the ball that gets hit by the paddle. Currently it is the only object which handles collisions, this is because it is the only object that needs to move according to physics. It inherits from `GameObject`

The physics are very rough, and made to be slightly unrealisitic to make the game more enjoyable and randomised. When a bat hits the ball the x direction is reversed, and the Y direction either goes up or down based on a R.N.G.

It overrides the following methods: 
 - Update
   - New Parameters it take are `GraphicsDeviceManager graphics` and `GameObject[] toCollideWith`
 - Draw

It uses the following variables:
  - MAX_SPEED `public const float` - This is needed to keep the speed reasonable

Evaluation
===

The following text will describe how I feel the project went and if I were to do the project again what I would change and do differently. The main purpose of the project was to learn how to use the framework `MonoGame`.

#### Positives

I  would say that the best feature of BattlePong is the expand-ability that the project offers, when making it I tried to make a basic game engine behind it and this was useful when working on the later stages of the game. Another thing I am happy with is that I used version control (`git`) a lot more than I usually do.

#### Negatives / Improvements

Despite the basic engine classes I made at the start I also lacked some useful knowledge when I started that meant at the later stages of development code would often be hacky or poorly optimised. So next time I would think more about where I want to take the project at the start, thus allowing me to build a better engine. Another one of the weaknesses in the game is physics, this is where most of the time was spent and is infact the hackiest part of the code, so if I were to redo theproject I would think more about how I want to implement physics

#### Conclusion 

I enjoyed working on this project and found it tobe a useful and enjoyable exercise. While I may not want to make this game again, at least in this framework, I would like to do more projects that use MonoGame

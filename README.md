#Battle Pong

This game is a twist on the classic game Pong. The twist is that the players can earn bullets to shoot the opposing player.

### How is the bullet gained

The bullet is earned when the player hits the ball 2 times during a run, so if the ball goes out then the player will not
receive a bullet. When a player earns a point they also earn a bullet

### The engine

The game will be created in C# by using a framework called [monogame](https://github.com/mono/MonoGame) which is an open source port of Microsofts XNA. The physics will be very basic and not include things like rotation.

### Graphics

The game does not require any complex graphical work, all the sprites are colours resized to form the shapes.

### Sound

The sound effects are very minimal, simple beeps when the ball is hit or a shot is fired.

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
  - MAX_SPEED `public const float` This is needed to keep the speed reasonable

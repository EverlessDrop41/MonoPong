#Battle Pong

This game is a twist on the classic game Pong. The twist is that the players can earn bullets to shoot the opposing player.

How is the bullet gained
--
The bullet is earned when the player hits the ball 2 times during a run, so if the ball goes out then the player will not
receive a bullet. When a player earns a point they also earn a bullet

The engine
--
The game will be created in C# by using a framework called [monogame](https://github.com/mono/MonoGame) which is an open source port of Microsofts XNA. The physics will be very basic and not include things like rotation.

Graphics
--
The game does not require any complex graphical work, all the sprites are colours resized to form the shapes.

Sound
--
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
  - Constructor `new GamObject()` and `GameObject (Vector2 _Position, Vector2 _Size)`

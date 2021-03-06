using Godot;
using System;

public class Player : Area2D
{
	[Export]
	public int speed = 400;
	private Vector2 _screenSize;
	public override void _Ready()
	{
		_screenSize = GetViewport().Size;
	}
	
	public override void _Process(float delta)
	{	
		var velocity = new Vector2();
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x += 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= 1;
   	 	}

		if (Input.IsActionPressed("ui_down"))
		{
			velocity.y += 1;
		}

		if (Input.IsActionPressed("ui_up"))
		{
			velocity.y -= 1;
		}
		
		var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		
		if(velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * speed;
			animatedSprite.Play();
		}
		
		else
		{
			animatedSprite.Stop();
		}
		Position += velocity * delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.x, 0, _screenSize.x),
			y: Mathf.Clamp(Position.x, 0, _screenSize.y)
		);
	}
}

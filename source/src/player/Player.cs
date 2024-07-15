using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		base._Ready();

		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (animatedSprite == null)
			GD.PrintErr("AnimatedSprite2D node not found.");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
			animatedSprite.Play("walk");
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			animatedSprite.Play("idle");
		}

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			animatedSprite.Play("jump");
		}


		Velocity = velocity;
		FlipSpriteByDirection();
		MoveAndSlide();
	}

	private void FlipSpriteByDirection()
	{
		if (Velocity.X < 0)
			animatedSprite.Scale = new Vector2(-1, 1);
		else if (Velocity.X > 0)
			animatedSprite.Scale = new Vector2(1, 1);
	}
}

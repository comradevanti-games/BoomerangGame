using Godot;

public partial class PlayerMovement : CharacterBody2D {

	[Export] public float Speed = 300.0f;
	[Export] public float JumpVelocity = -400.0f;
	[Export] public float DoubleJumpVelocity = -200.0f;
	[Export] public AnimatedSprite2D PlayerAnimationSprite;

	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private bool HasDoubleJumped { get; set; }
	private bool IsInAir { get; set; }

	public override void _PhysicsProcess(double delta) {

		Vector2 velocity = Velocity;

		if (IsInAir) {
			if (IsOnFloor()) {
				IsInAir = false;
				HasDoubleJumped = false;
			}
		}

		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}

		if (Input.IsActionJustPressed("ui_accept")) {

			if (IsOnFloor()) {
				velocity.Y = JumpVelocity;
				IsInAir = true;
			}

			if (!IsOnFloor() && !HasDoubleJumped) {
				velocity.Y = DoubleJumpVelocity;
				HasDoubleJumped = true;
			}

		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
			PlayerAnimationSprite.FlipH = !(direction.X > 0);
		}
		else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		HandlePlayerAnimation();
		MoveAndSlide();

	}

	private void HandlePlayerAnimation() {

		if (Velocity.X != 0) {
			if (IsOnFloor()) {
				PlayerAnimationSprite.Play("Run");
			}
		}

		if (!IsOnFloor()) {
			PlayerAnimationSprite.Play(Velocity.Y < 0 ? "Jump" : "Fall");
		}

		if (Velocity == Vector2.Zero) {
			PlayerAnimationSprite.Play("Idle");
		}
	}

}
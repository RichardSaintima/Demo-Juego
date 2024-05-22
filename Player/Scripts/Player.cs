using Godot;
using System;

public partial class Player : CharacterBody3D
{
    // Parámetros de movimiento
    [Export] public float Speed = 10.0f;
    [Export] public float JumpForce = 10.0f;
    [Export] public float Gravity = -9.8f;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        // Aplicar gravedad
        if (!IsOnFloor())
        {
            Velocity += new Vector3(0, Gravity * (float)delta, 0);
        }

        // Detectar entrada del jugador
        Vector3 inputVector = new Vector3();
        if (Input.IsActionPressed("move_right"))
        {
            inputVector.X += 1;
        }
        if (Input.IsActionPressed("move_left"))
        {
            inputVector.X -= 1;
        }
        if (Input.IsActionPressed("move_forward"))
        {
            inputVector.Z -= 1;
        }
        if (Input.IsActionPressed("move_backward"))
        {
            inputVector.X += 1;
        }

        // Movimiento horizontal
        Vector3 direction = inputVector.Normalized();
        Velocity = new Vector3(direction.X * Speed, Velocity.Y, direction.Z * Speed);

        // Salto
        if (Input.IsActionJustPressed("ui_jump") && IsOnFloor())
        {
            Velocity = new Vector3(Velocity.X, JumpForce, Velocity.Z);
        }

        // Aplicar movimiento
        MoveAndSlide();

        // Verificar si el jugador está en el suelo
        if (IsOnFloor())
        {
            Velocity = new Vector3(Velocity.X, 0, Velocity.Z); // Resetear la velocidad en Y al tocar el suelo
        }
    }
}

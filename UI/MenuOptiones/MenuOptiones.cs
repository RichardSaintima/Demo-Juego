using Godot;
using System;

public partial class MenuOptiones : Control
{
    private Button exitButton;

    public override void _Ready()
    {
        // Obtener referencia al botón de salir
        exitButton = GetNode<Button>("ControlBoton/Botones/Exit");
        
        // Conectar la señal del botón de salir a la función OnExitPressed
        exitButton.Pressed += OnExitPressed;
    }

    private void OnExitPressed()
    {
        GD.Print("Cerrar menú de opciones");
        QueueFree(); // Eliminar el menú de opciones
    }
}

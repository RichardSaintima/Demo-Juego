using Godot;
using System;

public partial class NewGame : Node
{
    private MenuPausa _pauseMenu;

    public override void _Ready()
    {
        // Obtener la referencia al nodo MenuPausa
        _pauseMenu = GetNode<MenuPausa>("MenuPausa");

        // Asegúrate de que el menú de pausa esté oculto al inicio
        if (_pauseMenu != null)
        {
            _pauseMenu.Visible = false;
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_cancel"))
        {
            if (_pauseMenu != null)
            {
                if (_pauseMenu.Visible)
                {
                    _pauseMenu.OnResumePressed();
                }
                else
                {
                    _pauseMenu.ShowPauseMenu();
                }
            }
        }
    }
}
using Godot;
using System;

public partial class MenuPausa : Control
{
    private Button _resumeButton;
    private Button _saveGameButton;
    private Button _optionsButton;
    private Button _mainMenuButton;

    public override void _Ready()
    {
        // Obtener referencias a los botones
        _resumeButton = GetNode<Button>("ControlBoton/Botones/Resume");
        _saveGameButton = GetNode<Button>("ControlBoton/Botones/SaveGame");
        _optionsButton = GetNode<Button>("ControlBoton/Botones/Options");
        _mainMenuButton = GetNode<Button>("ControlBoton/Botones/MainMenu");

        // Conectar las señales de los botones a las funciones
        _resumeButton.Pressed += OnResumePressed;
        _saveGameButton.Pressed += OnSaveGamePressed;
        _optionsButton.Pressed += OnOptionsPressed;
        _mainMenuButton.Pressed += OnMainMenuPressed;

        // Asegúrate de que el menú de pausa esté oculto al inicio
        this.Visible = false;
    }

    public void OnResumePressed()
    {
        GD.Print("Reanudar seleccionada");
        GetTree().Paused = false;
        this.Visible = false;
    }

    public void OnSaveGamePressed()
    {
        GD.Print("Guardar Partida seleccionada");
        // Aquí puedes agregar la lógica para guardar la partida
    }

    public void OnOptionsPressed()
    {
        GD.Print("Configuracion seleccionada");
        // Aquí puedes agregar la lógica para mostrar las opciones
    }

    public void OnMainMenuPressed()
    {
        GD.Print("Menu Principal seleccionada");
        GetTree().Paused = false; // Asegúrate de despausar antes de cambiar de escena
        GetTree().ChangeSceneToFile("res://UI/MenuPrincipal/MenuPrincipal.tscn");
    }

    public void ShowPauseMenu()
    {
        GetTree().Paused = true;
        this.Visible = true;
    }
}
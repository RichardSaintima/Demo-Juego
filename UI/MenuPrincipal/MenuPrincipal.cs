using Godot;
using System;

public partial class MenuPrincipal : Control
{
    // Referencias a los botones
    private Button newGameButton;
    private Button continueButton;
    private Button optionsButton;
    private Button exitButton;
    private Control optionsMenu;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Obtén referencias a los botones bajo el nodo "Botones"
        newGameButton = GetNode<Button>("ControlBoton/Botones/Newgame");
        continueButton = GetNode<Button>("ControlBoton/Botones/Continue");
        optionsButton = GetNode<Button>("ControlBoton/Botones/Options");
        exitButton = GetNode<Button>("ControlBoton/Botones/Exit");

        // Conecta las señales de los botones a las funciones
        newGameButton.Pressed += OnNewGamePressed;
        continueButton.Pressed += OnContinuePressed;
        optionsButton.Pressed += OnOptionsPressed;
        exitButton.Pressed += OnExitPressed;
    }

    private void OnNewGamePressed()
    {
        GD.Print("Nueva Partida seleccionada");
        // Aquí puedes cargar la escena de nueva partida
        GetTree().ChangeSceneToFile("res://Scenes/NewGame/NewGame.tscn");
    }

    private void OnContinuePressed()
    {
        GD.Print("Continuar seleccionada");
        // Aquí puedes cargar la partida guardada
        // Ejemplo: LoadGame();
    }

    private void OnOptionsPressed()
    {
        GD.Print("Opciones seleccionada");
        // Aquí puedes instanciar y mostrar el menú de opciones
        var optionsScene = (PackedScene)GD.Load("res://UI/MenuOptiones/MenuOptiones.tscn");
        var instantiatedOptionsMenu = (Control)optionsScene.Instantiate();
        AddChild(instantiatedOptionsMenu);  // Añade el menú de opciones a la jerarquía actual
        instantiatedOptionsMenu.Visible = true;
    }

    private void OnExitPressed()
    {
        GD.Print("Salir seleccionada");
        // Aquí puedes salir del juego
        GetTree().Quit();
    }
}

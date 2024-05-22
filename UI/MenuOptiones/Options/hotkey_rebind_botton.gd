extends Control

@onready var label = $HBoxContainer/Label as Label
@onready var boton = $HBoxContainer/Button as Button

@export var action_name : String = "move_left"

# Called when the node enters the scene tree for the first time.
func _ready():
	set_process_unhandled_key_input(false)
	set_action_name()
	set_text_for_key()

func set_action_name() -> void:
	label.text = "Unassigned"
	
	match action_name:
		"move_left":
			label.text = "Move Left"
		"move_right":
			label.text = "Move Right"
		"move_forward":
			label.text = "Move Forward"
		"move_backward":
			label.text = "Move Backward"
		"ui_jump":
			label.text = "Jump"
		"ui_crouch":
			label.text = "Crouch"
		"ui_sprint":
			label.text = "Sprint"
		"ui_inventory":
			label.text = "Inventory"
		"ui_interact":
			label.text = "Interact"
		"ui_cancel":
			label.text = "Cancel"

func set_text_for_key() -> void:
	var action_events = InputMap.action_get_events(action_name)
	if action_events.size() > 0:
		var action_event = action_events[0]
		var action_keycode = OS.get_keycode_string(action_event.physical_keycode)
		boton.text = "%s" % action_keycode
	else:
		boton.text = "No key assigned"

func _on_button_toggled(button_pressed):
	if button_pressed:
		boton.text = "Press a key..."
		set_process_unhandled_key_input(button_pressed)
		
		for i in get_tree().get_nodes_in_group("hotkey_button"):
			if i.action_name != self.action_name:
				i.boton.toggle_mode = false
				i.set_process_unhandled_key_input(false)
	else: 
		for i in get_tree().get_nodes_in_group("hotkey_button"):
			if i.action_name != self.action_name:
				i.boton.toggle_mode = true
				i.set_process_unhandled_key_input(false)
				
		set_text_for_key()

func _unhandled_key_input(event):
	rebind_action_key(event)
	boton.button_pressed = false

func rebind_action_key(event) -> void:
	InputMap.action_erase_events(action_name)
	InputMap.action_add_event(action_name, event)
	
	set_process_unhandled_key_input(false)
	set_text_for_key()
	set_action_name()

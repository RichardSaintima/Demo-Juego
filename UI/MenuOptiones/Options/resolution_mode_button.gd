extends Control


@onready var option_button = $HBoxContainer/OptionButton as OptionButton

const RESOLUTION_DICTIONARY : Dictionary = {
	"1152 x 648" : Vector2i(1152, 648),
	"1280 x 720" : Vector2i(1280, 720),
	"1366 x 768" : Vector2i(1366, 768),
	"1440 x 900" : Vector2i(1440, 900),
	"1600 x 900" : Vector2i(1600, 900),
	"1680 x 1050" : Vector2i(1680, 1050),
	"1920 x 1080" : Vector2i(1920, 1080),
	"2560 x 1440" : Vector2i(2560, 1440),
	"3840 x 2160" : Vector2i(3840, 2160)
}


# Called when the node enters the scene tree for the first time.
func _ready():
	add_windows_mode_items()
	option_button.item_selected.connect(on_resolution_selected)


func add_windows_mode_items() -> void:
	for resolution_size in RESOLUTION_DICTIONARY:
		option_button.add_item(resolution_size)
		

func on_resolution_selected(index : int) -> void:
	DisplayServer.window_set_size(RESOLUTION_DICTIONARY.values()[index])

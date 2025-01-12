extends Node

var is_player_in_water
var can_breathe

var last_is_player_in_water
var last_can_breathe


# Called when the node enters the scene tree for the first time.
func _ready():
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if last_is_player_in_water!= is_player_in_water or last_can_breathe!=can_breathe:
		print(is_player_in_water)
		last_is_player_in_water = is_player_in_water
		print(can_breathe)
		last_can_breathe=can_breathe
		print("\n")
	pass

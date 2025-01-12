extends Node

signal player_entered_water
signal player_exited_water

var is_player_in_water = false
var can_breathe = false
var last_checkpoint_pos = null


# Called when the node enters the scene tree for the first time.
func _ready():
	#player_entered_water.connect(func(): is_player_in_water=true; print("Player in water"))
	#player_exited_water.connect(func(): is_player_in_water=false; print("Player out of water"))
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	
	pass

extends CharacterBody2D

@export var final_position_marker: Marker2D
@export var speed: float = 100
@export var leverscript : Node

@onready var final_position = final_position_marker.global_position

var inicial_position
var is_button_pressed = false


# Called when the node enters the scene tree for the first time.
func _ready():
	if final_position == null:
		final_position = global_position
	inicial_position = global_position
	#leverscript.PushedLever.connect(_move_plataform_lever())
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if is_button_pressed:
		if global_position!=final_position:
			velocity = speed * (final_position - global_position).normalized()
			move_and_slide()
		elif velocity!=Vector2(0, 0):
			velocity = Vector2(0, 0)
			move_and_slide()
	else:
		if global_position!=inicial_position:
			velocity = speed * (inicial_position - global_position).normalized()
			move_and_slide()
		elif velocity!=Vector2(0, 0):
			velocity = Vector2(0, 0)
			move_and_slide()
	pass
'''
func _move_plataform_lever():
	is_button_pressed = !is_button_pressed
'''

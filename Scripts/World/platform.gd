extends RigidBody2D

@export var final_position_marker: Marker2D
@export var speed: float = 100
@export var leverscript : Node

@onready var final_position

var inicial_position
var is_button_pressed = false

# Called when the node enters the scene tree for the first time.
func _ready():
	freeze_mode=1
	if final_position_marker:
		final_position = final_position_marker.global_position
	if final_position == null:
		final_position = global_position
	inicial_position = global_position
	#leverscript.PushedLever.connect(_move_plataform_lever())
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if is_button_pressed:
		if global_position!=final_position:
			if freeze:
				freeze=false
			apply_central_impulse(speed * (final_position - global_position).normalized())
			for body in $Area2D.get_overlapping_bodies():
				if body!=self:
					body.global_position+=Vector2(0,5)
		elif !freeze:
			freeze=true
	else:
		if global_position!=inicial_position:
			if freeze:
				freeze=false
			apply_central_impulse(speed * (inicial_position - global_position).normalized())
			for body in $Area2D.get_overlapping_bodies():
				if body!=self:
					body.global_position+=Vector2(0,5)
		elif !freeze:
			freeze=true
	pass
'''
func _move_plataform_lever():
	is_button_pressed = !is_button_pressed
'''

extends CharacterBody2D

@export var final_position_marker: Marker2D
@export var speed: float = 100
@export var leverscript : Node

@onready var final_position

var inicial_position
var is_button_pressed = false

# Called when the node enters the scene tree for the first time.
func _ready():
	motion_mode=1
	if final_position_marker:
		final_position = final_position_marker.global_position
	if final_position == null:
		final_position = global_position
	inicial_position = global_position
	#leverscript.PushedLever.connect(_move_plataform_lever())
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if !stop():
		if is_button_pressed:
			if !approx_vector2(global_position, final_position):
				velocity = (speed * (final_position - global_position).normalized())
				adjust_velocity()
				move_and_slide()
			elif velocity!=Vector2(0,0):
				velocity = Vector2(0,0)
		else:
			if !approx_vector2(global_position, inicial_position):
				velocity = (speed * (inicial_position - global_position).normalized())
				adjust_velocity()
				move_and_slide()
			elif velocity!=Vector2(0,0):
				velocity = Vector2(0,0)
		pass
	
func adjust_velocity():
	for body in $Area2D.get_overlapping_bodies():
			if body.get_class()=="RigidBody2D":
				if body.is_sleeping():
					#body.global_position+=Vector2(0,1)
					body.apply_impulse(Vector2(0,0))
			if body.get_class()=="TileMap" or body.get_class()=="TileMapLayer":
				velocity = Vector2(0,0)
				move_and_slide()

func stop() -> bool:
	print(global_position, final_position, inicial_position)
	print(approx_vector2(global_position, final_position))
	print(approx_vector2(global_position, inicial_position))
	if is_button_pressed and approx_vector2(global_position, final_position):
		velocity = Vector2(0,0)
		move_and_slide()
		return true
	elif !is_button_pressed and approx_vector2(global_position, inicial_position):
		velocity = Vector2(0,0)
		move_and_slide()
		return true
	else:
		return false

func approx_vector2(position1: Vector2, position2: Vector2) -> bool:
	'''
	if is_equal_approx(position1.x, position2.x):
		if is_equal_approx(position1.y, position2.y):
			return true'''
	if round(position1.x)==round(position2.x):
		if round(position1.y)==round(position2.y):
			return true
	return false

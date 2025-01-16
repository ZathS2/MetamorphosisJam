extends RigidBody2D

var beeing_caried = false

# Called when the node enters the scene tree for the first time.
func _ready():
	lock_rotation = true
	#can_sleep = false
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if !beeing_caried:
		for body in $Area2D.get_overlapping_bodies():
			if get_groups().has("Catchable"):
				if body.is_in_group("Player"):
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<60:
						if Vector2(global_position-player_position).x>0:
							apply_central_impulse(Vector2(25, 0))
						elif Vector2(global_position-player_position).x<0:
							apply_central_impulse(Vector2(-25, 0))
			else:
				if body.is_in_group("Onça"):
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<90:
						if Vector2(global_position-player_position).x>0:
							apply_central_impulse(Vector2(25, 0))
						elif Vector2(global_position-player_position).x<0:
							apply_central_impulse(Vector2(-25, 0))
		pass

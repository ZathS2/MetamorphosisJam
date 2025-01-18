extends RigidBody2D

var beeing_caried = false
var being_pushed = false

var pushingDir : int = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	lock_rotation = true
	#can_sleep = false
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	being_pushed = false
	if !beeing_caried:
		for body in $Area2D.get_overlapping_bodies():
			if get_groups().has("Catchable"):
				if body.is_in_group("Player"):
					var speed = 150
					if body.is_in_group("Onça"):
						speed = 250
					
					being_pushed = true
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<60:
						if Vector2(global_position-player_position).x>0:
							if linear_velocity.length()<speed:
								apply_central_impulse(Vector2(25, 0))
								pushingDir = 1
						elif Vector2(global_position-player_position).x<0:
							if linear_velocity.length()<speed:
								apply_central_impulse(Vector2(-25, 0))
								pushingDir = -1
			else:
				if body.is_in_group("Onça"):
					being_pushed = true
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<90:
						if Vector2(global_position-player_position).x>0:
							if linear_velocity.length()<200:
								apply_central_impulse(Vector2(25, 0))
								pushingDir = 1
						elif Vector2(global_position-player_position).x<0:
							if linear_velocity.length()<200:
								apply_central_impulse(Vector2(-25, 0))
								pushingDir = -1
	
	if being_pushed==false:
		if !is_zero_approx(linear_velocity.x): 
			apply_central_impulse((-linear_velocity.x / 2 * mass) * Vector2.RIGHT)
			 
	
	var ray_cast_collider_down = $RayCastDown.get_collider()
	if ray_cast_collider_down!= null:
		if ray_cast_collider_down.get_class()=="TileMap" or ray_cast_collider_down.get_class()=="TileMapLayer":
			gravity_scale = 0
			global_position = Vector2(global_position.x, global_position.y-1)
		else:
			gravity_scale = 1
	else:
		var ray_cast_collider_down2 = $RayCastDown2.get_collider()
		if ray_cast_collider_down2!=null:
			if !(ray_cast_collider_down2.get_class()=="TileMap" or ray_cast_collider_down2.get_class()=="TileMapLayer"):
				gravity_scale = 1
		else:
			gravity_scale = 1

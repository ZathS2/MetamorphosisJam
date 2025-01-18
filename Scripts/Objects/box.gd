extends RigidBody2D

var beeing_caried = false
var being_pushed = false
var in_water = false

var gravity_value = 1

var pushingDir : int = 0
var Area

# Called when the node enters the scene tree for the first time.
func _ready():
	lock_rotation = true
	Area =$Area2D
	gravity_scale=1
	#can_sleep = false
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	var water = GameManager.water
	if water!=null:
		water.is_box_in_water(self)
	if in_water:
		print("in_water")
		Area = $InWaterArea
		gravity_value = 0.5
		lock_rotation = false
	else:
		Area = $Area2D
		gravity_value = 1
		lock_rotation = true
	
	being_pushed = false
	if !beeing_caried:
		for body in Area.get_overlapping_bodies():
			if get_groups().has("Catchable"):
				if body.is_in_group("Player"):
					var speed = 150
					
					being_pushed = true
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<60:
						if Vector2(global_position-player_position).x>0:
							if linear_velocity.length()<speed:
								apply_central_impulse(Vector2(50, 0))
								pushingDir = 1
						elif Vector2(global_position-player_position).x<0:
							if linear_velocity.length()<speed:
								apply_central_impulse(Vector2(-50, 0))
								pushingDir = -1
			else:
				if body.is_in_group("Onça"):
					being_pushed = true
					var player_position = body.global_position
					if Vector2(global_position-player_position).y<90:
						if Vector2(global_position-player_position).x>0:
							if linear_velocity.length()<200:
								apply_central_impulse(Vector2(50, 0))
								pushingDir = 1
						elif Vector2(global_position-player_position).x<0:
							if linear_velocity.length()<200:
								apply_central_impulse(Vector2(-50, 0))
								pushingDir = -1
	
	if being_pushed==false:
		if !is_zero_approx(linear_velocity.x): 
			apply_central_impulse((-linear_velocity.x / 2 * mass) * Vector2.RIGHT)
	
	if !in_water:
		var ray_cast_collider_down = $RayCastDown.get_collider()
		if ray_cast_collider_down!= null:
			if ray_cast_collider_down.get_class()=="TileMap" or ray_cast_collider_down.get_class()=="TileMapLayer":
				gravity_scale = 0
				global_position = Vector2(global_position.x, global_position.y-1)
			else:
				gravity_scale = gravity_value
		else:
			var ray_cast_collider_down2 = $RayCastDown2.get_collider()
			if ray_cast_collider_down2!=null:
				if !(ray_cast_collider_down2.get_class()=="TileMap" or ray_cast_collider_down2.get_class()=="TileMapLayer"):
					gravity_scale = gravity_value
			else:
				gravity_scale = 1

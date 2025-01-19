extends Area2D

var caring_body
var body_distance


func _physics_process(_delta):
	var direction_x = Input.get_axis("ui_left", "ui_right")
	if direction_x:
		if direction_x==-1 and !$"../AnimatedSprite2D".flip_h:
			print($"../AnimatedSprite2D".flip_h)
			flip_h()
		elif direction_x==1 and $"../AnimatedSprite2D".flip_h:
			print($"../AnimatedSprite2D".flip_h)
			flip_h()
	
	if get_parent().isFlying==true:
		if Input.is_action_just_pressed("interact"):
			if caring_body==null:
				for body in get_overlapping_bodies():
					if body.is_in_group("Catchable"):
						caring_body = body
						body.freeze = true
						body.set_collision_layer_value(1, false)
						body.beeing_caried = true
						body.linear_velocity = Vector2(0, 0)
						body.rotation = 15
						body.global_position = $"../Marker2D".global_position
						break
			else:
				caring_body.rotation = 0
				caring_body.freeze = false
				caring_body.beeing_caried = false
				caring_body.set_collision_layer_value(1, true)
				caring_body = null
		
		if caring_body!=null:
			caring_body.global_position = $"../Marker2D".global_position
	else:
		if caring_body:
			caring_body.rotation = 0
			caring_body.freeze = false
			caring_body.set_collision_layer_value(1, true)
			caring_body.beeing_caried = false
			caring_body = null
	
func flip_h():
		$"../AnimatedSprite2D".flip_h = !$"../AnimatedSprite2D".flip_h
		$"../Marker2D".position = Vector2($"../Marker2D".position*Vector2(-1, 1))
		$"../CollisionShape2D".position = Vector2($"../CollisionShape2D".position*Vector2(-1, 1))
		$CollisionShape2D.position = Vector2($CollisionShape2D.position*Vector2(-1, 1))

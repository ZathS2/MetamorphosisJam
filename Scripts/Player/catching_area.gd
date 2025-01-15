extends Area2D

var caring_body
var body_distance


func _physics_process(delta):
	if caring_body!= null:
		for i in caring_body.get_contact_count():
			var collision_angle = caring_body.get_contact_local_normal(i).angle()
			print(collision_angle)
	
	if Input.is_action_just_pressed("ui_text_indent"):
		if caring_body==null:
			for body in get_overlapping_bodies():
				if body.is_in_group("Catchable"):
					caring_body = body
					body.beeing_caried = true
					body.freeze = true
					body.global_position = $"../Marker2D".global_position
					body_distance = Vector2(body.global_position-get_parent().global_position)
					body.linear_velocity = Vector2(0, 0)
				break
		else:
			caring_body.freeze = false
			caring_body.beeing_caried = false
			caring_body = null
	
	if caring_body!=null:
		caring_body.global_position = Vector2(body_distance+get_parent().global_position)
		caring_body.linear_velocity = Vector2(0, 0)
	
	

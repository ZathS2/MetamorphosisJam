extends CharacterBody2D


const SPEED = 300.0

@onready var catching_area = $CatchingArea

var caring_body


func _physics_process(delta):
	var last_global_position = global_position
	
	if caring_body!= null:
		for i in caring_body.get_contact_count():
			var collision_angle = caring_body.get_contact_local_normal(i).angle()
			print(collision_angle)
	
	var direction_y = Input.get_axis("ui_up", "ui_down")
	if direction_y:
		velocity.y = direction_y * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)
	
	var direction_x = Input.get_axis("ui_left", "ui_right")
	if direction_x:
		velocity.x = direction_x * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()
	
	if Input.is_action_just_pressed("ui_accept"):
		if caring_body==null:
			for body in catching_area.get_overlapping_bodies():
				if body.is_in_group("Catchable"):
					caring_body = body
					body.beeing_caried = true
					body.freeze = true
					body.global_position = Vector2(body.global_position+Vector2(0,2))
					body.linear_velocity = Vector2(0, 0)
				break
		else:
			caring_body.freeze = false
			caring_body.beeing_caried = false
			caring_body = null
	
	if caring_body!=null:
		caring_body.global_position = Vector2(caring_body.global_position+Vector2(global_position-last_global_position))
	
	

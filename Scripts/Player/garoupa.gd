extends CharacterBody2D


const SPEED = 300.0
const JUMP_VELOCITY = -400.0



func _physics_process(delta):
	var direction_y = Input.get_axis("ui_up", "ui_down")
	if direction_y:
		velocity.y = direction_y * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)
	
	var direction_x = Input.get_axis("ui_left", "ui_right")
	if direction_x:
		velocity.x = direction_x * SPEED
		if direction_x==-1 and !$AnimatedSprite2D.flip_h:
			$AnimatedSprite2D.flip_h = true
		elif direction_x==1 and $AnimatedSprite2D.flip_h:
			$AnimatedSprite2D.flip_h = false
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()

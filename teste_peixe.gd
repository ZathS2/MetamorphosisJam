class_name Player
extends CharacterBody2D

signal player_in_water

const SPEED = 300.0
const JUMP_VELOCITY = -400.0
const UP_DIRECTION = Vector2(0, -1)


var tile_map
var last_position_tile
var last_collision_id

func _ready():
	player_in_water.connect(func(): print("Player in water"))
	#tile_map = get_node("/root/Node2D/TileMap")
	#print(tile_map)
	pass

func _physics_process(delta):
	'''
	# Gets position on tile map
	var position_tile = tile_map.local_to_map(global_position)
	if last_position_tile!=position_tile:
		print(position_tile)
		var tile_id = tile_map.get_cell_tile_data(1, Vector2(position_tile.x, position_tile.y))
		print(tile_id)
		tile_id = tile_map.get_cell_tile_data(1, Vector2(position_tile.x, position_tile.y+1))
		print(tile_id)
		last_position_tile = position_tile'''
	
	for i in range(get_slide_collision_count()):
		var collision = get_slide_collision(i)
		if collision:
			if last_collision_id!=collision.get_collider_id():
				print(collision.get_collider_id())
				last_collision_id = collision.get_collider_id()
				print(collision.get_angle(UP_DIRECTION))
				print(collision.get_collider())
	
	# Add the gravity.
	if not is_on_ground():
		velocity += get_gravity() * delta
	
	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_ground():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction = Input.get_axis("ui_left", "ui_right")
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()

func is_on_ground():
	var return_value = false
	for i in range(get_slide_collision_count()):
		var collision = get_slide_collision(i)
		if collision and collision.get_angle(UP_DIRECTION)==0:
			return_value = true
	return return_value

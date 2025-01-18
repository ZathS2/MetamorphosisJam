extends Area2D

func _ready():
	GameManager.water = self
	pass
	
func _process(delta):
	var is_player_in_water = false
	for body in get_overlapping_bodies():
		if body.is_in_group("Player"):
			is_player_in_water = true
			break
	GameManager.is_player_in_water = is_player_in_water

func is_box_in_water(box: RigidBody2D):
	if get_overlapping_bodies().has(box):
		box.in_water=true
		pass
	pass

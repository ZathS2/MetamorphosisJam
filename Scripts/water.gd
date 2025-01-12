extends Area2D

func _ready():
	#body_entered.connect(on_body_entered)
	#body_exited.connect(on_body_exited)
	#var playerScript = load("res://Scripts/PlayerScript.cs")
	#player = playerScript.new()
	pass
	
func _process(delta):
	var is_player_in_water = false
	for body in get_overlapping_bodies():
		if body.is_in_group("Player"):
			is_player_in_water = true
			break
	GameManager.is_player_in_water = is_player_in_water
'''
func on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Player"):
		GameManager.player_entered_water.emit()
		queue_free()

func on_body_exited(body: Node2D) -> void:
	if body.is_in_group("Player"):
		GameManager.player_exited_water.emit()
		queue_free()
'''

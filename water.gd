extends Area2D

var player

func _ready():
	body_entered.connect(on_body_entered)
	player = get_node("/root/Node2D/player")

func on_body_entered(body: Node2D) -> void:
	if body.is_in_group("Player"):
		player.player_in_water.emit()
		queue_free()

extends Area2D

var player

func _ready():
	body_entered.connect(on_body_entered)
	var playerScript = load("res://Scripts/PlayerScript.cs")
	player = playerScript.new()

func on_body_entered(body: Node2D) -> void:
	if body.is_in_group("PlayerNode"):
		player.PlayerInWaterEventHandler.emit()
		print("é pra ter emitido")
		queue_free()

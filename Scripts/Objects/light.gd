extends Node2D

var last_played = "off"

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	for body in $Area2D.get_overlapping_bodies():
		if body.get_groups().has("Botão"):
			if body.area2D.is_pressed and last_played=="off":
				$AnimationPlayer.play("on")
				last_played="on"
				pass
		elif last_played=="on":
				$AnimationPlayer.play("off")
				last_played="off"
				pass
	pass

extends Area2D

@onready var animatio_player = $"../AnimationPlayer"

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_body_entered(body):
	if body.get_class()!="StaticBody2D":
		animatio_player.play("button_pressed")
		print("Pressed")
	pass # Replace with function body.


func _on_body_exited(body):
	if body.get_class()!="StaticBody2D":
		animatio_player.play("button_released")
		print("Released")
	pass # Replace with function body.

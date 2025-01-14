extends Area2D

@onready var animatio_player = $"../AnimationPlayer"
@onready var platform = get_parent().platform

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_body_entered(body):
	print(body)
	if body.get_class()!="StaticBody2D":
		animatio_player.play("button_pressed")
		if platform!=null:
			platform.is_button_pressed = true
		
	pass # Replace with function body.


func _on_body_exited(body):
	if body.get_class()!="StaticBody2D":
		animatio_player.play("button_released")
		if platform!=null:
			platform.is_button_pressed = false
	pass # Replace with function body.

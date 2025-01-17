extends Area2D

@onready var animatio_player = $"../AnimationPlayer"
@onready var platform = get_parent().platform
@onready var door = get_parent().door

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_body_entered(body):
	if body.get_class()!="StaticBody2D" and body.get_class()!="TileMapLayer" and body.get_class()!="TileMap":
		animatio_player.play("button_pressed")
		if door!=null:
			door.isDoorClosed=false
		if platform!=null:
			platform.is_button_pressed = true
		if door != null:
			door.isDoorClosed = false
			door.t = 0
		
	pass # Replace with function body.


func _on_body_exited(body):
	if body.get_class()!="StaticBody2D" and body.get_class()!="TileMapLayer" and body.get_class()!="TileMap":
		animatio_player.play("button_released")
		if door!=null:
			door.isDoorClosed=true
		if platform!=null:
			platform.is_button_pressed = false
		if door != null:
			door.isDoorClosed = true
			door.t = 0
	pass # Replace with function body.

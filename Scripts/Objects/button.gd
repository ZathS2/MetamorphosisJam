extends Area2D

@onready var animatio_player = $"../AnimationPlayer"
@onready var platform = get_parent().platform
@onready var door = get_parent().door

var is_pressed = false

# Called when the node enters the scene tree for the first time.
func _ready():
	get_parent().area2D = self
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_body_entered(body):
	if body.get_class()!="StaticBody2D" and body.get_class()!="TileMapLayer" and body.get_class()!="TileMap":
		if !get_parent().get_groups().has("Clickable") or body.get_groups().has("Fish"):
			animatio_player.play("button_pressed")
			is_pressed=true
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
		if !get_parent().get_groups().has("Clickable"):
			animatio_player.play("button_released")
			is_pressed=false
			if door!=null:
				door.isDoorClosed=true
			if platform!=null:
				platform.is_button_pressed = false
			if door != null:
				door.isDoorClosed = true
				door.t = 0
	pass # Replace with function body.

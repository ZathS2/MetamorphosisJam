extends Node2D

@onready var Anim = $AnimationPlayer
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	Anim.play("rope")
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

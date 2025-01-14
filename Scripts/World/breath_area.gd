extends Area2D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	var can_breathe = false
	for body in get_overlapping_bodies():
		if body.is_in_group("Player"):
			can_breathe = true
			break
	GameManager.can_breathe = can_breathe

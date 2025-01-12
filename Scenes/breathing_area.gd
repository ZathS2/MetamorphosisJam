extends Area2D


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	print(get_overlapping_areas())
	print(get_overlapping_bodies())
	print()
	if get_overlapping_areas():
		GameManager.can_breathe = false
	else:
		GameManager.can_breathe = true
	queue_free()
	
	pass

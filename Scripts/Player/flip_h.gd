extends Node2D

var parent

# Called when the node enters the scene tree for the first time.
func _ready():
	parent = get_parent()
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if parent.velocity.x<0 and !$"../AnimatedSprite2D".flip_h:
		flip_h()
	elif parent.velocity.x>0 and $"../AnimatedSprite2D".flip_h:
		flip_h()
	pass

func flip_h():
		$"../AnimatedSprite2D".flip_h = !$"../AnimatedSprite2D".flip_h
		$"../CollisionShape2D".position = Vector2($"../CollisionShape2D".position*Vector2(-1, 1))

extends AnimatedSprite2D

var parent
var groups

# Called when the node enters the scene tree for the first time.
func _ready():
	parent = get_parent()
	groups = get_parent().get_groups()
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if groups.has("Garça"):
		if parent.isFlying:
			play("fly")
		elif parent.velocity.x==0:
			play("idle")
		else:
			play("run")
		pass
	elif groups.has("Arara"):
		play("idle")
	elif groups.has("Turtle"):
		if GameManager.is_player_in_water or parent.velocity.x!=0:
			play("run")
		else:
			play("idle")
	elif parent.velocity.x!=0 or groups.has("Fish"):
		play("run")
	else:
		play("idle")

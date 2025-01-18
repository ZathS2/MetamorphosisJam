extends Area2D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	
	pass


func _on_body_entered(body: Node2D) -> void:
	if !body.is_in_group("Player"):
		return
		
	if (GameManager.is_on_rope):
		return
	
	GameManager.is_on_rope = true
	GameManager.rope_seg_area = self
	pass # Replace with function body.

func _on_body_exited(body: Node2D) -> void:
	if !body.is_in_group("Player"):
		return
	
	if (!GameManager.jumped_out_of_rope):
		return
		
	GameManager.is_on_rope = false
	GameManager.rope_seg_area = null
	GameManager.jumped_out_of_rope = false
	pass # Replace with function body.

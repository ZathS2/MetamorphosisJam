extends Node

var is_player_in_water = false
var can_breathe = false
var is_on_rope = false
var jumped_out_of_rope = false

var rope_seg_area = null
var last_checkpoint_pos = null

var check_point_scene : PackedScene = null


const CREATURE: int = 0
const TURTLE: int = 1
const HERON: int = 2
const MACAW: int = 3
const MONKEY: int = 4
const ONCA: int = 5
const GAROUPA: int = 6

var current_animal = CREATURE

# salva os animais desbloquados em um int, vulgo byte
var animal_status: int = 0

var animal_status_save: int = 0

var collected_unlockers = []
var unlockers_save = []
#
var leversValue = {}

# Called when the node enters the scene tree for the first time.
func _ready():
	#player_entered_water.connect(func(): is_player_in_water=true; print("Player in water"))
	#player_exited_water.connect(func(): is_player_in_water=false; print("Player out of water"))
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	
func saveData():
	var levers = get_tree().get_nodes_in_group("Lever")
	for lever in levers:
		leversValue[lever] = lever.find_child("Area2D").isLeverDown
		break
		
	animal_status_save = animal_status
	unlockers_save = collected_unlockers.duplicate()
	print("Salvo")
	
func respawn():
	print("respawnando")
	var playerNode = get_tree().get_nodes_in_group("Player")[0] as Node2D
	current_animal = CREATURE
	
	animal_status = animal_status_save
	for unlocker in collected_unlockers:
		if (!unlockers_save.has(unlocker)):
			print("FOI")
			unlocker.show()
	
	collected_unlockers = unlockers_save
	
	playerNode.get_child(0).global_position = last_checkpoint_pos
	
	print(get_tree().get_nodes_in_group("Lever")[0].find_child("Area2D").isLeverDown)
	
	for lever in leversValue:
		
		var value = leversValue[lever]
		if (value != lever.find_child("Area2D").isLeverDown):
			lever.find_child("Area2D").MoveLever(value)
		lever.find_child("Area2D").isLeverDown = value
		print(lever.find_child("Area2D").isLeverDown)
	
func collectUnlocker(unlocker : Node2D):
	print("COLETO")
	collected_unlockers.append(unlocker)

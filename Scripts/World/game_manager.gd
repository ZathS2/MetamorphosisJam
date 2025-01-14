extends Node

var is_player_in_water = false
var can_breathe = false
var is_on_rope = false
var jumped_out_of_rope = false

var rope_seg_area = null
var last_checkpoint_pos = null


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

# Called when the node enters the scene tree for the first time.
func _ready():
	#player_entered_water.connect(func(): is_player_in_water=true; print("Player in water"))
	#player_exited_water.connect(func(): is_player_in_water=false; print("Player out of water"))
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	

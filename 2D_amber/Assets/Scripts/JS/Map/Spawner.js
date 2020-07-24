#pragma strict
var target : GameObject ;
var number : int = 1;
var delay : float = 0.1 ;

private var box : Collider2D ;

function Awake(){
  box = GetComponent.<Collider2D>() ;
}

function Spawn(){
  var max : Vector3 = box.bounds.max ;
  var min : Vector3 = box.bounds.min ;
  var pos : Vector3 = transform.position ;
  pos.x = Random.Range(min.x, max.x) ;
  
  Instantiate(target, pos, transform.rotation) ;
}

function DelaySpawn(){
  for(var i=0 ; i<number ; i++){
    Spawn() ;
    yield WaitForSeconds(delay) ;
  }
}

function CallSpawn(){
  DelaySpawn() ;
}

#pragma strict
var speed : float = 8 ;
var lifeTime : float = 1 ;

function Start(){
  Destroy(gameObject,lifeTime) ;
}

function Update(){
  transform.Translate(Vector3.right*Time.deltaTime*speed) ;
}

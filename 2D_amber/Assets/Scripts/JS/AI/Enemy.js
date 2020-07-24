#pragma strict
var hp : float = 10 ;
var atk : float = 1 ;
var detectRange : Vector2 = new Vector2(10,5) ;
var searchInterval : float = 1 ;

internal var target : Transform ;

// Component
internal var anim : Animator ;
internal var nav : Navigation2D ;
internal var state : AnimatorStateInfo ;

function Awake(){
  nav = GetComponent.<Navigation2D>() ;
  anim = GetComponent.<Animator>() ;
}

function Start(){
  StartCoroutine("SearchTimer") ;
}

function SearchPlayer(){
  var hits : Collider2D[] = new Collider2D[1] ;
  var result : int = Physics2D.OverlapBoxNonAlloc(transform.position, detectRange, 0, hits, 1<<9) ;
  if(result > 0){
    target = Game.player() ;
    StopCoroutine("SearchTimer") ;
  }
}

function SearchTimer(){
  while(true){
    yield WaitForSeconds(searchInterval) ;
    SearchPlayer() ;
  }
}

function StateMachine(){}

function Damage(dmg:float){
  hp -= dmg ;
}

function Die(){
  Destroy(gameObject) ;
}

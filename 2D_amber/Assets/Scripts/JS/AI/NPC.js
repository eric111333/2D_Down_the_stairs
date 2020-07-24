#pragma strict
var pos1 : Vector3 ;
var pos2 : Vector3 ;
var waitTime : Vector2 ;
var storyID : int = 0 ;

internal var inView : boolean = false ; // 是否在視野內
// 元件
internal var nav : Navigation2D ;
internal var anim : Animator ;
internal var world : World ;


function Awake(){
  nav = GetComponent.<Navigation2D>() ;
  anim = GetComponent.<Animator>() ;
  world = FindObjectOfType.<World>() ;
  pos1 += transform.position ;
  pos2 += transform.position ;
}

function Start(){
  StartCoroutine("Wander") ;
}

function Update(){
  Talk() ;
  StateMachine() ;
}

function Talk(){
  if(Input.GetKeyDown(KeyCode.Z) && !Game.pause && inView){
    world.StartTalk(storyID) ;
    Game.player().GetComponent.<Controller>().Move(0) ;
  }
}

// 遊蕩
function Wander(){
  var point1 : boolean = true ;
  nav.MoveTo(pos1) ;
  
  while(true){
    if(!nav.moving){
      yield WaitForSeconds(Random.Range(waitTime.x, waitTime.y)) ;
      point1 = !point1 ;
      nav.MoveTo(point1 ? pos1 : pos2) ;
    }
    yield WaitForSeconds(Time.deltaTime) ;
  }
}
// 狀態
function StateMachine(){
  anim.SetBool("move", nav.moving && !Game.pause) ;
}

//========
// 觸發器
//========
function OnTriggerEnter2D(co:Collider2D){
  if(co.tag != "Player"){return ;}
  co.GetComponent.<Controller>().SpawnButton() ;
  inView = true ;
}
function OnTriggerExit2D(co:Collider2D){
  if(co.tag != "Player"){return ;}
  co.GetComponent.<Controller>().DestroyButton() ;
  inView = false ;
}

//=======
// Debug
//=======
function OnDrawGizmosSelected(){
  Gizmos.color = Color.red ;
  Gizmos.DrawWireSphere(transform.position+pos1, 0.2) ;
  Gizmos.DrawWireSphere(transform.position+pos2, 0.2) ;
}

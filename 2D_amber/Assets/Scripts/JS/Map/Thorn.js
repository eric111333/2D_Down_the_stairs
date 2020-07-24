#pragma strict
var delay : float = 1 ;

function Start(){
  yield WaitForSeconds(delay) ;
  GetComponent.<Animation>().Play() ;
}

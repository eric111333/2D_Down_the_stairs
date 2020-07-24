import UnityEngine.Events ;
#pragma strict
var OnEnter : UnityEvent ;

function OnTriggerEnter2D(co : Collider2D){
  if(co.tag != "Player") return ;
  OnEnter.Invoke() ;
}

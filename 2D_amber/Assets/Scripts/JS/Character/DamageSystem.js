#pragma strict
var dmg : float = 1.0 ;
var type : TargetType = TargetType.Enemy ;

function OnTriggerEnter2D(co:Collider2D){
  
  switch(type){
    case 0:
      if(co.gameObject.layer == 11){
        co.GetComponent.<Enemy>().Damage(dmg) ;
      }
      break ;
    case 1:
      if(co.gameObject.layer == 9){
        co.GetComponent.<ControllerBattle>().Damage(dmg) ;
      }
      break ;
    case 2:
      if(co.gameObject.layer == 11 || co.gameObject.layer == 9){
      
      }
      break ;
  }
}

enum TargetType{Enemy, Player, All}

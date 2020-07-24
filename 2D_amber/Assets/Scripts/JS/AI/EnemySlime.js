#pragma strict

class EnemySlime extends Enemy{
  
  function Update(){
    StateMachine() ;
    if(target != null){
      nav.Follow(target) ;
    }
  }
  
  function StateMachine(){
    state = anim.GetCurrentAnimatorStateInfo(0) ;
    anim.SetBool("moving", nav.moving) ;
    anim.SetBool("attack", nav.ReachGoal() && target!=null) ;
    nav.enableMove = !state.IsTag("attack") ;
  }
  
  function Damage(dmg:float){
    if(!this.enabled){return;}
    
    super(dmg) ;
    anim.SetTrigger("Hurt") ;
    
    if(hp <= 0){
      anim.SetTrigger("Die") ;
      Destroy(nav) ;
      this.enabled = false ;
    }
  }
}

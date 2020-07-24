#pragma strict

class ControllerBattle extends Controller{
  var bulletObject : GameObject ;
  
  function Control(){
    super() ;
    
    if(state.IsName("Base.Damage")){return ;}
    
    if(Input.GetKeyDown(KeyCode.Z) && !btn){
      Move(0) ;
      lockMove = true ;
      anim.SetInteger("Attack", anim.GetInteger("Attack")+1) ;
    }
    
    if(Input.GetKeyDown(KeyCode.C)){
      StarBurst() ;
    }
    
    if(Input.GetKeyDown(KeyCode.X)){
      Move(0) ;
      lockMove = true ;
      body.velocity.y = 0 ;
      anim.SetBool("Shot", true) ;
    }
    
    if(Input.GetKeyUp(KeyCode.X)){
      anim.SetBool("Shot", false) ;
    }
  }
  
  function StarBurst(){
    if(!Game.sav.CanUseSkill()){return ;}
    Move(0) ;
    lockMove = true ;
    anim.SetTrigger("Skill") ;
  }
  
  function Jump(){
    if(lockMove){return;}
    super() ;
  }
  
  function Move(i:int){
    if(!lockMove){
      body.velocity.x = i*speed*Time.deltaTime ;
    }
    anim.SetFloat("Move", Mathf.Abs(i)) ;
  }
  
  function Direction(i:int){
    if(lockMove && !state.IsTag("free")){return ;}
    super(i) ;
  }
  
  //=======
  // 事件
  //=======
  function Shot(){
    super() ;
    var pt : Transform = transform.Find("bulletPoint") ;
    Instantiate(bulletObject, pt.position, pt.rotation) ;
  }
  
  function Damage(dmg : float){
    if(state.IsName("Base.Damage")){return ;}
    Move(0) ;
    lockMove = true ;
    
    if(Game.sav.Damage(dmg) <= 0){
      // Die
      anim.SetTrigger("Die") ;
      gameObject.layer = 0 ;
      this.enabled = false ;
      Reload() ;
    }else{
      // Damage
      anim.SetTrigger("Damage") ;
    }
  }
  
  function Reload(){
    yield WaitForSeconds(3) ;
    Game.screen().FadeAndGo(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) ;
    Game.Reset() ;
  }
  
}

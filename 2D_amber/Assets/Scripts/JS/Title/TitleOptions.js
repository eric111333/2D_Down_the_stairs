#pragma strict
var hand : Transform ;
var buttons : Transform[] ;
var xOffset : float[] ;
var world : World ;
var moveSound : AudioClip ;
var okSound : AudioClip ;
private var id : int = 0 ;

function Start () {
  world = FindObjectOfType.<World>() ;
  id = 1 ;
  UpdatePosition() ;
}

function Update () {
  // 選單選擇
  if(Input.GetKeyDown(KeyCode.UpArrow)){
    id -- ;
    id = Mathf.Clamp(id,0 ,2) ;
    world.sound.PlaySE(moveSound) ;
    UpdatePosition() ;
  }
  if(Input.GetKeyDown(KeyCode.DownArrow)){
    id ++ ;
    id = Mathf.Clamp(id,0 ,2) ;
    world.sound.PlaySE(moveSound) ;
    UpdatePosition() ;
  }
  // 確定
  if(Input.GetKeyDown(KeyCode.Z)){
    switch(id){
      // new
      case 0 :
      Game.screen().FadeAndGo("Map") ;
      this.enabled = false ;
      break ;
      // load
      case 1 :
      break ;
      // exit
      case 2 :
      Application.Quit() ;
      break ;
    }
    world.sound.PlaySE(okSound) ;
  }
  
}

// 更新指標位置
function UpdatePosition(){
  hand.position.y = buttons[id].position.y-0.22 ;
  hand.position.x = xOffset[id] ;
}

#pragma strict
internal var sound : SoundManager ;
internal var ui : MainUI ;
internal var dialog : DialogUI ;

function Awake(){
  sound = FindObjectOfType.<SoundManager>() ;
  ui = FindObjectOfType.<MainUI>() ;
  dialog = FindObjectOfType.<DialogUI>() ;
}

function StartTalk(storyID : int){
  Game.pause = true ;
  ui.gameObject.SetActive(false) ;
  dialog.enabled = true ;
  dialog.StartTalk(storyID) ;
}

function EndTalk(){
  Game.pause = false ;
  ui.gameObject.SetActive(true) ;
}

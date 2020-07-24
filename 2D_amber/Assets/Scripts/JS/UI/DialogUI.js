#pragma strict
import System.Collections.Generic ;

var talk : Talk ;
var stories : TextAsset[] ;
// 立繪圖片元件
var portrait : UI.Image ;
var portrait2 : UI.Image ;
// 立繪圖片組
var myFace : Sprite[] ;
var misakiFace : Sprite[] ;
// 其他角色立繪組
var otherFace : List.<Sprite[]> = new List.<Sprite[]>();
// 元件
private var anim : Animation ;
private var world : World ;

function Awake(){
  anim = GetComponent.<Animation>() ;
  world = FindObjectOfType.<World>() ;
  otherFace.Add(misakiFace) ;
}

function Update(){
  if(Input.GetKeyDown(KeyCode.Z)){
    talk.Next() ;
  }
}
// 顯示/隱藏對話
function Show(b:boolean){
  var Name : String = "ShowDialog" ;
  anim[Name].speed = b ? 1:-1 ;
  
  if(!anim.isPlaying){
    anim[Name].normalizedTime = b ? 0:1 ;
  }
  anim.Play() ;
}
// 開始對話
function StartTalk(id : int){
  Show(true) ;
  talk.story = stories[id].text.Split("\n"[0]) ;
  talk.wordID = 0 ;
  talk.Next() ;
}
// 結束對話
function CallEndTalk(){
  Show(false) ;
  this.enabled = false ;
  yield WaitForSeconds(0.5f) ;
  world.EndTalk() ;
}
// 換表情
function ChangeFace(who:int,face:int){
  if(who == 0){
    portrait.sprite = myFace[face] ;
  }else{
    portrait2.sprite = otherFace[who-1][face] ;
  }
}

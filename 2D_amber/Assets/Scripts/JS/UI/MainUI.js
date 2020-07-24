#pragma strict
var hearts : Transform ;
var heartImage : Sprite[] ;
var sp : RectTransform ;
var coinText : UI.Text ;
private var coin : int = 0 ;

function Awake(){
  DrawMaxHP() ;
}

function Update(){
  DrawSP() ;
  DrawCoin() ;
  DrawHP() ;
}

function DrawMaxHP(){
  for(var i=1 ; i<Game.sav.maxHp ; i++){
    var h : Transform = Instantiate(hearts.GetChild(0)) ;
    h.SetParent(hearts, false) ;
    h.name = "h"+(i+1) ;
  }
  DrawHP() ;
}

function DrawHP(){
  var hp : float = Game.sav.hp ;
  
  for(var i=0 ; i<Game.sav.maxHp ; i++){
    var img : UI.Image = hearts.GetChild(i).GetComponent.<UI.Image>() ;
    
    if(i < Mathf.Floor(hp)){
      img.sprite = heartImage[2] ;
    }else if(i < hp){
      img.sprite = heartImage[1] ;
    }else{
      img.sprite = heartImage[0] ;
    }
  }
}

function DrawSP(){
  var s = Game.sav.sp ;
  sp.sizeDelta.x = Mathf.Lerp(sp.sizeDelta.x, s, 0.12) ;
}

function DrawCoin(){
  if(Game.sav.money > coin){
    coinText.GetComponentInParent.<Animation>().Play() ;
  }
  coin = Game.sav.money ;
  
  coinText.text = "x " + Game.sav.money ;
}


#pragma strict
var Name : UI.Text ;
var text : UI.Text ;
var dialog : DialogUI ;
var names : String[] ;
internal var story : String[] ;   // 總劇本
internal var wordID : int = 0 ;   // 句子的id
internal var charaID : int = 0 ;  // 單句文字的id
internal var word : String ;      // 完整句子
internal var timer : boolean = false ;  // 計時器啟動與否

function Next(){
  // 如果正在打字，則直接顯示完整文字
  if(timer){
    text.text = word ;
    timer = false ;
    return ;
  }
  // 如果到達文件最後，則結束對話
  if(wordID >= story.length-1){
    dialog.CallEndTalk() ;
    return ;
  }
  // 設定完整文字
  word = story[wordID] ;
  // 判斷指令或者對話
  if(word[0] == "@"){
    dialog.ChangeFace(int.Parse(word[1].ToString()), int.Parse(word[3].ToString())) ;
    wordID ++ ;
    Next() ;
    return ;
  }else{
    ChangeName(int.Parse(word[0].ToString())) ;
    Print() ;
    wordID ++ ;
  }
}
// 打字機
function Print(){
  // 初始化打字機
  charaID = 0 ;
  word = word.Substring(2) ;
  text.text = "" ;
  timer = true ;
  // 打字機迴圈
  while(timer){
    text.text += word[charaID] ;
    charaID ++ ;
    // 如果打字結束
    if(charaID >= word.length){
      timer = false ;
      break ;
    }
    // 打字速度
    yield WaitForSeconds(0.07f) ;
  }
}
// 改名字
function ChangeName(who:int){
  Name.text = names[who] ;
}

import UnityEngine.SceneManagement ;
#pragma strict

var map : String ;

function OnTriggerEnter2D (co : Collider2D) {
	if(co.tag != "Player") return ;
  SceneManager.LoadScene(map, LoadSceneMode.Additive) ;
  SceneManager.UnloadSceneAsync(gameObject.scene) ;
}

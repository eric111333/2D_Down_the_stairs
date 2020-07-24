import UnityEngine.SceneManagement ;
#pragma strict
var map : String ;

function Awake () {
	SceneManager.LoadScene(map, LoadSceneMode.Additive) ;
}

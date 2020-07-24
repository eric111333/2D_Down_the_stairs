using System.Collections;
using UnityEngine;

public class EnemyBoss : Enemy {
    public Transform cannonPoint ;
    public Transform[] locators ;
    public GameObject bullet ;

    public int currentPosition = 0 ;    // 現在所在位置

    public int atkCount = 0 ;


	public override void Start() {
        StartCoroutine(BattleStart()) ;
	}
    
    void Update(){
        StateMachine() ;
        
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            nav.MoveTo(locators[0].position) ;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            nav.MoveTo(locators[1].position) ;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Shot() ;
        }
    }
    
    public override void StateMachine(){
        anim.SetBool("moving", nav.moving) ;
    }

    // Shot
    public void Shot(){
        anim.SetTrigger("attack") ;
    }
    
    public void Cannon(){
        Instantiate(bullet, cannonPoint.position, cannonPoint.rotation) ;
    }

    // One punch
    public void OnePunch(){
        anim.SetTrigger("onepunch") ;
        nav.speedRate = 2.0f ;
    }

    public void PunchEnd(){
        anim.SetTrigger("punchend") ;
        StartCoroutine(PunchEndDelay()) ;
        nav.speedRate = 1.0f ;
    }

    IEnumerator PunchEndDelay(){
        yield return new WaitForSeconds(1) ;
        TurnAround() ;
    }

    // AI
    IEnumerator BattleStart(){
        yield return new WaitForSeconds(1) ;
        MoveTo(0) ;
        nav.OnReach = TurnAround ;
    }

    public void MoveTo(int i){
        nav.MoveTo(locators[i].position) ;
        currentPosition = i ;
    }

    public void TurnAround(){
        StartCoroutine(DelayAttack(0.4f)) ;
    }

    IEnumerator DelayAttack(float time){
        bool right = currentPosition == 0 ;

        yield return new WaitForSeconds(time) ;
        nav.FaceTo(right ? -1 : 1) ;
        yield return new WaitForSeconds(time) ;
        if((atkCount % 2) == 0 && (atkCount != 0)){
            OnePunch() ;
            yield return new WaitForSeconds(0.45f) ;
            MoveTo(right ? 1 : 0) ;
            nav.OnReach = PunchEnd ;
        }else{
            Shot() ;
            yield return new WaitForSeconds(time*7.0f) ;
            MoveTo(right ? 1 : 0) ;
            nav.OnReach = TurnAround ;
        }
        atkCount ++ ;
    }
}

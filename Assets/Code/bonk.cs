using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class bonk : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackRange=0.6f,AttackTimer=0.3f,cooldown=0.4f;
    public LayerMask Enemylayer;
    Player player;
    Animator anim,Myanim;
    public GameObject EnemySmashs;
    EnemySmash enemySmash;
  public bool Onair=false,Attack=false;
    // void OnTriggerStay2D(Collider2D Square)
    // {
    //     if(Square.gameObject.CompareTag("WeakPoint")||Square.gameObject.CompareTag("Enemy"))
    //     {
    //         inrange=true;
    //     }
    // }
    // Update is called once per frame
    void Start()
    {
        enemySmash=EnemySmashs.GetComponent<EnemySmash>();
        Myanim=gameObject.GetComponent<Animator>();
        anim=transform.parent.gameObject.GetComponent<Animator>();
        player=transform.parent.gameObject.GetComponent<Player>();
    }
    void Update()
    {
        
       
        if(Input.GetKeyDown(KeyCode.RightArrow) && !Attack)
        {
            
           Atackkk();
          StartCoroutine(AttackCooldown());

        }
       
        // if(Onair)///Nhay3 len sau khi atack onair
        // {
        //     player.Jumping();
        //     Onair=false;
        // }
        
    }
    public void Atackkk()
    {
        Attack=true;
            
            enemySmash.GodMode=true;
            anim.SetTrigger("Attack");  
            
             AnimGroundCheck();
    }
    private void AnimGroundCheck()
    {
        
          if(Onair)
        {
            Vector2 X=player.transform.position;
            transform.position=X;
            AttackRange=1.8f;
            
            anim.SetTrigger("OnAir");
          
        }
        else
        {
            // Vector2 X=new Vector2(player.transform.position.x+0.5f,player.transform.position.y-0.3f);
            // transform.position=X;
            AttackRange=1.5f;
            anim.SetTrigger("Ground");
                        Myanim.SetTrigger("Attack");  

          
        }
    }

    public void  triggerAttack()
    {
      
        
        
        
        // float timer = 0f;
        // while (timer < AttackTimer)
        // {
        
          
            Collider2D[] hitEnemy=Physics2D.OverlapCircleAll(transform.position,AttackRange,Enemylayer);
            foreach (Collider2D enemy in hitEnemy)
            {
                Debug.Log("hited");
                //enemy.GetComponent<BonkNDed>().BonkBonk();
                //if(!player.isGround)
                //Onair=true;
                BonkNDed bonkComponent = enemy.GetComponent<BonkNDed>();

                if (bonkComponent != null)
                {
                    bonkComponent.BonkBonk();
                }
            }
        //     timer+=Time.deltaTime;
        //     yield return null;
        // }
         
            
         //Attack=false;
          
    }

    IEnumerator AttackCooldown()
    {
          yield return new WaitForSeconds(cooldown);
          Attack=false;
          // player.Attack=false;
    }

    void DamageTime()
    {
        Attack=false;
        enemySmash.GodMode=false;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,AttackRange);
    }
    
}

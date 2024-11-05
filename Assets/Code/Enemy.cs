using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Finish")||collision.gameObject.CompareTag("StartPoint"))
    //     {
    //         //GetComponent<Rigidbody2D>().gravityScale=1;
    //     }
    // }
    
    // Update is called once per frame
    [SerializeField ]CoinBuffEnemy coinBuffEnemy;
    [SerializeField] private Vector2 JumPlace;
    [SerializeField] private float PeekapooSpeed=20f,goSpeed,Flip=1;
    [SerializeField] bool JumP=false,onscreen=false,Movement=false;
    
    public bool Bonked=false,Move=false;
    public GameObject Enemyplace;
    public Camera mainCamera;
     [SerializeField] Animator animati;
     SpriteRenderer sprite;
     Rigidbody2D rb;
    GoGogo goGogo;
    
    Vector3 screenPoint;
    // void Awake()
    // {
        
        
    // }
    void Start()
    {
    
      int i=Random.Range(1,3);
      if(i==1)
      Movement=true;
        // if(transform.position.y >0)
        // {
        //    // player= GameObject.Find("me").GetComponent<Player>();
             
             coinBuffEnemy=GameObject.Find("Spawner").GetComponent<CoinBuffEnemy>();
        // }
         //test=GetComponent<Rigidbody2D>().gravityScale;
        if(coinBuffEnemy.LocationY<transform.position.y)
        {
          goGogo=GetComponent<GoGogo>();
          goGogo.Destroyit=false;
          // JumPlace=GameObject.Find("EnemyPlace(Clone)").transform.position;
          Enemyplace=GameObject.Find("EnemyPlace");
           rb=GetComponent<Rigidbody2D>();
        rb.gravityScale=0;
        //  AVC=GameObject.Find("me");
        //  JumPlace=AVC.transform.position;
        //  JumPlace.x=AVC.transform.position.x+3;
        mainCamera=Camera.main;
           
          //animati=GetComponent<Animator>();
         Movement=false;
        }
        
      sprite=GetComponent<SpriteRenderer>();


      
     // screenPoint = mainCamera.WorldToViewportPoint(Enemyplace.transform.position);
        
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Finish"))
       {
        Flip=-1;       
        sprite.flipX=false;  
       }
       if(collision.gameObject.CompareTag("StartPoint"))
       {
        Flip=1;  
        sprite.flipX=true;     
       }
    }

    void Update()
    {
      //test=rb.velocity.x;
       AnimationControl();



        if(Movement)
        {
          Vector2 pos = transform.position;
             pos.x +=goSpeed * Time.deltaTime*Flip;
            transform.position=pos;
        }
       // Debug.Log(Physics2D.OverlapBox())
             screenPoint = mainCamera.WorldToViewportPoint(Enemyplace.transform.position);

        onscreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1;
        if(coinBuffEnemy.LocationY<transform.position.y&&onscreen)
        { 
          // JumPlace=GameObject.Find("EnemyPlace(Clone)").transform.position;
          JumP=true;
           // Debug.Log("JUMPO==============================================================");
            //transform.position = Vector2.MoveTowards(transform.position, JumPlace, PeekapooSpeed * Time.deltaTime);
        }

        if(JumP)
        {
          sprite.flipX=true;
          EnemyJump();
        }
        
    }

    private void AnimationControl()
    {
      int State=0;

      if(!Bonked)
      {
        if(!Movement)
        State=1;
        else
        State=0;
        
      }
      else
      State=2;
      
      animati.SetInteger("State", State);
    }

    void Bonk()
{
  

    Destroy(gameObject);
}
void EnemyJump()
{
  PeekapooSpeedTune();
          JumPlace=Enemyplace.transform.position;
            if(transform.position.x<JumPlace.x)
            {
                
                Vector2 pos = transform.position;
             pos.x +=PeekapooSpeed * Time.deltaTime;
            transform.position=pos;
            rb.gravityScale=4;}
            else
            {
              sprite.flipX=false;
              JumP=false;
              goGogo.Destroyit=true;
            }
}
    private void PeekapooSpeedTune()
    {
       
          if(!goGogo.isOffScreen())
          PeekapooSpeed=28;
          else
          PeekapooSpeed=49;
    }
}

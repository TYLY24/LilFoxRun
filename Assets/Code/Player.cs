using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] public Vector2 velocity;


    [SerializeField] public float Jumpvel=10,Maxvel=10, test,StartX;
    
    
  [SerializeField] GameObject Coins,Bonk,Cam,GameoverUI,TurnUp,TurnBack,TurnoffButton1,TurnoffButton2,TurnoffButton3;

    [SerializeField] AudioManager audioManager;
    ShakingCam shakingCam;
    [SerializeField] public float MaxJump=2,Accelerate=0,DownArrow=50;

    private Rigidbody2D rb;
    BoxCollider2D collider2Dd;
    [SerializeField] public bool isDEAD=false,isGround,Groundcheck,Attack=false, onair,PLAYED=false,Chille=true,Back=false,JUMPBIte=false;
    //BoxCollider2D boxCollider2D;
    Animator anim;
    //HPnMETTER hPnMETTER;
    enum MovementState{run,jump,doublejump,fall,idle,Walk}
   [SerializeField] int Ran = 5, ii=1;
    bonk bonk;
    Coin coin;
    SpriteRenderer sprite;


   void OnCollisionEnter2D(Collision2D collision)
     {
      if(collision.gameObject.CompareTag("Ded"))
      isDEAD=true;

      if(collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Finish")||collision.gameObject.CompareTag("StartPoint"))
       {
          Vector3 Normal =  collision.GetContact(0).normal;
          if(Normal==Vector3.up)
           MaxJump=2;
       }
      
     }
    
    // 

    void Awake()
    {
      Application.targetFrameRate=60;
      coin =Coins.GetComponent<Coin>();
      sprite =GetComponent<SpriteRenderer>();
      StartX=transform.position.x;
      shakingCam=Cam.GetComponent<ShakingCam>();
      collider2Dd=GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        bonk=Bonk.GetComponent<bonk>();
        StartCoroutine(Chill());
        Vector2 sus;
        sus=transform.position;
        sus.x=transform.position.x+6f;
        transform.position=sus;
    }




    void Update()
    {
      
      if(JUMPBIte)
      {
        Jumping();
        JUMPBIte=false;
      }

      if(isDEAD)
      {
        DEad();
      }




        
        

        if(PLAYED)
        {
          RunBack(3f);
        AnimationControl();

        }
        else
        {
          ChillBeforeStart();
        }
         

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            Jumpinginput();

        }

        if(Input.GetKeyDown(KeyCode.DownArrow) )
        {

            rb.gravityScale=DownArrow;

        }

       
        

    }

    void DEad()
    {
      
      velocity.x=0;
        anim.SetTrigger("Hurt");
        shakingCam.isShakaShaka=false;
        if(MaxJump>=0)
        {
          Jumping();
          MaxJump-=10;
          audioManager.StopBgm();
          audioManager.PlayVfx(audioManager.Ded);
          GameoverUI.SetActive(true);
          TurnoffButton1.SetActive(false);
          TurnoffButton2.SetActive(false);
          TurnoffButton3.SetActive(false);
        }
        coin.InfoToSave.UpdateShieldsLV=0;
        collider2Dd.isTrigger = true;
        //Do thing here
    }

    public void Jumpinginput()
    {
      if( MaxJump>0)
        {
            MaxJump--;
            
            audioManager.PlayVfx(audioManager.Jump);
            
            Jumping();

        }
    }
    void RunBack(float Speed)
    {
      if(transform.position.x<StartX)
        {
          Vector2 pos=transform.position;
          pos.x +=Speed*Time.deltaTime;
          transform.position=pos;
           //rb.velocity=Vector2.right*3f;

        }
        else if(transform.position.x>StartX+0.5f)
        {
         Vector2 pos=transform.position;
           pos.x -=Speed*Time.deltaTime;
           transform.position=pos;
         // rb.velocity=Vector2.right*-3f;
        }
        else
        Back=true;
        
    }
    void ChillBeforeStart()
    {
      
      if(Chille)
       {
        
        
        if(transform.position.x<TurnUp.transform.position.x)
        ii=1;
        if(transform.position.x>TurnBack.transform.position.x)
        ii=-1;

          Vector2 ran= transform.position;
        if(Ran<5)
        {
           rb.velocity=Vector2.right*2f*ii;
           if(ii<0)
           sprite.flipX=true;
           else if(ii>0)
           sprite.flipX=false;
           
             anim.SetInteger("State", (int)MovementState.Walk);
        }
        else
          anim.SetInteger("State", (int)MovementState.idle);
        

         }
         else
         {
            RunBack(4f);
            if(Back)
              anim.SetInteger("State", (int)MovementState.idle);
            else if( transform.position.x<StartX)
            {
              anim.SetInteger("State", (int)MovementState.run);
              sprite.flipX=false;
            }
            else
            {
                anim.SetInteger("State", (int)MovementState.run);
                sprite.flipX=true;
            }
         }
         
         
         
         

      
      
    }

    IEnumerator Chill()
    {
      while (Chille)
      {
        Vector2 ran= transform.position;
        
          
          yield return new WaitForSeconds(3f);
          int randomValue = UnityEngine.Random.value < 0.5f ? -1 : 1;
          ii=randomValue;
           Ran = UnityEngine.Random.Range(0,10); 
        
      }
      
    }


    void AnimationControl()
    {

      MovementState state;

      
      if(isGround)
      {
        onair=false;
        rb.gravityScale=5;


          state=MovementState.run;
          sprite.flipX=false;
        
      }
       else if(rb.velocity.y>.1f)
      {
        onair=true;
        if(MaxJump==1)
        state=MovementState.jump;
        else
        
          
          state=MovementState.doublejump;
        
        
      }else if(rb.velocity.y<.1f)
      {
        onair=true;
        state=MovementState.fall;
      }
      else
      {
        state=MovementState.idle;
      }
      
      
      
                                                                                                                                             
      anim.SetInteger("State", (int)state);
      bonk.Onair=onair;
    }
    public void Jumping()
    {
       rb.gravityScale=5;
      rb.velocity=Vector2.up*Jumpvel;

    }
   
    
  
   

}

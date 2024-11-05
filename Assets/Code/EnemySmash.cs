using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySmash : MonoBehaviour
{

    [SerializeField] AudioManager audioManager;
    Player player;
    [SerializeField]float bonce,moveDuration=4f,GModduration=1f;
    public int SlowEf=0;
    public GameObject parentObject,Shop,Coin;
    HPnMETTER hPnMETTER;
    [SerializeField] public bool Slow=false, getHited=false,GodMode=false,SuperGodMode=false,DameTime=false,SlowEff=false;
    [SerializeField]Rigidbody2D rd;
    Animator anim;
    Coin coin;
    ShopContents shopContents;
    
    
    void Start()
    {
      //  anim=parentObject.GetComponent<Animator>();
         parentObject = transform.parent.gameObject;
         coin= Coin.GetComponent<Coin>();
         shopContents= Shop.GetComponent<ShopContents>();
         anim= parentObject.GetComponent<Animator>();
        player = parentObject.GetComponent<Player>();
        hPnMETTER=parentObject.GetComponent<HPnMETTER>();
        
    }
   void OnTriggerEnter2D(Collider2D Square)
   {
    
      if(Square.gameObject.CompareTag("Fruit"))
      coin.apple=coin.apple+1*coin.InfoToSave.UpdateFruitsLV;
    
    if(!getHited)
    if(Square.gameObject.CompareTag("WeakPoint"))
    {
        player.Jumping();
        player.MaxJump++;
        //Destroy(Square.transform.parent.gameObject);
        Square.transform.parent.gameObject.GetComponent<Enemy>().Bonked=true;
        
    }
    if(SuperGodMode==false)
    if(Square.gameObject.CompareTag("Enemy") && GodMode==false||Square.gameObject.CompareTag("Trap"))
   // 
    {
        
       // Debug.Log("HeadSHOT====================================================================================================================");
        // Vector2 pos =parentObject.transform.position;
        // pos.x-=1f;
        // parentObject.transform.position=pos;
        Damaged();
    }
    if(hPnMETTER.currentHealth>0)
     if(Square.gameObject.CompareTag("Trap"))
    {
        SlowEff=true;
        SlowEf++;
        Slow=true;
         if(!player.isDEAD)
                {
                    StartCoroutine(Slower());
                }
    }
   }


   void Damaged()
   {
        
        if(hPnMETTER.shield>0)
         {
            audioManager.PlayVfx(audioManager.ShieldBlock);
            hPnMETTER.shield--;
            hPnMETTER.Heart[hPnMETTER.FullHealth+hPnMETTER.shield].enabled=false;
         }
         else
         {
            audioManager.PlayVfx(audioManager.Hurt);
            anim.SetTrigger("Hurt");
             hPnMETTER.currentHealth--;
             getHited=true;
            SuperGodMode=true;
             StartCoroutine( Hited());
        }
        if(hPnMETTER.currentHealth==0)
        player.isDEAD=true;
        
        
   }

     IEnumerator  Slower()
    {
            float slow=player.velocity.x*0.7f;
            player.velocity.x=slow;

             float elapsedTime = 0f;
            while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float newSpeed = Mathf.Lerp( slow, player.Maxvel, elapsedTime / moveDuration);
            player.velocity.x = newSpeed;

            yield return null;
        }
            
            // yield return new WaitForSeconds(moveDuration);
            player.velocity.x=player.Maxvel;
        
        Slow=false;
    
    }

   
        IEnumerator  Hited()
    {
       
            yield return new WaitForSeconds(GModduration);
        
            getHited=false;
            SuperGodMode=false;
    }
        //  void OnTriggerExit2D(Collider2D Square)
        //  {
            
        //     //SisdF=0;
        //  }

        
    
        void Update()
        {
          if(DameTime)
          {
            Damaged();
            DameTime=false;
          }
            
        }
//     void OnTriggerEnter2D(Collision2D collision)
//   {
//     if(collision.gameObject.CompareTag("Enemy"))
//     {
//         Vector3 Normal =  collision.GetContact(0).normal;
//     if(Normal!=Vector3.up)
//     {
//         if(hPnMETTER.shield>0)
//         {
//         hPnMETTER.shield--;
//         hPnMETTER.Heart[hPnMETTER.FullHealth+hPnMETTER.shield].enabled=false;
//         }
//         else
//         {
//             hPnMETTER.currentHealth--;
            
//         }
//     }
//     else
//     {
//         GetComponent<Rigidbody2D>().velocity=Vector2.up*player.Jumpvel;
//         player.MaxJump++;
//         Destroy(collision.gameObject);
//     }}
    
//   }
}

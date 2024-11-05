using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject Shaka,Slow,me;
    public GameObject[] BG;
    ShakingCam shakingCam;
    EnemySmash enemySmash;
    public bool Helloo=false,Cum=false,snap=true,Atak=false,next=false;
    public float HelloPos=-11,AtakPos=-9,tCoro=1;
    Vector2 Location;
    Coroutine ActiveCorotine;
    Player player;
    void Start()
    {
        player=me.GetComponent<Player>();
        enemySmash=Slow.GetComponent<EnemySmash>();
        shakingCam=Shaka.GetComponent<ShakingCam>();
        anim=GetComponent<Animator>();
        Location=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySmash.SlowEf)
        {
            Helloo=true;       
            tCoro++;
            enemySmash.SlowEf=false;
             
        }
        


        if(Helloo)
        {
            
            Hello();
        }
        else
        {
            
            Vector2 pos=transform.position;
            if(pos.x>Location.x)
            {
                pos.x-=2*Time.deltaTime;
                transform.position=pos;
            }
            else
            {
                Cum=false;
                tCoro=0;
            }
                
        }


         
        

        if(tCoro==2)
        {
           StartCoroutine(Snap());
           tCoro++;
        }


           

    }

    IEnumerator AtackMove(int A,float posiX)
    {
        Vector2 pos=transform.position;
        if(A<0)
        {
            while(pos.x-posiX>0)
        {
             pos.x+=20*Time.deltaTime*A;
            transform.position=pos;
              yield return null;
        }
        }
        else
        {
            while(pos.x-posiX<0)
        {
             pos.x+=20*Time.deltaTime*A;
            transform.position=pos;
              yield return null;
        }
        }
        next=true;
        
    }
    IEnumerator Snap()
    {
       
         anim.SetBool("Atak",true);
        shakingCam.isShakaShaka=true;
         Vector2 pos=transform.position;
        
    //    // while(pos.x<AtakPos)
            
    //             pos.x+=20*Time.deltaTime;
    //         transform.position=pos;

        StartCoroutine(AtackMove(1,AtakPos));
        
        enemySmash.DameTime=true;
        player.JUMPBIte=true;

                Debug.Log("Stage1");
       yield return new WaitUntil(() => next);
            
            next=false;
            Debug.Log("Stage1Done");
            shakingCam.isShakaShaka=false;
            anim.SetBool("Atak",false);
           Helloo=false;
            Atak=false;
           StopCoroutine(ActiveCorotine);
           
            tCoro++;
        
    }

    void Hello()
    {
       
        Vector2 pos=transform.position;
        if(pos.x<HelloPos)
        {
              anim.SetBool("Atak",true);
        shakingCam.isShakaShaka=true;
            pos.x+=10*Time.deltaTime;
            transform.position=pos;
        }

        else
        {
            
            Cum=true;
           
            
            if(!Atak)
            {
                 
                
                shakingCam.isShakaShaka=false;
                anim.SetBool("Atak",false);
                Atak=true;
                ActiveCorotine=StartCoroutine(Bye());
                
            }
             
            
        }
    }

    IEnumerator Bye()
    {
        
        yield return new WaitForSeconds(9f);
        Helloo=false;
        Atak=false;
    }

}

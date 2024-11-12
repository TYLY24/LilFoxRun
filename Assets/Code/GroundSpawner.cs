using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D.IK;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool groundCounter=true,HaveBasement = false,Groundwillfal=false,LimboActive=false;
    [SerializeField] public Vector2 StartingPos,pos,Posii;

    [SerializeField] Coin coin;
    [SerializeField] private GameObject[] GStart,GEnd,Grounds,newObject;
    [SerializeField] private GameObject Shield,HP,ChangingStart,ChangingMid,ChangingEnd;

   // [SerializeField] float Above=10,UndeGr=-10;
    [SerializeField] Player player;
     [SerializeField] Camera cameraManin;
     public GameObject PostoSendEnemyJump;
    [SerializeField] public int random2=1,World=1;

      [SerializeField] int MAP=1,PLACE=1,Limbo=0;
     [SerializeField]   HPnMETTER hPnMETTER;
     [SerializeField] BackGrControl backGrControl;
   
   float totalTime,totorandom;


    

    
    
    
void OnTriggerEnter2D(Collider2D square)
    {
 
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        if (square.CompareTag("LimboEnd"))
        {
            Limbo=0;
            MAP=PLACE;
        }
    }
    void OnTriggerExit2D(Collider2D square)
    {

        if (square.CompareTag("Finish"))
        {
            //Debug.Log("Triggered the special Box Collider 2D!");
            // Add your logic here
            groundCounter =false;
        }
        if (square.CompareTag("Limbo"))
        {
            Limbo++;
        }


        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
    // Update is called once per frame

    /*void Start()
    {

        offset=transform.position-cameraManin.transform.position;
    }*/
    // private void Awake()
    // {
    //     player= GameObject.Find("me").GetComponent<Player>();
    //    hPnMETTER= GameObject.Find("me").GetComponent<HPnMETTER>();
        
    // }
    void Update()
    {
       
        
       
         

        if(!groundCounter)
        {


           if(coin.changeMap==true)
            {
                MAP=0;
                LimboActive=true;
                if(PLACE>GStart.Length) 
                PLACE=1;
                else
                PLACE++;

                 coin.changeMap=false;
                
            }



            groundCounter=true;

            generateGround();
            if(totalTime*0.8f>=totorandom)
            Groundwillfall(newObject);
             
             //Limbogenerate();

             if(LimboActive)
             {
                Limbogenerate();
                LimboActive=false;
             }
            
          
            
        }
         if(Limbo==2)
        {
            StartCoroutine(backGrControl.NewMAp(PLACE-1));
            Limbo++;
        }
        
        
    }
    void Limbogenerate()
    {
       
        //// newObject =   tổ hợp mặc đất
        int rand=Random.Range(5,10);
        float x=ChangingMid.GetComponent<BoxCollider2D>().size.x;
       Vector2 firstpos=pos;
       firstpos.y=ChangingStart.transform.position.y;
         Instantiate(ChangingStart,firstpos,quaternion.identity);
        firstpos.x=firstpos.x+ChangingStart.GetComponent<BoxCollider2D>().size.x/2+x/2;
        for(int i=1;i<=rand-2;i++)
        {
            
            Instantiate(ChangingMid,firstpos,quaternion.identity);
            firstpos.x=firstpos.x+x;
        }
        Instantiate(ChangingEnd,firstpos,quaternion.identity);
    }



    void generateGround()
    {

       /* float h1 = player.Jumpvel * player.Jumpvel;
        float g =player.GetComponent<Rigidbody2D>().gravityScale * 9.81f;
        float h2 = 2 * g;
        float maxJumpHeight = h1 /h2;
        float maxY = maxJumpHeight * 0.7f;
        maxY += -7;
        float minY = -7;
        float actualY = Random.Range(minY, maxY);
        // Spawn dis để tính toán khoảng cách 2 obj
        float SpawnDis=4;*/
        
        float gravity = player.GetComponent<Rigidbody2D>().gravityScale * Physics2D.gravity.y;
        float Jumpvel=player.Jumpvel;
        float timeToApex = Jumpvel / -gravity;
        totalTime = timeToApex * 2;

        float totalDistance = player.velocity.x * totalTime;
        
        totorandom = Random.Range(0, totalTime);

        float x = (player.velocity.x * totorandom)*2;
        float y = ((Jumpvel * totorandom + 0.5f * gravity * totorandom * totorandom)*2)* 0.7f;

       // test=totalTime;
        
            
        GameObject Ground,Start,End;
        int Ran=Random.Range(0,Grounds.Length);
        Ground= Grounds[MAP];
        Start= GStart[MAP];
        End=GEnd[MAP];

        // if(Place==UndeGr) 
        // {
        //     Ground= Grounds[Random.Range(0,Grounds.Length)];
        // }
        // else if(Place==Above)
        // {
        //      Ground= Grounds[Random.Range(0,Grounds.Length)];
        // }  
        // else
        // {
        //     Ground= Grounds[Random.Range(0,Grounds.Length)];
        // }
        
        
        // float y=Ground.transform.position.y+Ground.GetComponent<Renderer>().bounds.size.y/2;                                    //InsertListItem here
        // float t = CalculateTimeToReachY(Jumpvel,gravity,y);
        
        // float x = (player.velocity.x * t)*2*0.6f;
        
        

        
        
        float actualY =Ground.transform.position.y;//transform.position.y + y - Ground.GetComponent<Renderer>().bounds.size.y/2;
        float actualX =(transform.position.x+x+Ground.GetComponent<Renderer>().bounds.size.x/2);
        
        //Tye of spawned terrain
        int random=Random.Range(0,100);
        
        if(random>=55)
        pos = new Vector2(actualX-x/2 , actualY);
        else if (random<=35)
        {
        RandomBuff(totalTime,Jumpvel,gravity);  
        pos = new Vector2(actualX, actualY);
        }
        else
        pos = new Vector2(actualX-x, actualY);

        
        random2=Random.Range(2,10);
        newObject = new GameObject[random2];///// newObject =   tổ hợp mặc đất
        
       StartingPos=pos;
         newObject[0] =Instantiate(Start,pos,quaternion.identity);
        pos.x=pos.x+Ground.GetComponent<Renderer>().bounds.size.x;
        if(random2>2)
        Posii=pos;
        for(int i=1;i<=random2-2;i++)
        {
            
            newObject[i]=Instantiate(Ground,pos,quaternion.identity);
            pos.x=pos.x+Ground.GetComponent<Renderer>().bounds.size.x;
        }
        newObject[random2-1]=Instantiate(End,pos,quaternion.identity);
    
        
      
    }



        private void Groundwillfall(GameObject[] newobject)
        {
            int random=Random.Range(1,3);
            if(random==1)
            {
                Grounds grounds=newobject[0].GetComponent<Grounds>();
                grounds.Thisfall=true;
                grounds.numofElement=newobject.Length;
                grounds.Groundg=newObject;
            }


            //for ENEMY SPAWMER
           //newobject[newObject.Length-4].GetComponent<Grounds>().MonsterPlace=true;
           
           //   gameObject.GetComponent<Renderer>().material.color = Color.yellow;
           if(newObject.Length>5)
           {
                Vector2 A=newobject[newObject.Length-3].transform.position;
                
                 PostoSendEnemyJump.transform.position=A;
              //  PostoSendEnemyJump.GetComponent<Renderer>().material.color = Color.yellow;
                
           }
           
        }


        

        private void RandomBuff(float t,float Jumpvel,float gravity)
        {

            

            float x = (player.velocity.x * t)*2.5f;
        float y = ((Jumpvel * t + 0.5f * gravity * t * t)*2)* 0.7f;
            Vector2 posi=new Vector2(x,y);


           int HaveBuff= Random.Range(1,100);
           if(HaveBuff<=100)
           {
            //randombuff go pru72
            int randomBuff =Random.Range(1,100);
            if(randomBuff<50)
            {
                if(hPnMETTER.shield<=4)
                Instantiate(Shield,posi,quaternion.identity);
                else
                Instantiate(HP,posi,quaternion.identity);
            }
            else
            {
                Instantiate(HP,posi,quaternion.identity);
            }
            
           } 
        }

        private float CalculateTimeToReachY(float initialVelocity, float gravity, float targetY)
    {
        // Using the kinematic equation: y = v0 * t + 0.5 * a * t^2
        // 0.5 * a * t^2 + v0 * t - targetY = 0
        // Solve for t using the quadratic formula: t = (-b ± √(b² - 4ac)) / 2a

        float a = 0.5f * gravity;
        float b = initialVelocity;
        float c = -targetY;

        float discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            // No real solution, target Y is not reachable
            return -1f;
        }

        // Calculate both possible times and return the positive one
        float sqrtDiscriminant = Mathf.Sqrt(discriminant);
        float t1 = (-b + sqrtDiscriminant) / (2 * a);
        float t2 = (-b - sqrtDiscriminant) / (2 * a);
            
        // Return the valid positive time
        if (t1 >= 0 && t2 >= 0)
        {
            return Mathf.Min(t1, t2); 
           
        }
        else if (t1 >= 0)
        {
            return t1;
        }
        else if (t2 >= 0)
        {
            return t2;
        }

        return -1f; // No valid positive time
    }
    
    
}

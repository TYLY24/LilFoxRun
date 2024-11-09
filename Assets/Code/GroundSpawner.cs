using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool groundCounter=true,HaveBasement = false,Groundwillfal=false;
    [SerializeField] public Vector2 StartingPos,pos,Posii;


[SerializeField] private GameObject[] Grounds,newObject;
[SerializeField] private GameObject GStart,GEnd,Shield,HP;

    [SerializeField] float Above=10,UndeGr=-10;
    Player player;
     [SerializeField] Camera cameraManin;
     public GameObject PostoSendEnemyJump;
    [SerializeField] public int random2=1,World=1;

       
        HPnMETTER hPnMETTER;
   


    

    
    
    
void OnTriggerEnter2D(Collider2D square)
    {
 
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnTriggerExit2D(Collider2D square)
    {

        if (square.CompareTag("Finish"))
        {
            //Debug.Log("Triggered the special Box Collider 2D!");
            // Add your logic here
            groundCounter =false;
        }


        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
    // Update is called once per frame

    /*void Start()
    {

        offset=transform.position-cameraManin.transform.position;
    }*/
    private void Awake()
    {
        player= GameObject.Find("me").GetComponent<Player>();
       hPnMETTER= GameObject.Find("me").GetComponent<HPnMETTER>();
        
    }
    void Update()
    {
        //transform.position=cameraManin.transform.position + offset;
        

        if(!groundCounter)
        {
            
            generateGround(0);
            Groundwillfall(newObject);
             
             groundCounter=true;
            
        }
        // if(newObject[0].GetComponent<Grounds>().isfalling==true)
        //     {
        //         for(int i=1;i<newObject.Length;i++)
        //     {
        //         newObject[i].GetComponent<Grounds>().isfalling=true;
        //     }
        //     }
        
        
    }
    void generateGround(float Place)
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
        float totalTime = timeToApex * 2;

        float totalDistance = player.velocity.x * totalTime;
        /*
        float t = Random.Range(0, totalTime);

        float x = (player.velocity.x * t)*2;
        float y = ((Jumpvel * t + 0.5f * gravity * t * t)*2)* 0.7f;

        test=totalTime;
        
            */
        GameObject Ground;
        int Ran=Random.Range(0,Grounds.Length);
        if(Place==UndeGr) 
        {
            Ground= Grounds[Random.Range(0,Grounds.Length)];
        }
        else if(Place==Above)
        {
             Ground= Grounds[Random.Range(0,Grounds.Length)];
        }  
        else
        {
            Ground= Grounds[Random.Range(0,Grounds.Length)];
        }
        
        
        float y=Ground.transform.position.y+Ground.GetComponent<Renderer>().bounds.size.y/2;                                    //InsertListItem here
        float t = CalculateTimeToReachY(Jumpvel,gravity,y);
        
        float x = (player.velocity.x * t)*2*0.6f;
        
        

        
        
        float actualY =Place+Ground.transform.position.y;//transform.position.y + y - Ground.GetComponent<Renderer>().bounds.size.y/2;
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
         newObject[0] =Instantiate(GStart,pos,quaternion.identity);
        pos.x=pos.x+Ground.GetComponent<Renderer>().bounds.size.x;
        if(random2>2)
        Posii=pos;
        for(int i=1;i<=random2-2;i++)
        {
            
            newObject[i]=Instantiate(Ground,pos,quaternion.identity);
            pos.x=pos.x+Ground.GetComponent<Renderer>().bounds.size.x;
        }
        newObject[random2-1]=Instantiate(GEnd,pos,quaternion.identity);
    
        
      
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

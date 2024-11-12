using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinBuffEnemy : MonoBehaviour
{
    public int Level=5;
    bool SpawnTime=false;
    GroundSpawner groundSpawner;
    [SerializeField]GameObject obtacle,Coin,Enemy,Eagel;
    [SerializeField]GameObject[] Trap;
     private Camera mainCamera;
     public float LocationY;
     //int NumOfEnemy;
     [SerializeField] Player player;
     [SerializeField] Vector2 test;
     //public GameObject Player;

     [SerializeField] Vector2 ObtacSize;

        List<int> MonsterOption = new List<int> {1, 2, 3},
                RandomSpawn=new List<int> {1, 2};//if EMPTY = MAX AMOUNT OF MOB

    private void Start()
    {
     mainCamera = Camera.main;

    }
    private void Awake()
    {
        groundSpawner = GetComponent<GroundSpawner>();
        //player= Player.GetComponent<Player>();
        ObtacSize=obtacle.GetComponent<Renderer>().bounds.size;
    }
    void OnTriggerExit2D(Collider2D square)
    {

        if (square.CompareTag("Finish"))
        {
           SpawnTime=true;
            //Spawn();
           // Random.Range(0,5);
        }

    }

    void Update()
    {
        if(SpawnTime)
        {
            Spawn();
            // if(groundSpawner.random2>3)
            // SpawnTrap(groundSpawner.StartingPos);
            // if(groundSpawner.random2>5)
            // SpawnEnemy(groundSpawner.StartingPos);
            
           
            // SpawnCoin(groundSpawner.StartingPos);
             SpawnTime=false;
        }
    }

    void Spawn()
    {
        SpawnCoin(groundSpawner.StartingPos);

        for(int i=1; i<=Level;i++)
        {   
            if(RandomSpawn.Count>0)
            {
                    int RandomEnemyType=RandomSpawn[Random.Range(0, RandomSpawn.Count)];
                switch (RandomEnemyType)
                {
                    case 1:
                    if(groundSpawner.random2>3)
                        {
                            SpawnTrap(groundSpawner.StartingPos);
                            RandomSpawn.Remove(RandomEnemyType);
                        }
                        
                        break;
                    case 2:
                    if(groundSpawner.random2>5)
                    {
                        if(MonsterOption.Count==1)
                        RandomSpawn.Remove(RandomEnemyType);

                        int random= MonsterOption[Random.Range(0, MonsterOption.Count)];
                        SpawnEnemy(groundSpawner.StartingPos,random);
                        MonsterOption.Remove(random);
                    }
                        
                        break;
                }
            }
                
        }
        //ADD HERE if ADD MOb
        RandomSpawn=    new List<int> {1, 2};
        MonsterOption= new List<int> {1, 2, 3};
    }






    void SpawnCoin(Vector2 pos)
    {
        float Distan=ObtacSize.x/2;
        if(groundSpawner.random2>2)
        {
            Vector2 Psition;
        Psition.y =pos.y+ ObtacSize.y/2 + Coin.GetComponent<Renderer>().bounds.size.y;
        Psition.x =pos.x;
        for(int i =0;i<groundSpawner.random2*2-3;i++)
        {
            Psition.x= Psition.x+Distan;
            Instantiate(Coin,Psition,quaternion.identity);
        }
        
        }

    }
    void SpawnTrap(Vector2 pos)
    {
        int randomTrap =Random.Range(0,Trap.Length);
        Vector2 posi=pos;
        float X=ObtacSize.x;
        float random=Random.Range(pos.x+X,pos.x+ObtacSize.x*(groundSpawner.random2-2));
        posi.x=random;
        posi.y=pos.y+ObtacSize.y/2+Trap[randomTrap].GetComponent<Renderer>().bounds.size.y/2;
        
        
        Instantiate(Trap[randomTrap],posi,quaternion.identity);



    }
    void SpawnEnemy(Vector2 pos,int random)
    {
        
        Vector2 posi;
        
         posi.y=pos.y+ ObtacSize.y/2+Enemy.GetComponent<Renderer>().bounds.size.y;
        LocationY=posi.y;
        
        

        if(random==2)
            {
                
                posi.x=pos.x+ObtacSize.x*(groundSpawner.random2-2);
                 Instantiate(Enemy,posi,quaternion.identity);
            
            } 
        else if(random==3)
            {
                Vector3 EnemyCorners = mainCamera.WorldToViewportPoint(gameObject.GetComponent<Renderer>().bounds.min);
                Vector2 Place;
                Vector3 YEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
            //  Vector3 XEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
                Place.y=YEdge.y+Enemy.GetComponent<Renderer>().bounds.size.y;
                
                int randomplace=Random.Range(1,2);
                if(randomplace==1)
                Place.x=pos.x+ObtacSize.x*(groundSpawner.random2-3);
                
                else 
                
                Place.x=pos.x;//+obtacle.GetComponent<Renderer>().bounds.size.x*(groundSpawner.random2-5);

                test=Place;

                Instantiate(Enemy,Place,quaternion.identity);
            
            } 
        else
            {
               
                posi.x=pos.x+ObtacSize.x*(groundSpawner.random2-1);
                Instantiate(Enemy,posi,quaternion.identity);
            }
        
        
    }

    // void JumpScare(GameObject Jumpscare)//TESTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
    // {
    //     Jumpscare.GetComponent<Renderer>().material.color = Color.yellow;
    //     Vector2 A =groundSpawner.PostoSendEnemyJump.transform.position;
    //     A.y=groundSpawner.PostoSendEnemyJump.transform.position.y+groundSpawner.PostoSendEnemyJump.GetComponent<Renderer>().bounds.size.y/2;
    //     test=A;
    //     if(groundSpawner.PostoSendEnemyJump.GetComponent<Grounds>().Canfall)
    //     {
    //         Jumpscare.GetComponent<Enemy>().JumPlace=A;
    //         Jumpscare.GetComponent<Enemy>().JumP=true;
           
    //     }
    //    // JumpScareEnemy=null;
    // }


    // void jumpScare(Vector2 pos)
    // {
    //     {
    //             Vector3 EnemyCorners = mainCamera.WorldToViewportPoint(gameObject.GetComponent<Renderer>().bounds.min);
    //         Vector2 Place;
    //         Vector3 YEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
    //         Vector3 XEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
    //         Place.y=YEdge.y+Enemy.GetComponent<Renderer>().bounds.size.y;
    //         int randomplace=Random.Range(1,3);
    //         if(randomplace==1)
    //         Place.x=pos.x+obtacle.GetComponent<Renderer>().bounds.size.x*(groundSpawner.random2-3);
    //         else if(randomplace==2)
    //         Place.x=YEdge.x+Enemy.GetComponent<Renderer>().bounds.size.x;
    //         else 
            
    //         Place.x=XEdge.x;

    //         Instantiate(Enemy,Place,quaternion.identity);

            

    //         }
    // }

}
    
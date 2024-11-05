using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinBuffEnemy : MonoBehaviour
{
    bool SpawnTime=false;
    GroundSpawner groundSpawner;
    [SerializeField]GameObject obtacle,Coin,Enemy;
    [SerializeField]GameObject[] Trap;
     private Camera mainCamera;
     public float LocationY;
     int NumOfEnemy;
     Player player;
     [SerializeField] Vector2 test;
     public GameObject Player;

     [SerializeField] Vector2 testFall,ObtacSize;

    private void Start()
    {
     mainCamera = Camera.main;

    }
    private void Awake()
    {
        groundSpawner = GetComponent<GroundSpawner>();
        player= Player.GetComponent<Player>();
        ObtacSize=obtacle.GetComponent<Renderer>().bounds.size;
    }
    void OnTriggerExit2D(Collider2D square)
    {

        if (square.CompareTag("Finish"))
        {
            SpawnTime=true;
            Random.Range(0,5);
        }

    }

    void Update()
    {
        if(SpawnTime)
        {
            if(groundSpawner.random2>3)
            SpawnTrap(groundSpawner.StartingPos);
            if(groundSpawner.random2>5)
            SpawnEnemy(groundSpawner.StartingPos);
            
           
            SpawnCoin(groundSpawner.StartingPos);
            SpawnTime=false;
        }
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
    void SpawnEnemy(Vector2 pos)
    {
        int random=Random.Range(1,3);
        Vector2 posi;
        posi.x=pos.x+ObtacSize.x*(groundSpawner.random2-1);
        posi.y=pos.y+ ObtacSize.y/2+Enemy.GetComponent<Renderer>().bounds.size.y;
        LocationY=posi.y;
        
        Instantiate(Enemy,posi,quaternion.identity);

        if(random>=2)
        {
            posi.x=pos.x+ObtacSize.x*(groundSpawner.random2-2);
        
        
        Instantiate(Enemy,posi,quaternion.identity);

            if(random>=3)
            {
                Vector3 EnemyCorners = mainCamera.WorldToViewportPoint(gameObject.GetComponent<Renderer>().bounds.min);
            Vector2 Place;
            Vector3 YEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
          //  Vector3 XEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
            Place.y=YEdge.y+Enemy.GetComponent<Renderer>().bounds.size.y;
            
            int randomplace=Random.Range(3,3);
            if(randomplace==1)
            Place.x=pos.x+ObtacSize.x*(groundSpawner.random2-3);
            else if(randomplace==2)
            Place.x=YEdge.x+ObtacSize.x*groundSpawner.random2;
            else 
            
            Place.x=pos.x;//+obtacle.GetComponent<Renderer>().bounds.size.x*(groundSpawner.random2-5);

            test=Place;

            Instantiate(Enemy,Place,quaternion.identity);
            
            }
            
            //this is for jumping Enemy
            
            
            
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
    
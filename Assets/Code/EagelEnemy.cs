using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EagelEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool onscreen,Hello=false,WaitAtack=true,Hit=false;
    Vector3 screenPoint;
    Camera mainCamera;
     GameObject Player,Enemyplace;
     [SerializeField] Vector2 direction,AtakP;
     
     Animator animator;
     BoxCollider2D boxCollider2D;
    [SerializeField] float Speed=1f,DiveSpeed=3f;
    Rigidbody2D rigidbody2Ds;
    void Start()
    {
        animator=GetComponent<Animator>();
        Enemyplace=GameObject.Find("EnemyPlace");
        Player=GameObject.Find("me");
        mainCamera=Camera.main;
        AtakP=transform.position;
        AtakP.x=(transform.position.x-Player.transform.position.x)/2;
        direction = (Player.transform.position - (Vector3)AtakP).normalized;
        boxCollider2D=GetComponent<BoxCollider2D>();
        StartCoroutine(Bird());
        rigidbody2Ds=GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Finish")||collision.gameObject.CompareTag("StartPoint"))
       {    
            Hit=true;
            animator.SetBool("Hurti",true);
          //  boxCollider2D.isTrigger=true;

       }
       
    }
    void OnTriggerEnter2D(Collider2D Square)
   {
    
      if(Square.gameObject.CompareTag("Ded"))
      ded();
    
   }
    // Update is called once per frame
    IEnumerator Bird()
    {
        
        float A=Random.Range(1,3);
        yield return new WaitForSeconds(A);
        Hello=true;
        
    }
    void Update()
    {
        if(Hello)
        {

            Vector2 Pos=transform.position;
            if(AtakP.x<transform.position.x)
            {
                Pos.x-=Speed*Time.deltaTime;
                transform.position=Pos;
            }else
            {
                if(WaitAtack)
                {
                    StartCoroutine(Bird());
                    WaitAtack=false;
                }
                
                Attack();
               
            }
            
        }
    }

    public void Hurt()
    {
        //animator.SetBool("Hurti",false);
        
        rigidbody2Ds.constraints=RigidbodyConstraints2D.None;
        rigidbody2Ds.velocity=Vector2.up*18f;
        boxCollider2D.isTrigger=true;
    }

    private void Attack()
    {
        if(!Hit)
        {
            animator.SetBool("Attack",true);
            transform.position += (Vector3)direction * DiveSpeed * Time.deltaTime;
        }
        

    }
    void ded()
    {
        Destroy(gameObject);
    }
}

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
    void Start()
    {
        animator=GetComponent<Animator>();
        Enemyplace=GameObject.Find("EnemyPlace");
        Player=GameObject.Find("me");
        mainCamera=Camera.main;
        AtakP=transform.position;
        AtakP.x=(transform.position.x-Player.transform.position.x)*2/3;
        direction = (Player.transform.position - (Vector3)AtakP).normalized;
        boxCollider2D=GetComponent<BoxCollider2D>();
        StartCoroutine(Bird());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Finish")&&collision.gameObject.CompareTag("StartPoint")&&collision.gameObject.CompareTag("Ground"))
       {    
            Hit=true;
            animator.SetBool("Hurt",true);
          //  boxCollider2D.isTrigger=true;

       }
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

    private void Attack()
    {
        if(!Hit)
        {
            animator.SetBool("Attack",true);
            transform.position += (Vector3)direction * DiveSpeed * Time.deltaTime;
        }
        

    }
}

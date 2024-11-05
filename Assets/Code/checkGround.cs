using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{

    Player player;
    bool Groundne;
    // Start is called before the first frame update


    void OnTriggerStay2D(Collider2D collider2D)
        {
      if(collider2D.gameObject.CompareTag("Ground")||collider2D.gameObject.CompareTag("Finish")||collider2D.gameObject.CompareTag("StartPoint"))
    {
      //Debug.Log("MAT DAT SUP DO " + isGround + " đã đi vào vùng kích hoạt!");
      
    

      Groundne=true;
      

      //Debug.Log("MAT DAT SUP DO " + isGround + " đã đi vào vùng kích hoạt!");

    }
    else
    Groundne=false;
    
    }
     void OnCollisionEnter2D(Collision2D collision)
     {
       if(collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Finish")||collision.gameObject.CompareTag("StartPoint"))
       {
          Vector3 Normal =  collision.GetContact(0).normal;
          if(Normal==Vector3.up)
           player.MaxJump=2;
       }
      
     }
    // Update is called once per frame
    void Start()
    {
        player=transform.parent.gameObject.GetComponent<Player>();
    }
    void Update()
    {

      if(Groundne)
      player.isGround=true;
      else
      player.isGround=false;
    }
}

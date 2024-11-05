using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{

    
    Animator animator;
    [SerializeField] int Type=7;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D Square)
   {
    
     
    if(Square.gameObject.CompareTag("Player")||Square.gameObject.CompareTag("Enemy"))
    {
        
        animator.SetTrigger("Ded");
       Destroyit();
        
    }
    
    
   }
    void Start()
    {
        
        animator=GetComponent<Animator>();
        Type=Random.Range(0,7);
         animator.SetInteger("TypeFruit", Type);
    }
    void Destroyit()
    {
         Destroy(gameObject);
    }
    // Update is called once per frame
}

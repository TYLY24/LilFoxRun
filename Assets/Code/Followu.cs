using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform me;
    [SerializeField] private float FollowSpeed=2f,ShakaDistant,ShakeSpeed;
    //[SerializeField] bool isShake =false;
    

    Vector3 offset;

    
    
    
    void Start()
    {
        offset=transform.position-me.position;
    }

    // Update is called once per frame
    
    void Update()
    {
       Vector3 newPos= new Vector3(me.position.x,me.position.y,-10f);
       transform.position= Vector3.Slerp(transform.position,newPos+offset,FollowSpeed*Time.deltaTime);

      

    }
    
}

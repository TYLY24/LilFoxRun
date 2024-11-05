using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isfalling=false,BoxCheck=false,Thisfall=false;
    public int numofElement;
    [SerializeField] float FallSpeed=1;
    public GameObject[] Groundg;
    Vector2 origin,Boxsize;
    public Camera mainCamera;
    [SerializeField] LayerMask Pl;

    ShakingCam shakingCam;
    //Renderer objectRenderer;

    void Start()
    {
        //objectRenderer = GetComponent<Renderer>();
         mainCamera = Camera.main;
        // Check the tag of the GameObject this script is attached to
        if (CompareTag("StartPoint")&&Thisfall)
        {
            shakingCam=GameObject.Find("Virtual Camera").GetComponent<ShakingCam>();
            BoxCheck=true;
            // Do something specific for GameObject A
            sizeCalculate();
        }
    }

    
   
    void Update()
    {
        // if(MonsterPlace)
        // {
        //     Vector3 Adudu =transform.position;
        //     Adudu.y=transform.position.y+GetComponent<Renderer>().bounds.size.y/2;
        //     Vector3 screenPoint = mainCamera.WorldToViewportPoint(Adudu);
        // bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        // if (onScreen)
        // {
        //     GetComponent<Renderer>().material.color = Color.yellow;
            
        //     //Debug.Log("Siuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
        // }
            
        //}
        
        if(BoxCheck)
        {
            origin=transform.GetComponent<BoxCollider2D>().bounds.center;
            origin.y+=GetComponent<Renderer>().bounds.size.y/2+0.1f;
           // DrawBoxCastDebug(origin, Boxsize,Boxsize.x*numofElement/2);
            
            if(isStartFall())
            {
                isfalling=true;
            
            }
            
        }
        if(isfalling)
        {
            Groundwillfal();
                for(int i=1;i<Groundg.Length;i++)
            {
                Groundg[i].GetComponent<Grounds>().isfalling=true;
            }
        }
    }

    void sizeCalculate()
    {
        Pl= LayerMask.GetMask("Player");
        
            Boxsize.x=GetComponent<Renderer>().bounds.size.x;
            Boxsize.y=0.1f;
            
    }


    public bool isStartFall()
    {
        
      if(Physics2D.BoxCast(origin,Boxsize,0,Vector2.right,Boxsize.x*numofElement/2,Pl))
      {
        
        return true;
      }
      else
      {
        
        return false;
      }
    }

    private void Groundwillfal()
        {
            
                Vector2 pos=transform.position;
                if(pos.y+(GetComponent<Renderer>().bounds.size.y/2)>-4.5)
                {
                float fallAmout=FallSpeed*Time.deltaTime;
                pos.y-=fallAmout;
                transform.position=pos;
                shakingCam.isShakaShaka=true;
                }
                else
                {
                    shakingCam.isShakaShaka=false;
                }
                
            
        }

    //  void DrawBoxCastDebug(Vector2 origin, Vector2 size, float distance)
    // {
    //     // Calculate the half-size of the box
    //     Vector2 halfSize = size / 2;

    //     // Calculate the four corners of the box
    //     Vector2 topLeft = origin + new Vector2(-halfSize.x, halfSize.y);
    //     Vector2 topRight = origin + new Vector2(halfSize.x, halfSize.y);
    //     Vector2 bottomLeft = origin + new Vector2(-halfSize.x, -halfSize.y);
    //     Vector2 bottomRight = origin + new Vector2(halfSize.x, -halfSize.y);

    //     // Draw the box
    //     Debug.DrawLine(topLeft, topRight, Color.red);
    //     Debug.DrawLine(topRight, bottomRight, Color.red);
    //     Debug.DrawLine(bottomRight, bottomLeft, Color.red);
    //     Debug.DrawLine(bottomLeft, topLeft, Color.red);

    //     // Draw lines representing the cast direction
    //     Debug.DrawLine(topRight, topRight + Vector2.right * distance, Color.green);
    //     Debug.DrawLine(bottomRight, bottomRight + Vector2.right * distance, Color.green);
    // }
}

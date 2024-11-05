using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GoGogo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Depth=1;
    [SerializeField] float test,test1;

    [SerializeField]public bool Destroyit=true,Run =true;
    Player player;
    ShakingCam shakingCam;
    Grounds grounds;
    bool isfal;
    BoxCollider2D boxCollider2D;
     private Camera mainCamera;

    private void Awake()
    {
        player= GameObject.Find("me").GetComponent<Player>();
        shakingCam=GameObject.Find("Virtual Camera").GetComponent<ShakingCam>();
       boxCollider2D= gameObject.GetComponent<BoxCollider2D>();
        
    }

    private void Start()
    {
     mainCamera = Camera.main;
     grounds=GetComponent<Grounds>();
    }
    void FixedUpdate()
    {

        if(Run)
        {
            Vector2 RealVel= player.velocity/Depth;
        Vector2 pos = transform.position;
        pos.x -=RealVel.x * Time.fixedDeltaTime;
        transform.position=pos;
        }
        
        
        
        

    }

void Update()
{
    Byebye();
}

    void Byebye()
    {

        if(Destroyit)
        if (isOffScreen())
        {
            Destroy(gameObject);
            if(CompareTag("Finish")&&grounds.isfalling)
        {
            shakingCam.isShakaShaka=false;
        }
        }
    }

    public bool isOffScreen()
    {
        //    float halfX=gameObject.transform.localScale.x / 2;
        //float hlafY=gameObject.GetComponent<Renderer>().bounds.size.y/2;

        //Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        Vector3[] objectCorners = new Vector3[2];
        objectCorners[0] = mainCamera.WorldToViewportPoint(boxCollider2D.bounds.max);
        objectCorners[1] = mainCamera.WorldToViewportPoint(new Vector3(boxCollider2D.bounds.max.x, boxCollider2D.bounds.min.y, boxCollider2D.bounds.min.z));

        test=objectCorners[0].x;
        test1= objectCorners[1].x;

        if(objectCorners[0].x<0 || objectCorners[1].x<0)
        {
            return true;
        }
        




        return false;
    }
}

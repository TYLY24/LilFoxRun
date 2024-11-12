using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    // Start is called before the first frame update
    GoGogo go;
    public float NewgoBack,boxsize,X,NewX;
    public int NumofBg=2,Map;
    [SerializeField] Sprite[] bg;
    public bool ChangeMap;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    public Vector2 goBack;
    void Awake()
    {
        X=GetComponent<SpriteRenderer>().bounds.size.x;
        goBack=GetComponent<SpriteRenderer>().bounds.size;
        go= GetComponent<GoGogo>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        boxCollider2D=GetComponent<BoxCollider2D>();
       
        
       // ChangeBg(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(go.isOffScreen())
        {
            Vector2 Place=transform.position;
            Place.x=Place.x+goBack.x*NumofBg;
            transform.position=Place;
        }
        if(ChangeMap)
        {
            ChangeBg(Map);
            ChangeMap=false;
        }
        
    }

    public void ChangeBg(int N)
    {
       
        spriteRenderer.sprite=bg[N];
        NewX=spriteRenderer.bounds.size.x;
        NewgoBack=spriteRenderer.sprite.bounds.size.x;
        goBack.x=spriteRenderer.bounds.size.x;
        boxCollider2D.size=new Vector3(NewgoBack, boxCollider2D.size.y);
        X=NewX;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    // Start is called before the first frame update
    GoGogo go;
    float goBack;
    [SerializeField] int NumofBg=2;
    void Start()
    {
        go= GetComponent<GoGogo>();
        goBack=GetComponent<BoxCollider2D>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(go.isOffScreen())
        {
            Vector2 Place=transform.position;
            Place.x=Place.x+goBack*NumofBg;
            transform.position=Place;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BackGrControl : MonoBehaviour
{

    public int MAP=3 ;
    // Start is called before the first frame update
   [SerializeField] GameObject[] BG1,BG2;
   [SerializeField] GameObject BG;
   [SerializeField] Sprite [] Bg;

   [SerializeField] Vector2 StarPointBG1,StarPointBG2;
   
   [SerializeField] Paralax[] paralaxes1,paralaxes2;
   float X1,X2;
    void Start()
    {
        StarPointBG1=BG1[0].transform.position;
        StarPointBG2=BG2[0].transform.position;
        // X1=BG1[0].GetComponent<SpriteRenderer>().bounds.size.x;
        // X2=BG2[0].GetComponent<SpriteRenderer>().bounds.size.x;
        paralaxes1=new Paralax[BG1.Length];
        for(int i=0;i<BG1.Length;i++)
        {
            paralaxes1[i]=BG1[i].GetComponent<Paralax>();
        }

        paralaxes2=new Paralax[BG2.Length];
        for(int i=0;i<BG2.Length;i++)
        {
            paralaxes2[i]=BG2[i].GetComponent<Paralax>();
        }

        //StartCoroutine(NewMAp(3 ));
    }

    // Update is called once per frame
    public IEnumerator NewMAp(int M)
    {
        Vector2 A=StarPointBG1;
        for(int i=0;i<BG1.Length;i++)
        {
            
            paralaxes1[i].Map=M;
            paralaxes1[i].ChangeMap=true;
           
           BG1[i].transform.position=A;
           Vector2 Loca = BG1[i].transform.position;

                switch (M)
                {
                    case 1:
                        Loca.y += 7f;
                        BG1[i].transform.position = Loca;
                        break;
                        
                    case 2:
                        BG.GetComponent<SpriteRenderer>().sprite=Bg[0];
                        BG.SetActive(true);
                        if (i == 0 || i % 2 == 0)
                        {
                            Loca.y += 3f;
                        }
                        else
                        {
                            Loca.y += 10f;
                        }
                        BG1[i].transform.position = Loca;
                        break;
                    case 3:
                     BG.GetComponent<SpriteRenderer>().sprite=Bg[1];
                        
                        break;
                }

            
           
           yield return new WaitUntil(() => paralaxes1[i].NewX==paralaxes1[i].X);
           A.x+=paralaxes1[i].X;
        }
        A=StarPointBG2;
        for(int i=0;i<BG2.Length;i++)
        {
            paralaxes2[i].Map=M;
            paralaxes2[i].ChangeMap=true;
            BG2[i].transform.position=A;
            if(M==3)
            {
                
                   // BG2[i].transform.TransformPoint(Vector3.down*10f);
                Vector2 Loca2 = BG2[i].transform.localPosition;
                
                Loca2.y -= 5f;
                
                 BG2[i].transform.localPosition = Loca2;
                      
            }
           
           
            yield return new WaitUntil(() => paralaxes2[i].NewX==paralaxes2[i].X);
           A.x+=paralaxes2[i].X;
        }
    }
}

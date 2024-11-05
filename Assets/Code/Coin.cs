using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

//     HPnMETTER hPnMETTER;

    public SaveInfo InfoToSave;
     public Text Meter,Fruit ;
    public GameObject Pl,UIControl,SaveManage,Shop;
    public SaveNLoad saveNLoad;
    Player player;
    public float Meterr=0,test=0,test1=0;
    UIControl uIControl;
    public int apple=0, LVApple;

    ShopContents shopContents;
    

      void Start()
    {
      shopContents=Shop.GetComponent<ShopContents>();
        saveNLoad=SaveManage.GetComponent<SaveNLoad>();
        player=Pl.GetComponent<Player>();
        uIControl=UIControl.GetComponent<UIControl>();
        
    }
      void Update()
    {
        M();
        Fruits();
        if(player.isDEAD&&test1==0)
        {
          SaveScore();
          test1++;
        }
         
    }


    void Fruits()
    {
      uIControl.targetf=apple;
      Fruit.text= ""+apple;
    }
    void M()
    {
      test+=Time.deltaTime;
      if(player.velocity.x!=0)
        Meterr= player.velocity.x *test+0.5f*player.Accelerate*test*test;
        uIControl.targetm=Meterr;
        Meter.text= (int)(Meterr)+ " m";
    }
    void SaveScore()
    {
      InfoToSave.Fruits+=apple;
      if(InfoToSave.Meters<Meterr)
      InfoToSave.Meters=(int)Meterr;
      shopContents.Shield=0;
      saveNLoad.Save();
    }
//     void Start()
//     {
//         hPnMETTER=GetComponent<HPnMETTER>();
//         test=hPnMETTER.FullHealth;
//     }
//     void OnColliderEnter2D(Collider2D Square)
//    {
//     Debug.Log("HeadSHOT====================================================================================================================");
//     if(Square.gameObject.CompareTag("Enemy"))
//     {
//         Debug.Log("HeadSHOT====================================================================================================================");
//         GetComponent<Rigidbody2D>().velocity=Vector2.left*2;
//         if(hPnMETTER.shield>0)
//          {
//             hPnMETTER.shield--;
//             hPnMETTER.Heart[hPnMETTER.FullHealth+hPnMETTER.shield].enabled=false;
//          }
//          else
//          {
//              hPnMETTER.currentHealth--;
            
//         }
        
//     }
//    }
}

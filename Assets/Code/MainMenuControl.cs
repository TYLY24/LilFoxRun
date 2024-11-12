using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MainMenuControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Text BestScore;
    public GameObject BestScoreLoca,Gameplayui,Me,shaka,Boss; 
    Player player;
    public GameObject[] Gogo;
    ShakingCam shakingCam;
    Coin coin;
    [SerializeField] GoGogo[] goGogos;
    Animator animatorPL;
    HPnMETTER hPnMETTER;
    Boss boss;
    Vector2 targetPosition;
    bool Hited=false;
    [SerializeField] float A,B,C;

    [SerializeField] AudioManager audioManager;
    [SerializeField] BackGrControl backGrControl;
   
    
    void Start()
    {
        hPnMETTER=Me.GetComponent<HPnMETTER>();
        boss=Boss.GetComponent<Boss>();
        shakingCam=shaka.GetComponent<ShakingCam>();
        animatorPL=Me.GetComponent<Animator>();
        player=Me.GetComponent<Player>();
        targetPosition= new Vector2(player.StartX,player.transform.position.y);
        coin=BestScoreLoca.GetComponent<Coin>();
        BestScore.text="Best: "+coin.InfoToSave.Meters+ "m";
        goGogos=new GoGogo[Gogo.Length];
        for(int i=0;i<Gogo.Length;i++)
        {
            Debug.Log("!"+i);
            goGogos[i]=Gogo[i].GetComponent<GoGogo>();
        }
    }

    // Update is called once per frame
    public void StartButton()
    {
        //StartCoroutine(backGrControl.NewMAp(0 ));
        //gameObject.SetActive(false);
        audioManager.PlayVfx(audioManager.ButtonBig);
        if(!Hited)
        {
            hPnMETTER.shield+=coin.InfoToSave.UpdateShieldsLV;
             hPnMETTER.FullHealth+=coin.InfoToSave.UpdateHPLV;
             hPnMETTER.currentHealth=hPnMETTER.FullHealth;
            StartCoroutine(CutScrence());
            
            Hited=true;
        }
        
        
    }

    

    IEnumerator CutScrence()
    {
        audioManager.StopBgm();
        audioManager.PlayVfx(audioManager.MonsterRoar);
        animatorPL.SetTrigger("Hurt");
        shakingCam.isShakaShaka=true;

        yield return new WaitForSeconds(1f);

        
            shakingCam.isShakaShaka=false;
        player.Chille=false;
        // A=(float)Math.Round(player.transform.position.x, 2);
        // B=(float)Math.Round(targetPosition.x, 2);
        
        //     player.transform.position= targetPosition;
        
        
        // //A=player.transform.position.x;
        // Debug.Log("Stage2Done");
        
        

        yield return new WaitUntil(() => player.Back==true );
        
        
        audioManager.PlayVfx(audioManager.MonsterRoar);
        animatorPL.SetTrigger("Hurt");
        
        boss.Helloo=true;
        boss.tCoro++;

        yield return new WaitUntil(() => boss.Cum==true );
        //shakingCam.isShakaShaka=false;

        Debug.Log("Stage3");
        audioManager.PlayBgm(audioManager.BgmRun);
        player.PLAYED=true;
        Gameplayui.SetActive(true);
       
        for(int i=0;i<Gogo.Length;i++)
        {
            goGogos[i].Run=true;
        }

        // this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text Meter,Fruit ;
    public float Duration=8,targetf=0,targetm=0;
    public float currentvalue=0;
    public GameObject Player,UIingame;
    MainMenuControl mainMenuControl;
    Player player;
    // Start is called before the first frame update
    public void retry()
    {
        SceneManager.LoadScene("GamePlay");
        mainMenuControl.StartButton();
    }
    public void BackmainMenu()
    {
        SceneManager.LoadScene("GamePlay");
    }
    void Start()
    {
        mainMenuControl=UIingame.GetComponent<MainMenuControl>();
        player=Player.GetComponent<Player>();
    }


    public void JUmpButton()
    {
        player.Jumpinginput();
    }
    IEnumerator Counter(float target,Text Taget)
    {
        ///Numer run system
        ///
        var Rate= target/Duration;
        while(currentvalue!=target)
        {
            currentvalue=Mathf.MoveTowards(currentvalue,target,Rate);
            Taget.text=((int)currentvalue).ToString();
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ShopSettingExitUI : MonoBehaviour
{
    public GameObject ExitPanel,Mainmenu,Shop,Setting;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioMixer Mymixer;
    [SerializeField] Slider musicSlider;
    // Start is called before the first frame update
    
// --------------------------SETTING PART---------------------
    public void SettingButton()
    {
        audioManager.PlayVfx(audioManager.ButtonBig);
        Setting.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }

     public void ExitSetting()
    {
        audioManager.PlayVfx(audioManager.ButtonSmall);
        Time.timeScale = 1;
        Setting.SetActive(false);
        Mainmenu.SetActive(true);
        
    }

// --------------------------SHOP PART---------------------

    public void ShopButton()
    {
        audioManager.PlayVfx(audioManager.ButtonBig);
        Shop.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }
    // Update is called once per frame

// --------------------------EXIT PART---------------------

    public void ExitButton()
    {
        audioManager.PlayVfx(audioManager.ButtonBig);        
        ExitPanel.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitUnCheck()
    {
        audioManager.PlayVfx(audioManager.ButtonSmall);
        Time.timeScale = 1;
        ExitPanel.SetActive(false);
        Mainmenu.SetActive(true);
        
    }

    public void ExitCheck()
    {
        audioManager.PlayVfx(audioManager.ButtonBig);
        Application.Quit();
    }



}

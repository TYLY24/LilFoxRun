using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class ShopSettingExitUI : MonoBehaviour
{
    public GameObject ExitPanel,Mainmenu,Shop,Setting,ClearDataYN;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioMixer Mymixer;
    [SerializeField] Slider musicSlider,masterSlider,SfxSlider, musicSlider2,masterSlider2,SfxSlider2;
    [SerializeField] SaveNLoad saveNLoad;
    // Start is called before the first frame update
    
    void Start()
    {
        if(PlayerPrefs.HasKey("musicVol"))
        {
            LoadVolume();
        }
        else
        {
            VolumeMusic();
            VolumeSfx();
            VolumeMaster();
        }
    }



// --------------------------SETTING PART---------------------
    public void SettingButton()
    {
        LoadVolume();
        audioManager.PlayVfx(audioManager.ButtonBig);
        Setting.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }
    // ------Clear PART------------
    public void ClearData()
    {
        ClearDataYN.SetActive(true);
    }
    public void No()
    {
        ClearDataYN.SetActive(false);
    }
    public void Yes()
    {       
        PlayerPrefs.DeleteAll();
        saveNLoad.ClearData();
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    // ----------------------------
     public void ExitSetting()
    {
        audioManager.PlayVfx(audioManager.ButtonSmall);
        Time.timeScale = 1;
        Setting.SetActive(false);
        Mainmenu.SetActive(true);
        
    }

    public void VolumeMusic()
    {
        float Vol=musicSlider.value;
        Mymixer.SetFloat("MusicVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("musicVol",Vol);
    }
    public void VolumeMusic2()
    {
        float Vol=musicSlider2.value;
        Mymixer.SetFloat("MusicVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("musicVol",Vol);
    }
    public void VolumeSfx()
    {
        float Vol=SfxSlider.value;
        Mymixer.SetFloat("SfxVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("sfxVol",Vol);
    }
    public void VolumeSfx2()
    {
        float Vol=SfxSlider2.value;
        Mymixer.SetFloat("SfxVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("sfxVol",Vol);
    }
    public void VolumeMaster()
    {
        float Vol=masterSlider.value;
        Mymixer.SetFloat("MasterVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("masterVol",Vol);
    }
    public void VolumeMaster2()
    {
        float Vol=masterSlider2.value;
        Mymixer.SetFloat("MasterVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("masterVol",Vol);
    }

    public void LoadVolume()
    {
        musicSlider2.value=musicSlider.value=PlayerPrefs.GetFloat("musicVol");
        SfxSlider2.value= SfxSlider.value=PlayerPrefs.GetFloat("sfxVol");
        masterSlider2.value=masterSlider.value=PlayerPrefs.GetFloat("masterVol");
        VolumeMusic();
        VolumeSfx();
        VolumeMaster();
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

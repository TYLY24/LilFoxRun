using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSettingExitUI : MonoBehaviour
{
    public GameObject ExitPanel,Mainmenu,Shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShopButton()
    {
        Shop.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }
    // Update is called once per frame
    public void ExitButton()
    {
        ExitPanel.SetActive(true);
        Mainmenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitUnCheck()
    {
        Time.timeScale = 1;
        ExitPanel.SetActive(false);
        Mainmenu.SetActive(true);
        
    }

    public void ExitCheck()
    {
        Application.Quit();
    }



}

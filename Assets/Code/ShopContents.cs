using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopContents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mainmenu,Coin;
    [SerializeField]AudioManager audioManager;
    
    Coin coin;
    public int FruitsLV=1,Shield,HPLV=1;
    int Moneys,PriceHP=30,PriceShield=80,PriceFruits=100;
    public Text TxtFruitsLV,TxtShield,TxtHPLV,TxtMoneys,TxtPriceHP,TxtPriceShield,TxtPriceFruits;
    void OnEnable()
    {
        Debug.Log("OPEMMMMMMM");
        coin=Coin.GetComponent<Coin>();
        audioManager.Music.volume=0.5f;

        SetBuy();
        
        CheckBuy();
        SetText();
    }

    // Update is called once per frame
    public void ExitUnCheck()
    {
        audioManager.Music.volume=1f;
        audioManager.PlayVfx(audioManager.ButtonSmall);
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Mainmenu.SetActive(true);
        
        
    }
    public void HPButton()
    {
        if(PriceHP<=Moneys)
        {
            audioManager.PlayVfx(audioManager.Buy);
            Moneys=Moneys-PriceHP;
            HPLV++;
            PriceHP+=150;
        }
        else
        audioManager.PlayVfx(audioManager.BuyDenied);
        //SAVE CALLL
        SaveBuy();
        coin.saveNLoad.Save();
        SetText();
        CheckBuy();
    }

    public void ShieldButton()
    {
        if(PriceShield<=Moneys)
        {
            audioManager.PlayVfx(audioManager.Buy);
            Moneys=Moneys-PriceShield;
            Shield++;
            if(Shield!=0)
            PriceShield*=2;
        }
        else
        audioManager.PlayVfx(audioManager.BuyDenied);
        //SAVE CALLL
        SaveBuy();
        coin.saveNLoad.Save();
        SetText();
        CheckBuy();
    }

    public void FruitsButton()
    {
        if(PriceFruits<=Moneys)
        {
            audioManager.PlayVfx(audioManager.Buy);
            Moneys=Moneys-PriceFruits;
            FruitsLV++;
            PriceFruits=(int)(PriceFruits*1.5);
        }
        else
        audioManager.PlayVfx(audioManager.BuyDenied);
        //SAVE CALLL
        SaveBuy();
        coin.saveNLoad.Save();
        SetText();
        CheckBuy();
    }


    void SetText()
    {
        if(FruitsLV<5)
        {
            TxtFruitsLV.text="LV. "+ (int)(FruitsLV);
            TxtPriceFruits.text= ""+(int)(PriceFruits);
        }
        else
        {
            TxtFruitsLV.text="LV. Max";
            TxtPriceFruits.text= "Max";
        }

        if(HPLV<5)
        {
            TxtHPLV.text="LV. "+ (int)(HPLV);
        TxtPriceHP.text= ""+(int)(PriceHP);
        }
        else
        {
            TxtHPLV.text="LV. Max";
            TxtPriceHP.text= "Max";
        }
        TxtShield.text="Have: "+ (int)(Shield); 
        if(Shield<3)
        {
                 
            TxtPriceShield.text= ""+(int)(PriceShield);
        }
        else
        {
            
            TxtPriceShield.text= "Max";
        }
        
        
        
        TxtMoneys.text= ""+(int)(Moneys);
    }
    void CheckBuy()
    {



        if(PriceHP>Moneys||HPLV>5)
         TxtPriceHP.color = Color.red;
        else
        TxtPriceHP.color = Color.white;

        if(PriceShield>Moneys||Shield>3)
         TxtPriceShield.color = Color.red;
        else
        TxtPriceShield.color = Color.white;

        if(PriceFruits>Moneys||FruitsLV>5)
         TxtPriceFruits.color = Color.red;
        else
        TxtPriceFruits.color = Color.white;


    }

    void SaveBuy()
    {
        coin.InfoToSave.Fruits=Moneys;
        coin.InfoToSave.UpdateFruitsLV=FruitsLV;
        coin.InfoToSave.UpdateFruitsPrice=PriceFruits;
        coin.InfoToSave.UpdateHPLV=HPLV;
        coin.InfoToSave.UpdateHPPrice=PriceHP;
        coin.InfoToSave.UpdateShieldsLV=Shield;
        coin.InfoToSave.UpdateShieldsPrice=PriceShield;
    }
    void SetBuy()
    {
        if(coin.InfoToSave.UpdateHPLV!=0)
        {
            Moneys=coin.InfoToSave.Fruits;
        FruitsLV=coin.InfoToSave.UpdateFruitsLV;
        PriceFruits=coin.InfoToSave.UpdateFruitsPrice;
        HPLV=coin.InfoToSave.UpdateHPLV;
        PriceHP=coin.InfoToSave.UpdateHPPrice;
        Shield=coin.InfoToSave.UpdateShieldsLV;
        if(Shield!=0)
        PriceShield=coin.InfoToSave.UpdateShieldsPrice;
        else
        PriceShield=coin.InfoToSave.UpdateShieldsPrice=80;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopContents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mainmenu,Coin;
    
    Coin coin;
    public int FruitsLV=1,Shield,HPLV=1;
    int Moneys,PriceHP=30,PriceShield=80,PriceFruits=100;
    public Text TxtFruitsLV,TxtShield,TxtHPLV,TxtMoneys,TxtPriceHP,TxtPriceShield,TxtPriceFruits;
    void Start()
    {
        coin=Coin.GetComponent<Coin>();
        SetBuy();
        
        CheckBuy();
        SetText();
    }

    // Update is called once per frame
    public void ExitUnCheck()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Mainmenu.SetActive(true);
        
    }
    public void HPButton()
    {
        if(PriceHP<=Moneys)
        {
            Moneys=Moneys-PriceHP;
            HPLV++;
            PriceHP+=150;
        }
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
            Moneys=Moneys-PriceShield;
            Shield++;
            PriceShield*=2;
        }
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
            Moneys=Moneys-PriceFruits;
            HPLV++;
            PriceFruits=(int)(PriceFruits*1.5);
        }
        //SAVE CALLL
        SaveBuy();
        coin.saveNLoad.Save();
        SetText();
        CheckBuy();
    }


    void SetText()
    {
        TxtFruitsLV.text="LV. "+ (int)(FruitsLV);
        TxtShield.text="Have: "+ (int)(Shield);
        TxtHPLV.text="LV. "+ (int)(HPLV);
        TxtPriceHP.text= ""+(int)(PriceHP);
        TxtPriceShield.text= ""+(int)(PriceShield);
        TxtPriceFruits.text= ""+(int)(PriceFruits);
        TxtMoneys.text= ""+(int)(Moneys);
    }
    void CheckBuy()
    {
        if(PriceHP>Moneys)
         TxtPriceHP.color = Color.red;
        else
        TxtPriceHP.color = Color.white;

        if(PriceShield>Moneys)
         TxtPriceShield.color = Color.red;
        else
        TxtPriceShield.color = Color.white;

        if(PriceFruits>Moneys)
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
        Moneys=coin.InfoToSave.Fruits;
        FruitsLV=coin.InfoToSave.UpdateFruitsLV;
        PriceFruits=coin.InfoToSave.UpdateFruitsPrice;
        HPLV=coin.InfoToSave.UpdateHPLV;
        PriceHP=coin.InfoToSave.UpdateHPPrice;
        Shield=coin.InfoToSave.UpdateShieldsLV;
        PriceShield=coin.InfoToSave.UpdateShieldsPrice;
    }
}

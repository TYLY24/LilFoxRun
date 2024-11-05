using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HPnMETTER : MonoBehaviour
{
    [SerializeField] private Sprite HP,emptyHP,Shield;
    //[SerializeField]private Sprite[] statehealth;
     [SerializeField]public Image[] Heart;
    
    [SerializeField]public int FullHealth = 1,currentHealth;
    [SerializeField]public int shield=0;
    
    [SerializeField] GameObject Shop;
    ShopContents shopContents;
    Player player;
    // Start is called before the first frame update
    
    //Vector2 pos;
    
void OnTriggerEnter2D(Collider2D square)

{
if(square.gameObject.CompareTag("Shield")) 
    {
        Destroy(square.gameObject);
        shield++;      
    }
if(square.gameObject.CompareTag("Heal")) 
    {
        Destroy(square.gameObject);
        if(currentHealth<FullHealth)
        currentHealth++;      
    }
}
    
  void Awake()
  {
    shopContents=Shop.GetComponent<ShopContents>();
    player=GetComponent<Player>();
  }
    void Start()
    {
        //if(nang cap thì full heath =4)
        //FullHealth=FullHealth+shopContents.HPLV-1;
        currentHealth=FullHealth;
        //shield+=shopContents.Shield;
        
        for(int i=0; i<FullHealth+shield;i++)
        {
            if(i<currentHealth)
            Heart[i].sprite=HP;
            else
            Heart[i].sprite=Shield;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        for(int i=0; i<Heart.Length;i++)
        {
            if(i<FullHealth+shield)
            Heart[i].enabled=true;
            else
            Heart[i].enabled=false;
        }
       
        for(int i=0; i<FullHealth+shield;i++)
        {
            if(i<currentHealth)
            {
              
            Heart[i].sprite=HP;
            }
            else if(i<FullHealth)
            {
            
            Heart[i].sprite=emptyHP;
           // Debug.Log("DM MẤT MÁU!");
            }
            else
            {
             Heart[i].sprite=Shield;   
            }
        }


        
        
    }
    public void spawnHPatPos(Vector2 position,Image Heart)
    {
        // Instantiate the image prefab
        Image spawnedImage = Instantiate(Heart, transform);

        // Set the position within the Canvas (RectTransform)
        RectTransform rectTransform = spawnedImage.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
    }
}

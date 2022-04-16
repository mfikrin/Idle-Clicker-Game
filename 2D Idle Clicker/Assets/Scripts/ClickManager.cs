using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClickManager : MonoBehaviour
{
    public List<float> autoClickerLastTime = new List<float>();
    public int autoClickerPrice; // auto clicker
    public int currAutoClickerAmount;
    public float maxAutoClicker;
    
    public TextMeshProUGUI priceAutoClicker;
    public TextMeshProUGUI quantityText;


    // AutoBuy autoClicker
    public int autoBuyClickerPrice; // auto buy clicker auto
    public TextMeshProUGUI priceAutoBuyClicker;
    public TextMeshProUGUI textStateAutoBuyAutoClicker;
    public bool stateAutoBuyAutoClicker;

    void Awake()
    {
        //maxAutoClicker = Mathf.Infinity;
        currAutoClickerAmount = 0;
        //stateAutoBuyAutoClicker = false;
        Debug.Log(stateAutoBuyAutoClicker);
        textStateAutoBuyAutoClicker.text = "Not Activate";
        priceAutoClicker.text = "$" + autoClickerPrice.ToString();
        priceAutoBuyClicker.text = "$" + autoBuyClickerPrice.ToString();
        quantityText.text = "X " + currAutoClickerAmount.ToString() + "/" + maxAutoClicker.ToString();
    }
    void Update()
    {
        if (stateAutoBuyAutoClicker)
        {
            onBuyAutoClicker();
        }

        for (int i = 0; i < autoClickerLastTime.Count; i++)
        {
            if (Time.time - autoClickerLastTime[i] >= 0.5f)
            {
                autoClickerLastTime[i] = Time.time;
                EnemyManager.instance.currEnemy.Damage();
            }
        }    
    }
   
    public void onBuyAutoClicker()
    {
        if (GameManager.instance.gold >= autoClickerPrice && currAutoClickerAmount < maxAutoClicker)
        {
            GameManager.instance.TakeGold(autoClickerPrice);
            autoClickerLastTime.Add(Time.time);
            currAutoClickerAmount = autoClickerLastTime.Count;
            quantityText.text = "X " + currAutoClickerAmount.ToString() + "/" + maxAutoClicker.ToString();
        }
    }

    public void onBuyAutoBuyAutoClicker()
    {
        if (GameManager.instance.gold >= autoBuyClickerPrice && !stateAutoBuyAutoClicker)
        {
            GameManager.instance.TakeGold(autoBuyClickerPrice);
            stateAutoBuyAutoClicker = true;
            textStateAutoBuyAutoClicker.text = "Activate";

        }
    }

}

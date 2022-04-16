using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;

    public Sprite[] backgrounds;
    private int curBackground;
    private int enemiesUntilBackgroundChange;
    public Image backgroundImage;

    public static GameManager instance;

    void Awake()
    {
        gold = 0;
        goldText.text = "Gold: $" + gold.ToString();
        enemiesUntilBackgroundChange = 5;
        instance = this;
    }

    public void AddGold (int amount)
    {
        gold += amount;
        goldText.text = "Gold: $" + gold.ToString();
    }
    public void TakeGold(int amount)
    {
        gold -= amount;
        goldText.text = "Gold: $" + gold.ToString();
    }
    public void buyAutoClicker()
    {

    }

    public void BackgroundCheck()
    {
        enemiesUntilBackgroundChange--;

        if (enemiesUntilBackgroundChange == 0)
        {
            enemiesUntilBackgroundChange = 5;

            curBackground++;
            
            if (curBackground == backgrounds.Length)
            {
                curBackground = 0;
            }

            backgroundImage.sprite = backgrounds[curBackground];
        }
    }
}

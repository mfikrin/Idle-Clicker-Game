using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthBarFill;
    public int currhealth;
    public int maxhealth;
    public int goldToGive;
    public Animation anim;

    public void Damage()
    {
        currhealth--;
        healthBarFill.fillAmount = (float)currhealth / (float)maxhealth;

        anim.Stop();
        anim.Play();

        if (currhealth <= 0)
        {
            Defeated();
        }
    }

    public void Defeated()
    {
        GameManager.instance.AddGold(goldToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);
    }
}

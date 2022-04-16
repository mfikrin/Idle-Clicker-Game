using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Enemy currEnemy;
    public Transform canvas;
    
    public static EnemyManager instance;

    void Awake()
    {
        instance = this;
    }

    public void CreateNewEnemy()
    {
        int idx = Random.Range(0,enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[idx];
        
        GameObject obj = Instantiate(enemyToSpawn, canvas);

        currEnemy = obj.GetComponent<Enemy>();
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);
        CreateNewEnemy();
        GameManager.instance.BackgroundCheck();
    }

}

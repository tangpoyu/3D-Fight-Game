using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField]
    private GameObject enemyPrafab;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrafab,transform.position,Quaternion.identity).name = enemyPrafab.name;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public List<Transform> EnemyGeneratePoint;

    public List<GameObject> EnemyPrefab;

    public List<GameObject> Enemies;
    
    private int DeadCount = 0;
    public void GenerateEnemy()
    {
        int index;
        System.Random random = new System.Random();
        foreach (Transform tf in EnemyGeneratePoint)
        {
            index = random.Next(EnemyPrefab.Count);
            GameObject enemyOBJ = Instantiate(EnemyPrefab[index], tf.position, Quaternion.identity);
            Enemy enemy = enemyOBJ.GetComponent<Enemy>();
            enemy.EnemyDeadCount += Count;
            enemy.TimePass = enemy.ATKRate / (Enemies.Count + 1);
            Enemies.Add(enemyOBJ);
        }
    }

    /// <summary>
    /// À¿Õˆµ–»À ˝¡ø
    /// </summary>
    public void Count()
    {
        DeadCount++;
        if (DeadCount == Enemies.Count)
        {
            GetComponent<Room>().IsPassed = true;
            GetComponent<Room>().SetAllDoor(false);
        }
    }
}

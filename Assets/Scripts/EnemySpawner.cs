using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject errorImage;
    public GameObject enemy;
    public GameObject enemySpawner;
    
    public Vector2[] position;

    public static List<GameObject> enemies = new List<GameObject>();
    //public static GameObject[] enemies;

    static int enemiesCount = 0;
    bool existGO = false; //GO = GameObject.

    int randomPos;

    float nextSpawn = 3f;

    void Start()
    {
        //enemies = new GameObject[17];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawn)
        {
            if (nextSpawn <= 15)
            {
                nextSpawn = Time.timeSinceLevelLoad + Random.Range(2f,3f);
            } else if (nextSpawn > 15 && nextSpawn <= 30)
            {
                nextSpawn = Time.timeSinceLevelLoad + Random.Range(1.3f,2.3f);
            } else if (nextSpawn > 30)
            {
                nextSpawn = Time.timeSinceLevelLoad + Random.Range(0.5f,1.5f);
            }

            randomPos = Random.Range(0,(position.Length - 1));
            SpawnEnemies();  
        }
    }
    
    public void RemoveEnemy(GameObject enemigo)
    {
        for (int i = 0 ; i < enemiesCount && enemies[i] != null ; i++)
        {
            if (enemies[i].gameObject.transform.position == enemigo.transform.position)
            {
                enemiesCount--;
                enemies.RemoveAt(i); 
                Destroy(enemigo);
            }
        }
    }

    void SpawnEnemies()
    {
        if (enemiesCount == 0)
        {
            GameObject myEnemy = Instantiate(enemy);
            myEnemy.transform.SetParent(enemySpawner.transform, false);
            myEnemy.transform.position = new Vector3(position[randomPos].x, position[randomPos].y, 0);

            enemies.Add(myEnemy);
            enemiesCount++;
        }else 
        {
            for (int i = 0 ; i < enemies.Count && enemies[i] != null ; i++)
            {
                if (enemies[i].gameObject.transform.position.x == position[randomPos].x || enemies[i].gameObject.transform.position.y == position[randomPos].y)
                {
                    existGO = true;
                }
            }
            if (!existGO)
            {
                GameObject myEnemy = Instantiate(enemy);
                myEnemy.transform.SetParent(enemySpawner.transform, false);
                myEnemy.transform.position = new Vector3(position[randomPos].x, position[randomPos].y, 0);

                enemies.Add(myEnemy);
                enemiesCount++;
            }else {
                nextSpawn++;
            }
        }
    }


}

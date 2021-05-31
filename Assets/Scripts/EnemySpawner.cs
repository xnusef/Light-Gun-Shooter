using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public Vector2[] position;

    public List<GameObject> enemies = new List<GameObject>();

    static int enemiesCount = 0;
    bool existGO = false; //GO = GameObject.

    int randomPos;

    float nextSpawn = 4f;

    void Start()
    {
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
                nextSpawn = Time.timeSinceLevelLoad + Random.Range(1.5f,2.5f);
            } else
            {
                nextSpawn = Time.timeSinceLevelLoad + Random.Range(0.7f,1.7f);
            }

            randomPos = Random.Range(0,(position.Length - 1));

            for (int i = 0 ; i < enemiesCount ; i++)
            {
                if (enemies[i].transform.position == new Vector3 (position[randomPos].x,position[randomPos].y,0))
                {
                    existGO = true;
                }
            }
            
            if (existGO == false)
            {
                //GameObject myEnemy = GameObject.Instantiate(enemy);
                GameObject myEnemy = Instantiate(enemy);
                myEnemy.transform.SetParent(enemySpawner.transform, false);
                myEnemy.transform.position = new Vector3(position[randomPos].x, position[randomPos].y, 0);

                enemies.Insert(enemiesCount,myEnemy); //Da problemas
                Debug.Log(enemies);

                enemiesCount += 1;
                Debug.Log(enemiesCount);
            } else {existGO = false;}       
        }
    }
    
    public void RemoveEnemy(GameObject enemigo)
    {
        Debug.Log("RemoveEnemy");
        Debug.Log(enemiesCount);
        Debug.Log(enemies[0].transform.position); //da problemas // dice que no existe la posición 0 // es más grande que el tamaño del array
        for (int i = 0 ; i < enemiesCount ; i++)
        {
            Debug.Log("For");
            Debug.Log(i);
            Debug.Log(enemies[i].transform.position); // da problemas
            Debug.Log(enemigo.transform.position);
            
            if (enemies[i].transform.position == enemigo.transform.position) // da problemas
            {
                Debug.Log("If");
                enemiesCount -= 1;
                enemies.RemoveAt(i);
                Destroy(enemigo);
            }
        }
    }
}

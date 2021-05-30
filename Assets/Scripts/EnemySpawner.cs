using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public Vector2[] position;
    public List<GameObject> enemies = new List<GameObject>();
    static int enemiesCount = 0;
    bool existGO = false;

    int randomPos;
    
    Vector3 whereSpawning;

    float nextSpawn = 4f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (nextSpawn <= 15)
            {
                nextSpawn = Time.time + Random.Range(2f,3f);
            } else if (nextSpawn > 15 && nextSpawn <= 30)
            {
                nextSpawn = Time.time + Random.Range(1.5f,2.5f);
            } else
            {
                nextSpawn = Time.time + Random.Range(0.7f,1.7f);
            }

            randomPos = Random.Range(0,(position.Length - 1));

            for (int i = 0 ; i < enemiesCount ; i++)
            {
                if (enemies[i].transform.position.x == position[randomPos].x && enemies[i].transform.position.y == position[randomPos].y)
                {
                    existGO = true;
                }
            }
            
            if (existGO == false)
            {
                GameObject myEnemy = GameObject.Instantiate(enemy);
                myEnemy.transform.SetParent(enemySpawner.transform, false);
                myEnemy.transform.position = new Vector3(position[randomPos].x, position[randomPos].y, 0);
                enemies.Add(myEnemy);
                enemiesCount += 1;
                Debug.Log(enemiesCount);
                existGO = false;
            }            
        }
    }
    
    public void RemoveEnemy(GameObject enemigo)
    {
        Debug.Log("RemoveEnemy");
        Debug.Log(enemiesCount);
        for (int i = 0 ; i < enemiesCount ; i++)
        {
            Debug.Log("For");
            if (enemies[i].transform.position == enemigo.transform.position)
            {
                Debug.Log("If");
                enemiesCount -= 1;
                enemies.RemoveAt(i);
                Destroy(enemigo);
            }
        }



        /*bool found = false;
        int cordsPos = -1;

        float enemigoX = enemigo.transform.position.x;
        float enemigoY = enemigo.transform.position.y;

        Debug.Log(enemigoX);
        Debug.Log(enemigoY);

        for (int i = 0 ; i < 17 ; i++)
        {
            if (enemigoX == xpos[i])
            {
                if (enemigoY == ypos[i])
                {
                    cordsPos = i;
                    found = true;
                }
            }
        }

        if (found == true)
        {
            existingEnemies[cordsPos] = false;
            cordsPos = -1;
            found = false;
        }*/
    }
}

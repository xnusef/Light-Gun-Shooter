using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public Vector2 positionNewObject;
    public List<GameObject> enemies;
    static int enemiesCount = 0;

    float nextSpawn = 4f;


    void Awake()
    {
        enemies = new List<GameObject>();
    }
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

            SpawnearEnemigos();
           /* for (int i = 0 ; i < enemiesCount ; i++)
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
                enemies.Add(myEnemy);
                enemiesCount += 1;
                Debug.Log(enemiesCount);
                existGO = false;
            }   */         
        }
    }
    
    void SpawnearEnemigos()
    {
        int positionCoord = Random.Range(0, 16);
        positionNewObject = new Vector2(positionCoord, positionCoord);
        if (enemiesCount == 0)
        {
            GameObject myEnemy = Instantiate(enemy) as GameObject;
            myEnemy.transform.SetParent(enemySpawner.transform, false); //Es esto necesario?
            Vector3 positionNewObjectZ = new Vector3(positionNewObject.x, positionNewObject.y, 0);
            myEnemy.transform.position = positionNewObjectZ;
            enemies.Add(myEnemy);
            enemiesCount++;
        }
        else
        {
            foreach (GameObject go in enemies){
                if (positionNewObject.x != go.transform.position.x && positionNewObject.y != go.transform.position.y)
                {
                    GameObject myEnemy = Instantiate(enemy) as GameObject;
                    myEnemy.transform.SetParent(enemySpawner.transform, false); //Es esto necesario?
                    Vector3 positionNewObjectZ = new Vector3(positionNewObject.x, positionNewObject.y, 0);
                    myEnemy.transform.position = positionNewObjectZ;
                    enemies.Add(myEnemy);
                    enemiesCount++;
                }
            }
        }
        
    }

    public void RemoveEnemy(GameObject enemigo)
    {
        Debug.Log("RemoveEnemy");
        Debug.Log(enemiesCount);
        Debug.Log(enemies[0].transform.position);
        /*for (int i = 0 ; i < enemies.Lenght; i++)
        {
            Debug.Log("For");
            Debug.Log(i);
            Debug.Log(enemies[i].transform.position);
            Debug.Log(enemigo.transform.position);
            
            if (enemies[i].transform.position == enemigo.transform.position)
            {
                Debug.Log("If");
                enemiesCount -= 1;
                enemies.RemoveAt(i);
                Destroy(enemigo);
            }
        }*/
    }
}

using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public Vector2[] position;

    static List<GameObject> enemies = new List<GameObject>();

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
            //estos if anidados aumentan la velocidad del spawn del juego
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

            randomPos = Random.Range(0,(position.Length - 1));//genera posición aleatoria

            for (int i = 0 ; i < enemiesCount ; i++)
            {
                if (enemies[i].transform.position == new Vector3 (position[randomPos].x,position[randomPos].y,0))
                {
                    existGO = true; //la existencia del objeto fue comprovada
                }
            }
            
            if (existGO == false)
            {
                //GameObject myEnemy = GameObject.Instantiate(enemy);
                GameObject myEnemy = Instantiate(enemy);                                                        //desde acá
                myEnemy.transform.SetParent(enemySpawner.transform, false);                                     //creación de enemigos
                myEnemy.transform.position = new Vector3(position[randomPos].x, position[randomPos].y, 0);      //hasta acá

                enemies.Insert(enemiesCount,myEnemy); //se agrega a la lista
                //Debug.Log(enemies.Count + " CANTIDAD DE ENEMIGOS");

                enemiesCount += 1;
                //Debug.Log(enemiesCount + " CONTADOR DE ENEMIGOS +1");
            } else {existGO = false;}       
        }
    }
    
    public void RemoveEnemy(GameObject enemigo)
    {
        for (int i = 0 ; i < enemies.Count; i++)
        {      
            if (enemies[i].transform.position == enemigo.transform.position)
            {
                enemiesCount -= 1;
                Debug.Log(enemiesCount+"CONTADOR DE ENEMIGOS");
                enemies.RemoveAt(i);
                Debug.Log(i+"INDEX del LIST");
                Destroy(enemigo);
            }
            
        }
    }
}

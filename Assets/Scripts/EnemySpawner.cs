using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public float[] xpos;
    public float[] ypos;
    bool[] existingEnemies;
    int randomPos;
    
    Vector3 whereSpawning;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    float nextSpawn = 4f;


    // Start is called before the first frame update
    void Start()
    {
        existingEnemies = new bool[17];
        for(int i = 0 ; i < 17 ; i++)
        {
            existingEnemies[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            randomPos = Random.Range(0,(xpos.Length - 1));
            if (existingEnemies[randomPos] == false)
            {
                nextSpawn = Time.time + Random.Range(minSpawnRate,maxSpawnRate);
                //whereSpawning = new Vector3(xpos[randomPos], ypos[randomPos], 0);
                var myEnemy = GameObject.Instantiate(enemy);
                myEnemy.transform.SetParent(enemySpawner.transform, false);
                //enemy.transform.position = whereSpawning;
                existingEnemies[randomPos] = true;

            } else {
                nextSpawn = Time.time + 1f;
            }
            
        }
    }
}

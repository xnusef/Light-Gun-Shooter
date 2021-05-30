using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemySpawner;

    public float[] xpos;
    public float[] ypos;
    public bool[] existingEnemies;
    int randomPos;
    
    Vector3 whereSpawning;

    float nextSpawn = 4f;


    // Start is called before the first frame update
    void Start()
    {
        existingEnemies = new bool[17];
        for(int i = 0 ; i < 17 ; i++)
        {
            existingEnemies[i] = false;
        }
        xpos = new float[17];
        xpos[0] = -6.364f;
        xpos[1] = -4.81f;
        xpos[2] = -1.69f;
        xpos[3] = 0.39f;
        xpos[4] = 2.22f;
        xpos[5] = 5.42f;
        xpos[6] = 6.84f;
        xpos[7] = 8.32f;
        xpos[8] = 6.56f;
        xpos[9] = 4.65f;
        xpos[10] = 3.1f;
        xpos[11] = 1.1f;
        xpos[12] = -0.55f;
        xpos[13] = -2.55f;
        xpos[14] = -4.03f;
        xpos[15] = -6.05f;
        xpos[16] = -7.81f;
        ypos = new float[17];
        ypos[0] = 0.198f;
        ypos[1] = 0.76f;
        ypos[2] = 1.06f;
        ypos[3] = 0.67f;
        ypos[4] = 1.01f;
        ypos[5] = 0.82f;
        ypos[6] = 0.13f;
        ypos[7] = 2.28f;
        ypos[8] = 2.47f;
        ypos[9] = 2.53f;
        ypos[10] = 2.68f;
        ypos[11] = 2.68f;
        ypos[12] = 2.68f;
        ypos[13] = 2.68f;
        ypos[14] = 2.59f;
        ypos[15] = 2.46f;
        ypos[16] = 2.29f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (nextSpawn <= 15)
            {
                nextSpawn = Time.time + Random.Range(2f,3f);
                randomPos = Random.Range(0,(xpos.Length - 1));
            } else if (nextSpawn > 15 && nextSpawn <= 30)
            {
                nextSpawn = Time.time + Random.Range(1.5f,2.5f);
                randomPos = Random.Range(0,(xpos.Length - 1));
            } else if (nextSpawn > 30)
            {
                nextSpawn = Time.time + Random.Range(0.7f,1.7f);
                randomPos = Random.Range(0,(xpos.Length - 1));
            }

            if (existingEnemies[randomPos] == false)
            {
                int currentRPos = randomPos;
                GameObject myEnemy = GameObject.Instantiate(enemy);
                myEnemy.transform.SetParent(enemySpawner.transform, false);
                enemy.transform.position = new Vector3(xpos[currentRPos], ypos[currentRPos], 0);
                Debug.Log(randomPos);
                existingEnemies[currentRPos] = true;
                Debug.Log(randomPos);
            } else {
                nextSpawn = Time.time + 1f;
            }
            
        }
    }
    
    public void RemoveEnemy(GameObject enemigo)
    {
        bool found = false;
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
        }
    }
}

using System.Collections;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float timeBDestroying = 3f; //Time Before Destroying // Tiempo antes de ser destruido

    public GameObject timerobject;
    private Timer script;

    public Sprite diedEnemy;

    public GameObject enemySpawner;
    private EnemySpawner enemyscript;

    public GameObject errorFov;

    public float quitTime = 2f;
    public float addTime = 3f;

    void Update()
    {
        if (Time.timeSinceLevelLoad < 15)
        {
            quitTime = 2f;
            addTime = 3f;
        } else if (Time.timeSinceLevelLoad > 15 && Time.timeSinceLevelLoad < 30)
        {
            quitTime = 2f;
            addTime = 2f;
        } else if (Time.timeSinceLevelLoad > 30)
        {
            quitTime = 2f;
            addTime = 1.3f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        script = timerobject.GetComponent<Timer>();
        enemyscript = enemySpawner.GetComponent<EnemySpawner>();
        StartCoroutine(SelfDestruction());
    }

    IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(timeBDestroying);

        if(script == null || enemyscript == null)
        {
            Debug.Log("script es null");
        } else {
            GameObject go = Instantiate(errorFov);
            go.transform.SetParent(GameObject.Find("Canvas").transform, false);
            yield return new WaitForSeconds(0.1f);
            Destroy(go);
            script.QuitTime(quitTime);
            enemyscript.RemoveEnemy(this.gameObject);
        }
    }

    public void Shooted()
    {
        if(script == null)
        {
            Debug.Log("script es null");
        } else {
            StopCoroutine(SelfDestruction());
            StartCoroutine(ShootedEffect());
        }
    }

    IEnumerator ShootedEffect()
    {
        this.GetComponent<SpriteRenderer>().sprite = diedEnemy;

        yield return new WaitForSeconds(0.5f);

        if(script == null)
        {
            Debug.Log("script es null");
        } else {
            script.AddTime(addTime);
            enemyscript.RemoveEnemy(this.gameObject);
        }
    }
}

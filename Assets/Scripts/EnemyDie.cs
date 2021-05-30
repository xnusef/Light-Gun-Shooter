using System.Collections;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float timeBDestroying = 3f;

    public GameObject timerobject;
    private Timer script;

    public Sprite diedEnemy;

    public GameObject enemySpawner;
    private EnemySpawner enemyscript;

    public float quitTime = 2f;
    public float addTime = 3f;


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

        if(script == null)
        {
            Debug.Log("script es null");
        } else {
            script.QuitTime(quitTime);
            enemyscript.RemoveEnemy(this.gameObject);
            //enemyscript.
        }
        Destroy(this.gameObject);
    
    }

    public void Shooted()
    {
        if(script == null)
        {
            Debug.Log("script es null");
        } else {
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
        }
        Destroy(this.gameObject);
    
    }
}

using System.Collections;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float timeBDestroying = 3f;

    public GameObject timerobject;
    private Timer script;

    /*public GameObject enemySpawner;
    private EnemySpawner enemyscript;*/

    public float quitTime = 2f;
    public float addTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        script = timerobject.GetComponent<Timer>();
        //enemyscript = enemySpawner.GetComponent<EnemySpawner>();
        StartCoroutine(SelfDestruction());
    }

    IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(timeBDestroying);

        if(script == null)
        {
            Debug.Log("script no es null");
        } else {
            script.QuitTime(quitTime);
            //enemyscript.
        }
        Destroy(this.gameObject);
    
    }

    public void Shooted()
    {
        
    }
}

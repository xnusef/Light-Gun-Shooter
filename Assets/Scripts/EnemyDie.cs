using System.Collections;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float timeBDestroying = 3f;

    public GameObject timerobject;
    private Timer script;

    public float quitTime = 2f;
    public float addTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(timerobject.transform.name);
        script = timerobject.GetComponent<Timer>();
        Debug.Log(script);
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
        }
        Destroy(this.gameObject);
    
    }

    public void Shooted()
    {
        
    }
}

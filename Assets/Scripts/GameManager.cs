using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject BulletCounter;
    private Bullets bulletScript;
    public GameObject fire;

    private Vector2 clickedPos;

    int bullets = 6;
    bool reloading = false;
    

    // Start is called before the first frame update
    void Start()
    {
        bulletScript = BulletCounter.GetComponent<Bullets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloading == false && bullets > 0)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(FireEffect());
        }
    }

    IEnumerator FireEffect()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fire.SetActive(false);
    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject BulletCounter;
    private Bullets bulletScript;
    public GameObject fire;

    private EnemyDie enemyscript;

    private Vector2 clickedPos;

    int bullets = 6;
    bool reloading = false;
    bool shooting = false;
    

    // Start is called before the first frame update
    void Start()
    {
        bulletScript = BulletCounter.GetComponent<Bullets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r") && reloading == false && bullets < 6)
        {
            reloading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButtonDown(0) && reloading == false && bullets > 0 && shooting == false)
        {
            shooting = true;
            bullets = bullets - 1;
            GetComponent<AudioSource>().Play();
            StartCoroutine(FireEffect());
            bulletScript.ChangeSprite(bullets);

            clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickedPos,clickedPos,0f);

            if (hit == false)
            {
                
            } else if (hit == true)
            {
                if (hit.collider.tag == "Enemy")
                {
                    enemyscript = hit.collider.GetComponent<EnemyDie>();
                    enemyscript.Shooted();
                }
            }
            
        }
    }

    IEnumerator FireEffect()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fire.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        shooting = false;
    }

    IEnumerator Reload()
    {
        while (bullets < 6 && reloading == true)
        {
            yield return new WaitForSeconds(0.2f);
            bullets = bullets + 1;
            bulletScript.ChangeSprite(bullets);
        }
        reloading = false;


    }
}

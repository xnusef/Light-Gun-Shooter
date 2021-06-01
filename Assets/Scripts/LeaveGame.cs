using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LeaveGame : MonoBehaviour
{

    public Animator SceneLoader;
    public Animator Music;

    public GameObject enemySpawner;
    private EnemySpawner enemySpawnerScript;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadPreviousLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadPreviousLevel(int LevelIndex)
    {
        SceneLoader.SetTrigger("Start");
        Music.SetTrigger("Start");
        Cursor.visible = true;
        yield return new WaitForSeconds(0.5f);
        enemySpawnerScript.ClearList();
        SceneManager.LoadScene(LevelIndex);
    }

}

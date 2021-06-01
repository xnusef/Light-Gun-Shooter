using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    public static float timeLeft = 16f; //para que no comience en 14
    
    public Text countdown;
    int actualTime = 16;

    public Text timer;
    int time = 0;

    public GameObject leaveGameGo;
    private LeaveGame gameLost;
    public GameObject loseText;
    bool lose = false;

    void Start()
    {
        gameLost = leaveGameGo.GetComponent<LeaveGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualTime > 0 && lose == false)
        {
            //tiempo restante - tiempo actual  // por cada frame resta el tiempo exacto desde la ejecución
            actualTime = (int) (timeLeft - Time.timeSinceLevelLoad);
            countdown.text = actualTime.ToString();

        } else if (actualTime <= 0 && lose == false)
        {
            lose = true;
            countdown.text = ("0");
            StartCoroutine(Lose());
            //EndGame
        }

        if (time != (int) Time.timeSinceLevelLoad)
        {
            time = (int) Time.timeSinceLevelLoad;
            timer.text = time.ToString();
        }
    }

    public void QuitTime(float time)
    {
        timeLeft -= time;
    }

    public void AddTime(float time)
    {
        timeLeft += time;
    }

    IEnumerator Lose()
    {
        loseText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Cursor.visible = true;
        loseText.SetActive(false);
        lose = false;
        gameLost.BackToMenu();
    }
}
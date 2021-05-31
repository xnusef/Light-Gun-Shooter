using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float timeLeft = 16f;
    
    public Text countdown;

    public Text timer;
    int time = 0;

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.timeSinceLevelLoad;
            countdown.text = ((int) timeLeft).ToString();
        } else if (timeLeft < 0)
        {
            countdown.text = ("0");
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
}
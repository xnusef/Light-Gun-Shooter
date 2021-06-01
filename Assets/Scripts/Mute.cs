using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite muteOff;
    public Sprite muteOn;
    public GameObject buttonMute;
    private bool isMuted;

    void Start()
    {
        isMuted = false;
        AudioListener.pause = isMuted;
        if (AudioListener.pause == true)
        {
            buttonMute.gameObject.GetComponent<Image>().sprite = muteOff;
        } else
        {
            buttonMute.gameObject.GetComponent<Image>().sprite = muteOn;
        }
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        if (AudioListener.pause == false)
        {
            buttonMute.gameObject.GetComponent<Image>().sprite = muteOn;
        } else 
        {
            buttonMute.gameObject.GetComponent<Image>().sprite = muteOff;
        }
    }
}
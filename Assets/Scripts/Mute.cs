using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite muteOff;
    public Sprite muteOn;
    public GameObject buttonMute;
    private bool isMuted;

    public AudioSource fx;
    public AudioClip hoverSound;
    public AudioClip clickSound;

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

    public void Hover()
    {
        fx.PlayOneShot(hoverSound);
    }

    public void MutePressed()
    {
        fx.PlayOneShot(clickSound);
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
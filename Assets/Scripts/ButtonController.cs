using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject button;
    public GameObject hover;
    public Animator music;

    public AudioSource fx;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public GameObject creditsPanel;
    Animator creditsAnimator;

    public Animator SceneLoader;

    public void Hover()
    {
        hover.gameObject.SetActive(true);
        fx.PlayOneShot(hoverSound);
    }
    public void StopHover()
    {
        hover.gameObject.SetActive(false);
    }


    public void Credits()
    {
        fx.PlayOneShot(clickSound);
        StartCoroutine(CreditsAnimations());
    }

    IEnumerator CreditsAnimations()
    {
        if (!creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(true);
            creditsAnimator.SetBool("Show", true);
            yield return new WaitForSeconds(0.5f);
        }else if (creditsPanel.activeSelf)
        {
            creditsAnimator.SetBool("Show", false);
            yield return new WaitForSeconds(0.5f);
            creditsPanel.SetActive(false);
        }
    }

    public void PlayGame()
    {
        fx.PlayOneShot(clickSound);
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadNextLevel(int LevelIndex)
    {
        SceneLoader.SetTrigger("Start");
        music.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(LevelIndex);
    }

    public void QuitGame()
    {
        fx.PlayOneShot(clickSound);
        Application.Quit();
    }

    void Start()
    {
        creditsAnimator = creditsPanel.GetComponent<Animator>();
    }
}

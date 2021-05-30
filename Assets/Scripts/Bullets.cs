using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{

    public GameObject bulletCount;
    public Sprite[] mySprites;


    public void ChangeSprite(int BulletsAmount)
    {
        GetComponent<AudioSource>().Play();
        bulletCount.GetComponent<Image>().sprite = mySprites[BulletsAmount];
    }
}

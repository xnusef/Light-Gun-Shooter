using UnityEngine;

public class Bullets : MonoBehaviour
{

    public SpriteRenderer bulletCount;
    public Sprite[] mySprites;


    public void ChangeSprite(int BulletsAmount)
    {
        GetComponent<AudioSource>().Play();
        bulletCount.sprite = mySprites[BulletsAmount];
    }
}

using UnityEngine;

public class Bullets : MonoBehaviour
{

    public SpriteRenderer bulletCount;
    public Sprite[] mySprites;

    public void ChangeSprite(int BulletsAmount)
    {
        bulletCount.sprite = mySprites[BulletsAmount];
    }
}

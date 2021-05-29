using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject sight;
    public GameObject weapon;
    public GameObject fire;


    Vector3 weaponPos;
    Vector3 firePos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        sight.transform.position = Input.mousePosition;
        weaponPos = Input.mousePosition;
        firePos = Input.mousePosition;
        weaponPos.y = 465;
        firePos.y = 330;

        weapon.transform.position = weaponPos;
        fire.transform.position = firePos;
    }
}


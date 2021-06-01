using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject sight;
    public GameObject weapon;
    public GameObject fire;

    float wy;
    float fy;

    Vector3 weaponPos;
    Vector3 firePos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        wy = weapon.transform.position.y;
        fy = fire.transform.position.y;// - 142;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        wy = weapon.transform.position.y;
        fy = fire.transform.position.y;// - 142;

        sight.transform.position = Input.mousePosition;
        weaponPos = Input.mousePosition;
        firePos = Input.mousePosition;
        weaponPos.y = wy;
        firePos.y = fy;

        weapon.transform.position = weaponPos;
        fire.transform.position = firePos;
    }
}


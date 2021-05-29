using UnityEngine;

public class CameraSizer : MonoBehaviour
{
    void Start()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(1920, 1080, true);
    }
}
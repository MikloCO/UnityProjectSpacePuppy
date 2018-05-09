using UnityEngine;

public class RotatingScript : MonoBehaviour
{

    public Pause pause;
    public float speed = 1f;

    void Update()
    {
        transform.Rotate(0, 0, speed * 0.01f * pause.gameSpeed);
    }
}

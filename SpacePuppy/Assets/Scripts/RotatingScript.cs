using UnityEngine;

public class RotatingScript : MonoBehaviour
{

    private Pause pause;
    public float speed = 1f;

    private void Start () {
        pause = FindObjectOfType<Pause>();
    }

    void Update()
    {
        transform.Rotate(0, 0, speed * 0.01f * pause.gameSpeed);
    }
}

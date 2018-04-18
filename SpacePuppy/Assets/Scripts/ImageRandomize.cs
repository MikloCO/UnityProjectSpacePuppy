using UnityEngine;
using UnityEngine.UI;

public class ImageRandomize : MonoBehaviour {

    public Image randomImage;
    public Sprite Piece1;
    public Sprite piece2;
    public Sprite piece3;
    public Sprite piece4;
    public Sprite[] images;

    private float timer = 0;

    void Start()
    {
        images = new Sprite[4];
        images[0] = Piece1;
        images[1] = piece2;
        images[2] = piece3;
        images[3] = piece4;
    }
    private void Update()
    {

        if (timer > 2)
        {
            timer = 0;
            changeImage();
        }
       timer += Time.deltaTime;

    }
    void changeImage()
    {
        int num = UnityEngine.Random.Range(0, images.Length);
        randomImage.sprite = images[num];
    }
}

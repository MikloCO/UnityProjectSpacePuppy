using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public Movement player;
  //  public GameObject[] heads;
    public GameObject head1, head2, head3;
    
    void Start () {
        head1.gameObject.SetActive(true);
        head2.gameObject.SetActive(true);
        head3.gameObject.SetActive(true);
        //gameOver.gameObject.SetActive(false); // detta ska vara loadscene("DeathScene")
    }
	public void Update()
    {

    }

    public void RemoveHead()
    {
        switch (player.playerHealth)
        {
            case 2:
                head3.gameObject.SetActive(false);
                break;
            case 1:
                head2.gameObject.SetActive(false);
                break;
            case 0:
                head3.gameObject.SetActive(false);
                SceneManager.LoadScene("DeathScene");
                //gameOver.gameObject.SetActive(true);
                //Time.timeScale = 0;
                break;
        }
    }
}

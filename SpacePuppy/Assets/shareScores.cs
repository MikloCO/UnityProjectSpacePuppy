using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shareScores : MonoBehaviour
{
    public static int m_points = 0;
    public Text m_scoreText;

    public void onClickScoreButton()
    {
        m_points++;
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = "Score: " + m_points;
    }
}

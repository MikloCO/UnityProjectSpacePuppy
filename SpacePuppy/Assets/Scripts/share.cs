using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class share : MonoBehaviour {


    string TWITTER_ADRESS = "http://twitter.com/intent/tweet";

    string TWEET_LANGUAGE = "en";

    string textToDisplay = "Hey puppers! Check out my score: ";

    string AppID = "2141145696121635";

    string Link = "https://play.google.com/store/apps/details?id=com.Grupp19.SpacePupper";

    //Nedan måste va minst 200x200px
    string Picture = "https://lh3.googleusercontent.com/ST0idtisfVKWTpDoOCMMSrPumpIT7OBS8ydBJaXjJOTXI4xLCd1EszlaAPeEEJ9VusmC=s180-rw";

    string Caption = "Check out my new Score: ";

    string Description = "Enjoy Fun, free games! Challenge yourself or share your pupper scores with friends!";


    public void shareScoreOnTwitter () {
        Application.OpenURL(TWITTER_ADRESS + "?Text=" + WWW.EscapeURL(textToDisplay) + shareScores.m_points +  WWW.EscapeURL(TWEET_LANGUAGE));
		
	}

    public void shareScoreOnFacebook ()
    {
        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link" + Link + "&picture" + Picture
                            + "&caption=" + Caption + shareScores.m_points + "&description");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

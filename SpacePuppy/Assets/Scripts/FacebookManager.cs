using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;

//fix applink

public class FacebookManager : MonoBehaviour
{

    private static FacebookManager _instance;

    public static FacebookManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject fbm = new GameObject("FBManager");
                fbm.AddComponent<FacebookManager>();
            }
            return _instance;
        }
    }

    public bool IsLoggedIn { get; set; }
    public string ProfileName { get; set; }
    public Sprite ProfilePic { get; set; }
    public string AppLinkUrl { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

        IsLoggedIn = true;

    }

    public void InitFB()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(SetInit, OnHideUnity);
        }
        else
        {
            IsLoggedIn = FB.IsLoggedIn;
        }
    }
    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB is logged in");
            GetProfile();
        }
        else
        {
            Debug.Log("FB not logged in");
        }

        IsLoggedIn = FB.IsLoggedIn;
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void GetProfile()
    {
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
		FB.GetAppLink(DealWithAppLink);/*Type in fb app url and erase method DealWithAppLink if it crashes app*/
    }
    void DisplayUsername(IResult result)
    {

        if (result.Error == null)
        {
            ProfileName = "" + result.ResultDictionary["first_name"];
        }
        else
        {
            Debug.Log(result.Error);
        }
    }
    void DisplayProfilePic(IGraphResult result)
    {

        if (result.Texture != null)
        {
            ProfilePic = Sprite.Create(result.Texture, new Rect(0, 0, 120, 120), new Vector2());
        }
    }
    //35:35 video

    void DealWithAppLink(IAppLinkResult result)
    {
		if (!string.IsNullOrEmpty(result.Url))
        {
			AppLinkUrl = "" + result.Url + "";/*result.Url + ""*/
			Debug.Log("I am an if error of DeadAppLink");
        }
        else
        {
            AppLinkUrl = "http://play.google.com";
			Debug.Log ("I am an else error");
        }
    }
    public void Share()
    {
        FB.FeedShare(
        string.Empty,
			new Uri(AppLinkUrl),/*Replace AppLinkUrl with a string "of the app url"*/
        "Space Pupper",
        "This is the caption",
        "Check out this game!",
			new Uri("https://lh3.googleusercontent.com/ST0idtisfVKWTpDoOCMMSrPumpIT7OBS8ydBJaXjJOTXI4xLCd1EszlaAPeEEJ9VusmC=s180-rw"),/*Either put in an image URL of our app here, OR a screenshoot.*/
        //    string mediaSource = "";,/*You can insert video here!*/
        string.Empty,
        ShareCallBack
    );
    }
    void ShareCallBack(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Share Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on share!");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Sucess on share!");
        }

    }

    public void Invite()
    {
        FB.Mobile.AppInvite(
			new Uri("https://play.google.com/store/apps/details?id=com.Grupp19.SpacePupper"),/*Ändra till appens verkliga URL*/
        new Uri("https://randomImageFromWebsite.jpg"),
            InviteCallback
        );
    }
    void InviteCallback(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Invite Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on invite");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Sucess on Invite");
        }
    }

    public void ShareWithUsers()
    {
        FB.AppRequest(
                "Come and join me, I bet you can't beat my score!",
            null,
            new List<object> { "app_users" },
            null,
            null,
            null,
            null,
            ShareWithUsersCallback
        );
    }

    void ShareWithUsersCallback(IAppRequestResult result)
    {

        if (result.Cancelled)
        {
            Debug.Log("Invite Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on invite");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Sucess on Invite");
        }
    }
}
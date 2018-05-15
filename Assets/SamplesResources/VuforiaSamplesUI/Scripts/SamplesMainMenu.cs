/*===============================================================================
Copyright (c) 2016-2017 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SamplesMainMenu : MonoBehaviour
{

    #region PUBLIC_MEMBERS

    public enum MenuItem
    {
		StartARcamera,
		ReadGuide,
		SaveResult,
		ShareResult,
		Credit,
    }

    public Canvas AboutCanvas;
    public Text AboutTitle;
    public Text AboutDescription;
	public GameObject AboutButton;


    public static bool isAboutScreenVisible;

    // initialize static enum with one of the items
	public static MenuItem menuItem = MenuItem.StartARcamera;

    public const string MenuScene = "1-Menu";
    public const string LoadingScene = "2-Loading";

    

    #endregion // PUBLIC_MEMBERS

    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
        // reset about screen state variable to false when returning from AR scene
        isAboutScreenVisible = false;

    }

    #endregion // MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    public static string GetSceneToLoad()
    {
        // called by SamplesLoadingScreen to load selected AR scene
        return  menuItem.ToString();
    }

    public static void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void BackToMenu()
    {
        // called to return to Menu from About screen
        AboutCanvas.sortingOrder = 0;
        isAboutScreenVisible = false;
    }

    public void LoadAboutScene(string itemSelected)
    {
        
        // This method called from list of Sample App menu buttons
        switch (itemSelected)
        {

		case ("StartARcamera"):
			menuItem = MenuItem.StartARcamera;
			AboutButton.SetActive (true);
                break;
		case ("ReadGuide"):
			menuItem = MenuItem.ReadGuide;
			//hide start button in guide menu
			AboutButton.SetActive (false);
                break;
		case ("SaveResult"):
			menuItem = MenuItem.SaveResult;
			AboutButton.SetActive (false);
                break;
		case ("ShareResult"):
			menuItem = MenuItem.ShareResult;
			AboutButton.SetActive (false);
                break;
		case ("Credit"):
			menuItem = MenuItem.Credit;
			AboutButton.SetActive (false);
                break;
        }

        AboutTitle.text ="test";
        AboutDescription.text ="test";
        AboutCanvas.transform.parent.transform.position = Vector3.zero; // move canvas into position
        AboutCanvas.sortingOrder = 2; // bring canvas in front of main menu
        isAboutScreenVisible = true;

    }

  

    #endregion // PUBLIC_METHODS

}

using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SamplesMainMenu : MonoBehaviour
{


	//list of option in menu 
	public enum MenuItem
	{
		StartARcamera,
		ReadGuide,
		SaveResult,
		ShareResult,
		Credit,
	}
	//about panel element to modifie for each item list clicked
	public Canvas AboutCanvas;
	public Text AboutTitle;
	public Text AboutDescription;
	public GameObject AboutButton;


	public bool isAboutScreenVisible;

	// initialize static enum with one of the items
	public MenuItem menuItem = MenuItem.StartARcamera;

	public const string MenuScene = "1-Menu";
	public const string LoadingScene = "2-Loading";




	void Start()
	{
		// reset about screen state variable to false when returning from AR scene
		isAboutScreenVisible = false;

	}
	public void BackToMenu()
	{
		// called to return to Menu from About screen
		AboutCanvas.sortingOrder = 0;
		isAboutScreenVisible = false;
	}
	void Update()
	{
		//Escape button pressed handle
		#if (UNITY_EDITOR || UNITY_ANDROID)

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (isAboutScreenVisible)
			{
				// called to return to Menu when about screen is active
				BackToMenu();
			}
			else
			{
		#if UNITY_EDITOR
				// if about screen not active and Escape button pressed quit app
				UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_ANDROID
		// On Android, the Back button is mapped to the Esc key
		Application.Quit();
		#endif
			}
		}
	}
		
		#endif // UNITY_EDITOR || UNITY_ANDROID

	

public void OnStartAR()
{
	// called by OK button on About screen to load loding screen
		UnityEngine.SceneManagement.SceneManager.LoadScene(SamplesMainMenu.LoadingScene);
}
		

public void LoadAboutScene(string itemSelected)
{

		// This method called from list of Sample App menu buttons with itemSelected as input
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
		//activate about panel
	isAboutScreenVisible = true;
		//specifie content based on the list item selected
	AboutTitle.text ="test";
	AboutDescription.text ="test";
	AboutCanvas.transform.parent.transform.position = Vector3.zero; // move canvas into position
	AboutCanvas.sortingOrder = 2; // bring canvas in front of main menu
	

}




}

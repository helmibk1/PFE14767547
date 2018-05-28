using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Menu : MonoBehaviour
{

	public bool isAboutScreenVisible;

	//about panel element to modifie for each item list clicked
	public Canvas AboutCanvas;
	public Text AboutTitle;
	public Text AboutDescription;
	public GameObject AboutButton;



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

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (isAboutScreenVisible)
			{
				// called to return to Menu when about screen is active
				BackToMenu();
			}
			else
			{
				//close application
				  Application.Quit();
			}
		}
	}
		

	public void OnStartAR()
	{
		// called by OK button on About screen to load loding screen
		UnityEngine.SceneManagement.SceneManager.LoadScene("2-Loading");
	}
		

	public void LoadAboutScene(string itemSelected)
	{
			// This method called from list of Sample App menu buttons with itemSelected as input
		switch (itemSelected)
		{

		case ("StartARcamera"):
			AboutButton.SetActive (true);
			AboutTitle.text ="Start ARcamera";
			AboutDescription.text ="test";
			break;
		case ("ReadGuide"):
			//hide start button in guide menu
			AboutButton.SetActive (false);
			AboutTitle.text ="Guide";
			AboutDescription.text ="test";
			break;

		case ("Credit"):
			AboutButton.SetActive (false);
			AboutTitle.text ="Credit";
			AboutDescription.text ="test";
			break;
		}
			//activate about panel
		isAboutScreenVisible = true;
			//specifie content based on the list item selected

		AboutCanvas.transform.parent.transform.position = Vector3.zero; // move canvas into position
		AboutCanvas.sortingOrder = 2; // bring canvas in front of main menu
	}

}

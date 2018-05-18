using UnityEngine;

public class EscapeButton : MonoBehaviour
{


    public void LoadMenuScene()
    {
        // called by "Vuforia Samples" button in AR scene UI menu
        // also called below in Update() if Android Back button pressed
		UnityEngine.SceneManagement.SceneManager.LoadScene("1-Menu");
    }
		

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
			LoadMenuScene ();
        }
    }


}
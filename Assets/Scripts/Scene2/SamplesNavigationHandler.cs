using UnityEngine;

public class SamplesNavigationHandler : MonoBehaviour
{

    /*string currentSceneName;



    public void OnStartAR()
    {
        // called by OK button on About screen
        SamplesMainMenu.LoadScene(SamplesMainMenu.LoadingScene);
    }

    public void LoadMenuScene()
    {
        // called by "Vuforia Samples" button in AR scene UI menu
        // also called below in Update() if Android Back button pressed
		UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    #endregion // PUBLIC_METHODS

    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    void Update()
    {
#if (UNITY_EDITOR || UNITY_ANDROID)

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            Debug.Log("Esc/Back button pressed from " + currentSceneName);

            if (currentSceneName == SamplesMainMenu.MenuScene)
            {
                if (SamplesMainMenu.isAboutScreenVisible)
                {
                    gameObject.GetComponent<SamplesMainMenu>().BackToMenu();
                }
                else
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
                    // On Android, the Back button is mapped to the Esc key
                    Application.Quit();
#endif
                }
            }
            else
            {
                LoadMenuScene();
            }
        }

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.JoystickButton0))
        {

            if (currentSceneName == SamplesMainMenu.MenuScene && SamplesMainMenu.isAboutScreenVisible)
            {
                // In Unity 'Return' key same as clicking OK button on About Screen
                // On ODG R7, JoystickButton0 is the Trackpad select button
                OnStartAR();
            }
        }

#endif // UNITY_EDITOR || UNITY_ANDROID
    }

    #endregion // MONOBEHAVIOUR_METHODS
*/
}
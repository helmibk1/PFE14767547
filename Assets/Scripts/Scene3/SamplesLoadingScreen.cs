using UnityEngine;
using UnityEngine.UI;

public class SamplesLoadingScreen : MonoBehaviour
{

   

    bool mChangeLevel = true;
    RawImage mUISpinner;



    void Start()
    {
        mUISpinner = GetComponentInChildren<RawImage>();
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        mChangeLevel = true;
    }

    void Update()
    {
        if (mUISpinner)
            mUISpinner.rectTransform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);

        if (mChangeLevel)
        {
            LoadNextSceneAsync();
            mChangeLevel = false;
        }
    }
		


    void LoadNextSceneAsync()
    {
		string sceneName = "StartARcamera";

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
    }
		

}

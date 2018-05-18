using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

 
    bool mChangeLevel = true;
    RawImage mUISpinner;


    void Start()
    {
        mUISpinner = GetComponentInChildren<RawImage>();
		//control how long it takes to load data (ThreadPriority.Low = 2 ms)
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        mChangeLevel = true;
    }

    void Update()
    {
        if (mUISpinner)
			//rotate LodingImage 
            mUISpinner.rectTransform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);

        if (mChangeLevel)
        {
            LoadNextSceneAsync();
            mChangeLevel = false;
        }
    }
		

	//load next scene
    void LoadNextSceneAsync()
    {
		string sceneName = "3-ARcamera";
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
    }
		

}

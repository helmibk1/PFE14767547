using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
	//time until showing next scene
    public float loadingDelay = 5.0F;

    void Start()
    {
        StartCoroutine(LoadNextSceneAfter(loadingDelay));
    }
		
	//private IEnumerator to load a scene after a delay passed as input
    private IEnumerator LoadNextSceneAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

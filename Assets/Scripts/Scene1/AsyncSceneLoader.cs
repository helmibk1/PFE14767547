using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    public float loadingDelay = 5.0F;

    void Start()
    {
        StartCoroutine(LoadNextSceneAfter(loadingDelay));
    }
		
    private IEnumerator LoadNextSceneAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

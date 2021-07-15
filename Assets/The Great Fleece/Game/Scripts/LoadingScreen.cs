using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image loadingBar; 
    private AsyncOperation loadingSceneOperation;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel());

    }

    private IEnumerator LoadLevel()
    {
        loadingSceneOperation = SceneManager.LoadSceneAsync("Main");
        loadingSceneOperation.allowSceneActivation = false;

        while (loadingSceneOperation.progress < 0.9f)
        {
            loadingBar.fillAmount = loadingSceneOperation.progress;
            yield return null;
        }

        loadingBar.fillAmount = 1f;

        yield return new WaitForSeconds(2f);

        loadingSceneOperation.allowSceneActivation = true;
    }
}
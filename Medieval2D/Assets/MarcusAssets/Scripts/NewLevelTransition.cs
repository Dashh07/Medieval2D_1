using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelTransition : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeTime = 2.0f;
    public void TransitionToScene(string newSceneName)
    {
        StartCoroutine(SceneFade(newSceneName));
    }

    IEnumerator SceneFade(string newSceneName)
    {
        float timer = 0f;
        while(timer < fadeTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = timer / fadeTime;
            yield return null;
        }
        SceneManager.LoadScene(newSceneName);
        while (timer > 0f)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = timer / fadeTime;
            yield return null;
        }
    }
}

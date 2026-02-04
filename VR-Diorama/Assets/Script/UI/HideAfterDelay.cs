using UnityEngine;
using System.Collections;

public class HideAfterDelay : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 5f;
    [SerializeField] float fadeRate = 0.25f;


    private CanvasGroup canvasGroup;
    private float startTimer;
    private float fadeoutTimer;

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;

        startTimer = Time.time + delayInSeconds;
        fadeoutTimer = fadeRate;

        StartCoroutine(fadeRoutine());
    }

    private IEnumerator fadeRoutine()
    {
        yield return new WaitForSeconds(delayInSeconds);

        while(fadeoutTimer < 0)
        {
            fadeoutTimer -= Time.deltaTime;
            canvasGroup.alpha = fadeoutTimer / fadeRate;
        }

        gameObject.SetActive(false);
    }
}

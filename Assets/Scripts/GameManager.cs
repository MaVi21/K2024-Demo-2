using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of fade-in and fade-out effects
    public GameObject[] objectsToDeactivate; // Array of GameObjects to deactivate during fade
    public MonoBehaviour[] scriptsToDisable; // Array of scripts to disable during fade
    public Image fadeOverlay; // Reference to the GameObject with the fade overlay (e.g., an Image with a transparent texture)

    private bool isFading = false;

    private void Start()
    {
        SetObjectsActivity(false);
        SetScriptsEnable(false);
        StartFadeIn();
    }

    // Example method to handle game over message
    public void GameOver()
    {
        SetObjectsActivity(false);
        SetScriptsEnable(false);
        StartFadeOut();
    }

    public void SetGamePause(bool p)
    {
        SetObjectsActivity(!p);
        SetScriptsEnable(!p);
    }

    private void SetObjectsActivity(bool b)
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(b);
        }
    }

    private void SetScriptsEnable(bool b)
    {
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.StopAllCoroutines();
            script.enabled = b;
        }
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        fadeOverlay.gameObject.SetActive(true);
        float elapsedTime = 0f;
        Color currentColor = fadeOverlay.color;
        Color targetColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0f); // Target color is fully transparent

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeOverlay.color = Color.Lerp(currentColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }

        // Ensure the fade overlay is completely transparent
        fadeOverlay.color = targetColor;
        fadeOverlay.gameObject.SetActive(false);
        SetObjectsActivity(true);
        SetScriptsEnable(true);
    }

    private IEnumerator FadeOut()
    {
        fadeOverlay.gameObject.SetActive(true);
        isFading = true;
        float elapsedTime = 0f;
        Color currentColor = fadeOverlay.color;
        Color targetColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1f); // Target color is fully opaque

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeOverlay.color = Color.Lerp(currentColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }

        // Ensure the fade overlay is completely opaque
        fadeOverlay.color = targetColor;
        isFading = false;
    }

    public bool IsFading()
    {
        return isFading;
    }    

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of the fade-in effect in seconds
    public Image fadeOverlay; // Reference to the Image component representing the fade overlay

    private void Start()
    {
        fadeOverlay.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
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
    }
}

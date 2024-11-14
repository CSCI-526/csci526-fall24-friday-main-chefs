using System.Collections;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color originalColor;
    private bool isFading = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = _spriteRenderer.color; // Store the original color
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        isFading = true;
        Color startColor = _spriteRenderer.color;
        float elapsedFlashTime = 0;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            elapsedFlashTime = 0;
            while (elapsedFlashTime < flashDuration)
            {
                elapsedFlashTime += Time.deltaTime;
                float pingPong = Mathf.PingPong(elapsedFlashTime / flashDuration * 2, 1);
                _spriteRenderer.color = Color.Lerp(startColor, flashColor, pingPong);
                yield return null;
            }
        }
        
        isFading = false;
        _spriteRenderer.color = originalColor; // Reset to original color after fading
    }

    public void StartFading(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        if (!isFading)
        {
            StartCoroutine(FlashCoroutine(flashDuration, flashColor, numberOfFlashes));
        }
    }

    public void ResetColor()
    {
        StopAllCoroutines();
        _spriteRenderer.color = originalColor; // Reset to original color
        isFading = false;
    }
}

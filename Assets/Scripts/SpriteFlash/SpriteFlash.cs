using System.Collections;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        Color startColor = _spriteRenderer.color;
        float elapsedFlashTime = 0;
        float elapsedFlashPercentage = 0;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            elapsedFlashTime = 0;
            while (elapsedFlashTime < flashDuration)
            {
                elapsedFlashTime += Time.deltaTime;
                elapsedFlashPercentage = elapsedFlashTime / flashDuration;
                float alpha = Mathf.Lerp(startColor.a, flashColor.a, Mathf.PingPong(elapsedFlashPercentage * 2, 1));
                _spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }
        }

        // Reset color to the original state after flashing
        _spriteRenderer.color = startColor;
    }
}

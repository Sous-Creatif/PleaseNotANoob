using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopLogic : MonoBehaviour
{
    public float riseSpeed = 1f; 
    public float fadeDuration = 2f; 

    private SpriteRenderer spriteRenderer; 
    private float startTime;

    public void Anim()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time; 
        StartCoroutine(RiseAndFade());
    }

    IEnumerator RiseAndFade()
    {
        float elapsed = 0;

        while (elapsed < fadeDuration)
        {
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);

            elapsed = Time.time - startTime;
            float ratio = elapsed / fadeDuration;

            Color color = spriteRenderer.color;
            color.a = 1 - ratio; 
            spriteRenderer.color = color;

            yield return null;
        }

        Destroy(gameObject); 
    }
}

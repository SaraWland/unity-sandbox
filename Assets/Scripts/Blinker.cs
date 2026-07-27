using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = Color.purple;
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = Color.white;
        }
    }
}
using UnityEngine;
using System.Collections;

public class CountdownAnimation : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SetAnimationFrame(0));
    }

    private IEnumerator SetAnimationFrame(int index)
    {
        spriteRenderer.sprite = sprites[index];
        yield return new WaitForSeconds(1f);
        if (index + 1 >= sprites.Length)
        {
            spriteRenderer.enabled = false;
            gameplayManager.EnableAll();
            yield break;
        }

        StartCoroutine(SetAnimationFrame(index + 1));
    }
}
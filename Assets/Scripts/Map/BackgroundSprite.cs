using UnityEngine;

public class BackgroundSprite : MonoBehaviour
{
    [SerializeField] Sprite[] backgroundSprites;
    Renderer[] spriteRenderers;
    
    void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        
        int backsNum = Random.Range(0,backgroundSprites.Length);
        
        foreach (SpriteRenderer rederer in spriteRenderers)
        {
            rederer.sprite = backgroundSprites[backsNum];
        }
    }

}

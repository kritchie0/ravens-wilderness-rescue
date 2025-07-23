using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] spriteSheetSprites;
    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteSheetSprites = Resources.LoadAll<Sprite>("SDV_Dog");
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = spriteSheetSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

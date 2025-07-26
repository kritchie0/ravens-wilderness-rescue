using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* --- Public Variables --- */
    public Rigidbody2D rigidBody;
    public Animator animator;
    
    public SpriteRenderer spriteRenderer;
    public float velocity = 2.0f;
    
    /* --- Private Variables --- */
    private int[] _indexWalkingDown = new[] { 0, 1, 2, 3 };
    private int[] _indexWalkingRight = new[] { 4, 5, 6, 7 };
    private int[] _indexWalkingUp = new[] { 8, 9, 10, 11 };
    private int[] _indexWalkingLeft = new[] { 12, 13, 14, 15 };

    private Vector2 _direction;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        Debug.Log(_direction.x);
        _direction.y = Input.GetAxisRaw("Vertical");
        Debug.Log(_direction.y);
    }
    
    void UpdateSprite()
    {
        int framesPerSecond = 20;
        int n_frame = (int)(Time.time * framesPerSecond);
        if (Input.GetKey("w"))
        {
            spriteRenderer.GetComponent<SpriteRenderer>().sprite = spriteSheetSprites[0];
        }
    }
    
    void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", _direction.x);
        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }
    
}

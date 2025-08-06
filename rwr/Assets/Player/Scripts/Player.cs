using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* --- Public Variables --- */
    public Rigidbody2D rigidBody;
    public Animator animator;
    public float velocity = 2.0f;

    /* --- Private Variables --- */
    private bool _isColliding = false;
    private bool _isMovingFlag = false;
    private Vector2 _direction;
    private Vector2 _previousPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + _direction * (velocity * Time.deltaTime));
    }
    
    private void UpdateDirection()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", _direction.x);
        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }
}

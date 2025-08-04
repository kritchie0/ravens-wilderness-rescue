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
        if (_isMovingFlag)
        {
            if (_isColliding)
            {
                rigidBody.MovePosition(_previousPosition + _direction * (velocity * Time.deltaTime));
            }
            
            else
            {
                rigidBody.MovePosition(rigidBody.position + _direction * (velocity * Time.deltaTime));
                _previousPosition = rigidBody.position;                
            }
        }
        if (_isColliding)
        {
            _isColliding = true;
        }
        else
        {
            rigidBody.MovePosition(rigidBody.position + _direction * (velocity * Time.deltaTime));
            _previousPosition = rigidBody.position;
            _isColliding = false;
        }
        
    }
    
    private void UpdateDirection()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        if (_direction is { x: 0, y: 0 })
        {
            _isMovingFlag = false;
        }
        else
        {
            _isMovingFlag = true;
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", _direction.x);
        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _isColliding = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _isColliding = false;
    }
}

using System;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movment Stuff")]
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Animator _animator;

    private void Awake()
    {
        Debug.Log("Player initialized");
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        const string HORIZONTAL = "Horizontal";
        const string VERTICAL = "Vertical";
        const string SPEED = "Speed";
        
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _rb.MovePosition(_rb.position + _moveInput * (moveSpeed * Time.deltaTime));
        
        _animator.SetFloat(HORIZONTAL, _moveInput.x);
        _animator.SetFloat(VERTICAL, _moveInput.y);
        _animator.SetFloat(SPEED, _moveInput.sqrMagnitude);
   }
}

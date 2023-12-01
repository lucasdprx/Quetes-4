using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveplayer : MonoBehaviour
{
    private Vector2 _direction;
    private Vector2 _moveVector;
    [SerializeField] private float _speed;
    [SerializeField] private float _deceleration;
    [SerializeField] public float jumpForce;
    
    public bool isGrounded;
    public bool isJumping = false;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (ShootPlayer.isShootPlayer == false && ShootPlayer.turnPlayer)
        {
            isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            {
                isJumping = true;
            }

            if (isJumping == true)
            {
                _rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (ShootPlayer.turnPlayer)
        {
            if (ShootPlayer.isShootPlayer == false && ShootPlayer.turnPlayer)
            {
                if (_moveVector != Vector2.zero)
                {
                    _direction += _moveVector;
                }


                _direction *= _deceleration;
                _rb.velocity += new Vector2(_direction.x * _speed * Time.deltaTime - _rb.velocity.x, 0);
            }
        }
    }
    public void move(InputAction.CallbackContext ctx)
    {
       //print(ctx.ReadValue<Vector2>());
        _moveVector = ctx.ReadValue<Vector2>();
    }
}

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jumpHeight;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody2D.velocity = new Vector2(speed, 0);
            _animator.SetBool("Walking", true);
            _spriteRenderer.flipX = false;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody2D.velocity = new Vector2(-speed, 0);
            _animator.SetBool("Walking", true);
            _spriteRenderer.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _rigidbody2D.velocity = new Vector2(0, 0);
            _animator.SetBool("Walking", false);
        }

        _animator.SetFloat("X", _rigidbody2D.velocity.x);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            _rigidbody2D.velocity = new Vector2(0, jumpHeight);
        }

    }
}

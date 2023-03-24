using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float climbSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask collisionLayer;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private CapsuleCollider2D playerCollider;

    private bool isJumping;
    private bool isGrounded;
    private bool isClimbing;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool IsClimbing { get => isClimbing; set => isClimbing = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public CapsuleCollider2D PlayerCollider { get => playerCollider; set => playerCollider = value; }

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de PlayerMovement");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        isJumping = false;
        isGrounded = false;
        IsClimbing = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }

    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {

        if (!IsClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            // Déplacement vertical
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

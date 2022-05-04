
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;
    public Animator animator;

    private bool isJumping = false;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);


        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump")  && isGrounded  )
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);

    }

    void MovePlayer(float _horisontalMovement){
        Vector3 targetVelocity = new Vector2(_horisontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping= false;
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float horizontalInput = 0.0f;

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 2.0f;
    private bool isGrounded = false;
    private Transform myTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Script: Player\t Rigidbody 2D is NULL");
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Script: Player\t Animator is NULL");
        }

        myTransform = GetComponent<Transform>();
        if (myTransform == null)
        {
            Debug.LogError("Script: Player\t Transform is NULL");
        }
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            myTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            myTransform.eulerAngles = new Vector3(0, 180, 0);
        }

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Destroy(other.gameObject);
        }
    }
}

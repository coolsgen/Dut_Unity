using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour
{
    
    public float maxSpeed = 10f;
    
    private bool isFacingRight = true;
    
    private Animator anim;
    private bool isGrounded = false;
  
    public Transform groundCheck;
    
    private float groundRadius = 0.2f;
    
    public LayerMask whatIsGround;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

  
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        anim.SetBool("Ground", isGrounded);
       
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        
        if (!isGrounded)
            return;

        float move = Input.GetAxis("Horizontal");

      
        anim.SetFloat("Speed", Mathf.Abs(move));

       
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

       
        if (move > 0 && !isFacingRight)
        
            Flip();
    
        else if (move < 0 && isFacingRight)
            Flip();
    }
    private void Update()
    {
      
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
           
            anim.SetBool("Ground", false);
           
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
        }
    }

    private void Flip()
    {
     
        isFacingRight = !isFacingRight;
    
        Vector3 theScale = transform.localScale;
      
        theScale.x *= -1;
      
        transform.localScale = theScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //movement
    public float maxSpeed;

    //jump
    bool grounded = false;
    
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight = 1250;

    Rigidbody2D rigidbody;
    Animator animation;
    bool facingRight;

    public float life = 3;
    public float coins = 0;
    public Text textLife;
    public Text textCoins;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    
        facingRight = true;
    }

    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            animation.SetBool("isGrounded", grounded);
            rigidbody.AddForce(new Vector2(0, jumpHeight));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animation.SetBool("isGrounded", grounded);

        animation.SetFloat("verticalSpeed", rigidbody.velocity.y);

        float move = Input.GetAxis("Horizontal");
        animation.SetFloat("speed", Mathf.Abs(move));
        rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Duri"))
        {
            SoundEffectManager.instance.PlayHitClip();
            life -= 1;
            textLife.text = "Life : " + life;
            if (life <= 0)
                Destroy(gameObject);
        }
        if (other.gameObject.name.Contains("coinGold"))
        {
            SoundEffectManager.instance.PlayCoinClip();
            coins += 1;
            textCoins.text = "Coins : " + coins;
            Destroy(other.gameObject);
        }
    }
}

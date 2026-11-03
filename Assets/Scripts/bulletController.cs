using UnityEngine;

public class bulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float initialvelocity;
    public bool lookingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (lookingRight)
        {
            rb.linearVelocity = Vector2.right * initialvelocity;
        }
        else
        {
            rb.linearVelocity = Vector2.left * initialvelocity;
        }
    }
   
}

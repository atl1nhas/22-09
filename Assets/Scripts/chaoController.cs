using UnityEngine;

public class chaoController : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public float velocity = 2f;
    public float minimumDistance = 0.1f;

    private bool seguindoPos1 = true;
    private Rigidbody2D rb;
    private float targetX;

    private Vector2 movimentoPlataforma;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // A plataforma não será empurrada pelo personagem
        rb.bodyType = RigidbodyType2D.Kinematic;

        targetX = position1.position.x;
    }

    void FixedUpdate()
    {
        float chaoX = transform.position.x;
        float distance = Mathf.Abs(chaoX - targetX);

        if (distance < minimumDistance)
        {
            if (seguindoPos1)
            {
                targetX = position2.position.x;
            }
            else
            {
                targetX = position1.position.x;
            }

            seguindoPos1 = !seguindoPos1;
        }

        float direcao = Mathf.Sign(targetX - chaoX);

        movimentoPlataforma = new Vector2(
            direcao * velocity,
            0
        );

        rb.linearVelocity = movimentoPlataforma;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "personagem")
        {
            Rigidbody2D personagemRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (personagemRb != null)
            {
                // Faz o personagem acompanhar o movimento da plataforma
                personagemRb.position += movimentoPlataforma * Time.fixedDeltaTime;
            }
        }
    }
}
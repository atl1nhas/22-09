using UnityEngine;

public class spike : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.SendMessage("Die");
      
    }
   }
}

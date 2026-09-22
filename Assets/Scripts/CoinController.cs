using UnityEngine;

public class coincontroller : MonoBehaviour
{
    private bool coletada = false;

   private void OnTriggerEnter2D(Collider2D other)
   {
    if (coletada) return;

    if (other.CompareTag("Player"))
    {
        coletada = true;
        other.gameObject.SendMessage("ChangeTextCoin");
        Destroy(gameObject);
    }
   }
}

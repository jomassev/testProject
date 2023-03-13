using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    Inventory.instance.AddCoins(1);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}

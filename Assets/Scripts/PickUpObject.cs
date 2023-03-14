using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private int healPower;

    public void Awake()
    {
        if(gameObject.tag == "Apple")
        {
            healPower = 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    Inventory.instance.AddCoins(1);
                    break;
                case "Apple":
                    Debug.Log("collision avec Apple");
                    playerHealth = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
                    playerHealth.GainHealth(healPower);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}

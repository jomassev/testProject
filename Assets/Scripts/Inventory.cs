using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int coinsCount;

    [SerializeField]
    private Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Inventory dans la scène");
            return;
        };

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount = coinsCount + count;
        coinsCountText.text = coinsCount.ToString();
    }
}

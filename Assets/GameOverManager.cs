using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    [SerializeField]
    private GameObject GameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de GameOverManager");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        GameOverUI.SetActive(true);
    }
}

using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    [SerializeField]
    private GameObject[] objects;

    void Awake()
    {
        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }

}

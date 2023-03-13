using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    [SerializeField]
    private IEnumerator loadNextScene()
    {
        Debug.Log("start coroutine");
        Debug.Log("start FadeIn");
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded) {

        fadeSystem.SetTrigger("FadeOut");
        }
    }
}

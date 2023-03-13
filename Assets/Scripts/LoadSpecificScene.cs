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
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
        Camera camera;

        switch (sceneName)
        {
            case "Level01":
                break;
            case "Level02":
                camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = new Color(0.333f, 0.786f, 0.980f);
                break;
            default: break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded) {

        fadeSystem.SetTrigger("FadeOut");
        }
    }
}

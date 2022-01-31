using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadDelayTime = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelayTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersistScript>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            StartCoroutine(LoadNextLevel());
        }        
    }
}

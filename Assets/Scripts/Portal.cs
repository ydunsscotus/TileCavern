using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f; 
   
    private void OnTriggerEnter2D(Collider2D other)
     {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
         
   }

   IEnumerator LoadNextLevel()
   {
    yield return new WaitForSecondsRealtime(LevelLoadDelay);
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
        nextSceneIndex = 0;
    }
    SceneManager.LoadScene(currentSceneIndex);
    }
}

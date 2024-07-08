using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public float delay = 2.0f; // Delay dalam detik

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("scene to" + sceneBuildIndex);
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}

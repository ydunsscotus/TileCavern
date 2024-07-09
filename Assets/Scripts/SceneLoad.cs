using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Memuat scene berdasarkan nama
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Keluar dari aplikasi
    public void ExitApplication()
    {
        Application.Quit();
        

    }
}

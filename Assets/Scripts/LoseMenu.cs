using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Close()
    {
        Application.Quit();
    }

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
    }
}

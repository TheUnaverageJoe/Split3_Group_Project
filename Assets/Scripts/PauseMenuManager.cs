using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        paused = PauseMenu.active;
        Time.timeScale = paused ? 0f : 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void togglePause()
    {
        PauseMenu.SetActive(!PauseMenu.active);
        paused = !paused;
        Time.timeScale =  paused ? 0f : 1f;
    }
}

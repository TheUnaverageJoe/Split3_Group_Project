using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Player;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        paused = PauseMenu.activeSelf;
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
        Player.GetComponent<Teleport>().paused = !Player.GetComponent<Teleport>().paused;
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        paused = !paused;
        Time.timeScale =  paused ? 0f : 1f;
    }

    public void hideCursor()
    {
        Cursor.visible = false;
    }
}

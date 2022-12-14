using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGEIM()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void ExitGeim()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene("GameScene");
    }
}

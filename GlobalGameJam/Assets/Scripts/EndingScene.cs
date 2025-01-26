using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public GameObject goodEndingScreen;
    public GameObject badEndingScreen;
    public GameObject player;

    public GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endEventGood()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerMovement>().enabled = false;
        goodEndingScreen.SetActive(true);
        blackout.SetActive(true);
    }

    public void endEventBad()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerMovement>().enabled = false;
        badEndingScreen.SetActive(true);
        blackout.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Title_Screen");
    }

    public void stargame(){
        SceneManager.LoadScene("MainScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIContrLvl2 : MonoBehaviour
{
   

    public PlayerStats pDath;
    public GameObject gameOver2;
    public GameObject pauseMenu2;
    public Text inLvl2;

    void Start()
    {
        
        pDath = FindObjectOfType<PlayerStats>();
        gameOver2.SetActive(false);
        pauseMenu2.SetActive(false);

        StartCoroutine(Timer());

    }

    // Update is called once per frame
    void Update()
    {
        if (pDath.pHealth <= 0)
        {
            StartCoroutine(TimerDeathMenu());
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu2.SetActive(true);


        }
    }
   
    public void ContinueButtonScene2()
    {

        SceneManager.LoadScene("Level2");

    }
    public void MainMenuButton()
    {

        SceneManager.LoadScene("MainMenu");
        

    }
    public void ResumeButton()
    {
        pauseMenu2.SetActive(false);
        Time.timeScale = 1;

    }

    IEnumerator TimerDeathMenu()
    {

        yield return new WaitForSeconds(4);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOver2.SetActive(true);

    }
    IEnumerator Timer()
    {
        inLvl2.enabled = true;
        yield return new WaitForSeconds(4);
        inLvl2.enabled = false;

    }
    public void ExitGame() 
    {

        Application.Quit();
    }
}

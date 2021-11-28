using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public PlayerStats pDath;
    public GameObject gameOver;
    public GameObject pauseMenu;

    public Text inilvl1;
    public Text indicat;

   


    void Start()
    {

       
        indicat.enabled = false;
        pDath = FindObjectOfType<PlayerStats>();
        gameOver.SetActive(false);
        pauseMenu.SetActive(false);

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
            pauseMenu.SetActive(true);

          
        }
        if (Input.GetButton("Fire1"))
        {

            indicat.enabled = false;
            



        }
    }
    public void ContinueButtonScene1 ()
    {

        SceneManager.LoadScene("Level1");
    
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
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

    IEnumerator TimerDeathMenu()
    {
       
        yield return new WaitForSeconds(4);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOver.SetActive(true);

    }
    IEnumerator Timer()
    {
        inilvl1.enabled = true;
        yield return new WaitForSeconds(4);
        inilvl1.enabled = false;
        indicat.enabled = true;

    }
}

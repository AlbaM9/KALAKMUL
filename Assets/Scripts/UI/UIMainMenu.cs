using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public Saved saveData;
    
    public string levels;

    public PlayerStats health;
    public PlayerController mun;

    public Camera mainCamera;
    public Camera animationCam;

    public GameObject initialMenu;

   
   

    private void Awake()
    {

        Time.timeScale = 1;
        initialMenu.SetActive(false);
        mainCamera.enabled = false;
        animationCam.enabled = true;

        StartCoroutine(TimerMenu());
    }
    void Start()
    {
       

        health = FindObjectOfType<PlayerStats>();
        mun = FindObjectOfType<PlayerController>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            mainCamera.enabled = true;
            animationCam.enabled = false;
            initialMenu.SetActive(true);
        }
       
    }
    public void NewGameButton() 
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetString("Scene", "Level1");
        Time.timeScale = 1;

    }
    public void ContMainButton() 
    {
        levels =  PlayerPrefs.GetString("Scene");
        SceneManager.LoadScene(levels);
        PlayerPrefs.GetFloat("life", 100f);
        
        PlayerPrefs.GetInt("bullets", 10);


        Time.timeScale = 1;
        
        
        
    }
    IEnumerator TimerMenu()
    {
        
        yield return new WaitForSeconds(14);
        initialMenu.SetActive(true);
        mainCamera.enabled = true;
        animationCam.enabled = false;
    }
    public void ExitButt() 
    {
        Application.Quit();
    }
}

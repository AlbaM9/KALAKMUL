using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float pHealth = 100.0f;
    public Animator anim;

    public Image lifeBar;
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth <= 0f)
        {
            //anim.SetBool("Die", true);
            anim.SetBool("Death", true);
           
            
        }
        else
        {
            anim.SetBool("Death", false);
        }

        lifeBar.fillAmount = pHealth / 100;
    }
   
}

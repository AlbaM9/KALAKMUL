using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float pSpeed = 5.0f;
    public float velRotate = 200.0f;
    private Animator anim;
    public float x, y, rot;

    public GameObject weapon;
    public Transform weapPos;

    public Transform shootP;
    public int shootRange;

   // public MostroController mostroHealth;
    public int munition = 10;

    public GameObject bulletpoint;

   // private float lastTimeShoot = Mathf.NegativeInfinity;

    public Text munCount;
    //public LayerMask hittablelayers;

    public Camera mainCamera;
    public Camera shootCam;

    public Transform cam;
    public int lvl;

    public Transform enemy;
    

   
   
    
    void Start()
    {

        shootCam.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animator>();
        weapon.gameObject.SetActive(false);
        //mostroHealth = FindObjectOfType<MostroController>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rot = Input.GetAxis("Mouse X");

        // transform.Rotate(0, cam.eulerAngles.y* Time.deltaTime, 0);
        var CharacterRotation = cam.transform.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.z = 0;
        transform.rotation = CharacterRotation;
     
     //  transform.Rotate(0,rot*velRotate *Time.deltaTime, 0);
       
        transform.Translate(0, 0, y * Time.deltaTime * pSpeed);
        transform.Translate (x * Time.deltaTime * pSpeed,0,0);
        

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        ShootAttack();
        munCount.text = munition + "/10";
       
    }

     void ShootAttack() 
    {

        if (Input.GetButton("Fire1"))
        {

            mainCamera.enabled = false;
            shootCam.enabled = true;
            anim.SetBool("FireON", true);
            weapon.gameObject.SetActive(true); //el arma aparece.
            pSpeed = 0.5f;

            if (munition > 0)
            {
                RayCast();
            }
           

           
           
        }
        else
        {
            anim.SetBool("FireON", false);
            mainCamera.enabled = true;
            shootCam.enabled = false;
            weapon.gameObject.SetActive(false);
        }

    }
    void RayCast ()
    {
        RaycastHit hit;
        Ray ray = new Ray(shootP.position, transform.forward);
        

        Debug.DrawRay(shootP.position, transform.forward * shootRange, Color.blue);
       

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Disparo");
            munition -= 1;

            if (Physics.Raycast(shootP.position, transform.forward, out hit, shootRange, LayerMask.GetMask("Enemy")))
            {

                Debug.Log("Herido");
                GameObject bulletHoleClone = Instantiate(bulletpoint, hit.point, Quaternion.LookRotation(hit.normal));
                //para que se destruya despues de 5 segundos
                Destroy(bulletHoleClone, 4f);
                hit.collider.GetComponent<MostroController>().GetDamaged();


            }
        }
       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class script_third_person_controller : MonoBehaviour
{
    // This script houses:
    //player movement, shoot, aim, and eventually pause control
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera swordVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private GameObject pfArrowProjectile;
    [SerializeField] private Transform arrowSpawn;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    //public UI_Control uI_Control;
    public float darknessCount = 0;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();

    public Animator animator;
    private int animFiring; 
    private int animAiming; 
    private bool shootCheck;

    float swapWaitVar = 1;
    Vector3 mouseWorldPosition;
    public GameObject reticle;
    public GameObject sword;
    public GameObject bow;
    public GameObject swordlitOBJ;
    public GameObject bowlitOBJ;
    public GameObject postprocessing;

    public bool swordLit;
    public bool bowLit;
    
    AudioSource audioSource;
    public AudioClip bowClip;
    public AudioClip macuaClip;

    //public GameObject WinCanvas;




    //public static bool PauseGame = false;
    //public GameObject pauseUI;


    private void Start()
    {
        Debug.Log(starterAssetsInputs.escape);
        
                //Debug.Log(UI_Control.PauseGame);
        AssignAnimationIDs();
        swordLit = false;
        bowLit = false;
        audioSource = GetComponent<AudioSource>();
    }
    private void Awake()

    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        darknessCount = 0;
        starterAssetsInputs.bow = true;
        animator = GetComponent<Animator>();
        //Debug.Log(starterAssetsInputs.bow);
        //Debug.Log(starterAssetsInputs.sword);

    }
    private void Update()
    {
         mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //DebugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;

        }



        if (starterAssetsInputs.bow)
        {
            
            if(bowLit)
            {
                bowlitOBJ.SetActive(true);
                bow.SetActive(false);
                sword.SetActive(false);
                swordlitOBJ.SetActive(false);
            }else if (bowLit == false)
            {
                bowlitOBJ.SetActive(false);
                bow.SetActive(true);
                sword.SetActive(false);
                swordlitOBJ.SetActive(false);
            }
            
            
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * swapWaitVar));

            
            
            //Debug.Log("equipped bow");
            starterAssetsInputs.sword = false;
            if (starterAssetsInputs.Aim)
            {
                reticle.SetActive(true);
                starterAssetsInputs.sprint = false;
                animator.SetBool(animAiming, true);
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(aimSensitivity);
                thirdPersonController.SetRotateOnMove(false);

                Vector3 worldAimTarget = mouseWorldPosition;
                worldAimTarget.y = transform.position.y;

                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;


                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            }
            else
            {
                reticle.SetActive(false);
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetBool(animAiming, false);
                
            }

            if (starterAssetsInputs.shoot && starterAssetsInputs.Aim)
            {
                //INSERT THE SOUND CLIP HERE FOR BOW
                starterAssetsInputs.sprint = false;
                animator.SetBool(animFiring, true);
                shootCheck = true;
                //Debug.Log(animFiring);
                Invoke ("FiringTheBow", 0.5f);
                starterAssetsInputs.shoot = false;
                 //audioSource.PlayOneShot(bowClip, 0.1F);

                
            }
            else if (starterAssetsInputs.shoot == false && shootCheck == true)
            {
                Invoke ("waitShoot", .667f);
            }
        }
        else 
        {
            starterAssetsInputs.bow = false;
            aimVirtualCamera.gameObject.SetActive(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * swapWaitVar));
            //animator.SetBool(animAiming, false);

        }

        //type of weapon sword---------
        if (starterAssetsInputs.sword)
        {
            if(swordLit)
            {
                bowlitOBJ.SetActive(false);
                bow.SetActive(false);
                sword.SetActive(false);
                swordlitOBJ.SetActive(true);
            }else if (swordLit == false)
            {
                bowlitOBJ.SetActive(false);
                bow.SetActive(false);
                sword.SetActive(true);
                swordlitOBJ.SetActive(false);
            }
            
            animator.SetLayerWeight(3, Mathf.Lerp(animator.GetLayerWeight(3), 1f, Time.deltaTime * swapWaitVar));
            
            starterAssetsInputs.bow = false;
            swordVirtualCamera.gameObject.SetActive(true);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;

            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;


            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if (starterAssetsInputs.shoot)
            {
                //actually means swing but theyre both bound to left click
                //INSERT THE SOUND CLIP HERE
                animator.SetBool(animFiring, true);
                shootCheck = true;
                starterAssetsInputs.shoot = false;
                //audioSource.PlayOneShot(macuaClip, 0.5F);

                
                
            }else if (starterAssetsInputs.shoot == false && shootCheck == true)
            {
                Invoke ("waitShoot", .667f);
            }


        }
        else
        {
            swordVirtualCamera.gameObject.SetActive(false);
            starterAssetsInputs.sword = false;
            animator.SetLayerWeight(3, Mathf.Lerp(animator.GetLayerWeight(3), 0f, Time.deltaTime * swapWaitVar));

        }


    }
    private void AssignAnimationIDs()
		{
			animFiring = Animator.StringToHash("Firing");
            animAiming = Animator.StringToHash("Aiming");
			

		}


    private void waitShoot ()
    {
        animator.SetBool(animFiring, false);
        shootCheck = false;
    }
    private void FiringTheBow ()
    {
         Vector3 worldAimTarget = mouseWorldPosition;
                worldAimTarget.y = transform.position.y;

                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;


                transform.forward = Vector3.Lerp(transform.forward, aimDirection, 200f);



                Vector3 aimDir = (mouseWorldPosition - arrowSpawn.position).normalized;
                Instantiate(pfArrowProjectile, arrowSpawn.position, Quaternion.LookRotation(aimDir, Vector3.up));
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Solstice")
        {
           //WinCanvas.SetActive(true);
           SceneManager.LoadScene("scene_solstice");
        }

        if (collider.tag == "Eclipse")
        {
           //WinCanvas.SetActive(true);
           SceneManager.LoadScene("Scene_eclipse");
        }

        if (collider.tag == "Win")
        {
            SceneManager.LoadScene("scene_hub");
        }
        if (collider.tag == "Equinox")
        {
            SceneManager.LoadScene("scene_boss");
        }
    }
}
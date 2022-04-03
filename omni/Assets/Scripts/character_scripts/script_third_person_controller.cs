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
    [SerializeField] private Transform pfArrowProjectile;
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




    //public static bool PauseGame = false;
    //public GameObject pauseUI;


    private void Start()
    {
        Debug.Log(starterAssetsInputs.escape);
        //Debug.Log(UI_Control.PauseGame);
        AssignAnimationIDs();
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

        //weapon swapping


        if (!starterAssetsInputs.bow && !starterAssetsInputs.sword)
        {
            animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 1f, Time.deltaTime));
        }
        else
        animator.SetLayerWeight(2, Mathf.Lerp(animator.GetLayerWeight(2), 0f, Time.deltaTime)); 



        if (starterAssetsInputs.bow)
        {
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * swapWaitVar));
            
            
            
            //Debug.Log("equipped bow");
            starterAssetsInputs.sword = false;
            if (starterAssetsInputs.Aim)
            {
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
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetBool(animAiming, false);
                
            }

            if (starterAssetsInputs.shoot && starterAssetsInputs.Aim)
            {
                animator.SetBool(animFiring, true);
                shootCheck = true;
                //Debug.Log(animFiring);
                Invoke ("FiringTheBow", 0.5f);
                starterAssetsInputs.shoot = false;

                
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
            //TEMPPPPPPPPPPPPPPPPPPPP
            animator.SetLayerWeight(3, Mathf.Lerp(animator.GetLayerWeight(3), 2f, Time.deltaTime * swapWaitVar));
            
            //Debug.Log("equipped sword");
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
                //swing animation
                starterAssetsInputs.shoot = false;

                //play animation oneshotalse;
                //lurch?
                //set collider active

            }


        }
        else
        {
            swordVirtualCamera.gameObject.SetActive(false);
            starterAssetsInputs.sword = false;
            animator.SetLayerWeight(3, Mathf.Lerp(animator.GetLayerWeight(3), 0f, Time.deltaTime * swapWaitVar));




        }


       /* if (starterAssetsInputs.escape && UI_Control.PauseGame == true)
        {
            starterAssetsInputs.escape = false;
            Debug.Log("internal notice esc");
            uI_Control.Resume();



        }

        if (starterAssetsInputs.escape && UI_Control.PauseGame == false)
        {
            starterAssetsInputs.escape = false;
            Debug.Log("noticed other");
            uI_Control.Pause();
            
        } */

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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_projectile : MonoBehaviour
{
    //projectile------------
    public GameObject bullet;
    //projectile force----------------
    public float shootForce;
    public float upwardForce;
    //projectile stats--------------------
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //checking-------------------------
    bool shooting, readyToShoot, reloading;

    //references to scene-------------------------
    public Camera cam;
    public Transform attackPoint;

    //visuals---------------------------------
    public GameObject projectileFlash;
    public TextMeshProUGUI ammoDisplay;

    public bool allowInvoke = true;
    // Start is called before the first frame update
    private void Awake ()
    {
        //mag full?------------------------
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update ()
    {
        MyInput();

        if (ammoDisplay != null)
        {
            ammoDisplay.SetText(bulletsLeft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput ()
    {
        //Can I hold down the button? Auto----------
        if (allowButtonHold == true)
        {
            //needs to be updated to allow for controller access***********
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else 
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }


        //shooting--------------------
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }

        //reloading---------------------
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload ();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <=0 )

        {
            Reload();
        }
    }
    private void Shoot ()
    {
        readyToShoot = false;
        //aiming------------------------
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //did the ray hit?---------------
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        } else 
        {
            targetPoint = ray.GetPoint(75); 
        }

        //Direction-------------------------
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //spread
        float x = Random.Range(-spread, spread);
        float y= Random.Range(-spread, spread);

        //Direction with Spread----------------------
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3 (x, y, 0);

        //instantiate---------------------------------
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);


        //bullet rotation------
        currentBullet.transform.forward = directionWithSpread.normalized;

        //move--------------------
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(cam.transform.up * upwardForce, ForceMode.Impulse);

        //exit
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //multiple projectiles?------------------
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShooting);

        }

        //projectile flare---------------
        if (projectileFlash !=null)
        {
            Instantiate (projectileFlash, attackPoint.position, Quaternion.identity);
        }
        bulletsLeft--;
        bulletsShot++;
    }

    private void ResetShot ()
    {
        allowInvoke = true;
        readyToShoot = true;
    }
    private void Reload ()
    {
        reloading = true;
        
        Invoke("ReloadFinished", reloadTime);
        

    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

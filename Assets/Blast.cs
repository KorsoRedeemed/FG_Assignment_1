using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(LineRenderer))]

public class Blast : MonoBehaviour
{
    public int damage = 1;
    public float range = 100f;
    public float laserDuration = 0.5f;

    public int maxAmmo = 1;
    public int currentAmmo = 1;

    public GameObject shootPos;
    public Camera playerCam;

    public GameObject laserLine;
    private LineRenderer lr;

    [SerializeField] private TextMeshProUGUI ammoDisplay;

    void Start()
    {
        if (currentAmmo == -1)
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();
        if(Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
    }

    public void Reload()
    {
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
    }


    void Shoot() 
    {
        currentAmmo--;
        GameObject lazer = Instantiate(laserLine);
        lr = lazer.GetComponent<LineRenderer>();
        lr.enabled = true;
        lr.SetPosition(0, shootPos.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, shootPos.transform.position.z), playerCam.transform.forward, out hit, Mathf.Infinity))
        {
            lr.SetPosition(1, hit.point);
            Debug.Log(hit.transform.name);
            if(hit.transform.GetComponent<PlayerManager>() != null)
            {
                hit.transform.GetComponent<PlayerManager>().currentHealth -= damage;
            }
            
        }
    }
    

    
}

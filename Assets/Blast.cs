using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Blast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float laserDuration = 1f;

    public GameObject shootPos;
    public Camera playerCam;

    public GameObject laserLine;
    private LineRenderer lr;

    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Awake()
    {
        
    }

    void Shoot() 
    {
        GameObject lazer = Instantiate(laserLine);
        lr = lazer.GetComponent<LineRenderer>();
        lr.enabled = true;
        lr.SetPosition(0, shootPos.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, shootPos.transform.position.z), playerCam.transform.forward, out hit, Mathf.Infinity))
        {
            lr.SetPosition(1, hit.point);
            Debug.Log(hit.transform.name);
        }
    }
    

    
}

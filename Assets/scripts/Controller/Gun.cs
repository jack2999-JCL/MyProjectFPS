using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;

    reload ammoScript;

    public Camera fpsCam;
    
    // Start is called before the first frame update
    void Start()
    {
           ammoScript = GetComponent<reload>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && !ammoScript.needReload)
            Shoot();
        
    }
    
    void Shoot()
    {
        
        RaycastHit hit;
        ammoScript.currentAmmo--;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            BoxKey box = hit.transform.GetComponent<BoxKey>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }
            Boss boss = hit.transform.GetComponent<Boss>();
            if(boss != null)
            {
                boss.TakeDamage(damage);
            }
        }
    }
}

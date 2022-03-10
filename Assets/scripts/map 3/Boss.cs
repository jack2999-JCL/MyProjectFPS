using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{


    public float currentHealthBoss = 800;
    public Slider healthBarBoss;

    public Transform bullets;
    public Transform spawnPoint;
    
    public bool openFire = false;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (openFire == true)
        {
            Fire();
        }

    }

    void Fire()
    {
        Instantiate(bullets, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(transform.forward * 7000);
        openFire = false;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        if (openFire == false)
        {
            yield return new WaitForSeconds(3);
            openFire = true;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealthBoss -= damage;
        healthBarBoss.value = currentHealthBoss;
        if (currentHealthBoss <= 0)
        {
            
            Die();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}


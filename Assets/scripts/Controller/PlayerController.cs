using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public CharacterController Controller;

    public float Jump;
    // public bool isOnGround = true;
    public float Speed;
    public int damage = 5;

    public float currentHealth = 100;
    public Slider healthBar;
    
    public GameObject healthBarBoss;
    public GameObject nameBoss;
    public GameObject Boss;
    public GameObject Ammo;
    public bool BossAttack = false;
    public int damageAttack = 35;


    private float HoriInput;
    private float VertiInput;



    public bool HaveKey;
    public TargetSpawn target;
    public Animation door1;
    public Animation door2;

    // Start is called before the first frame update
    void Start()
    {
        Ammo.SetActive(true);
        playerRB = GetComponent<Rigidbody>();
        // target.winMap = false;
        // winMap1 = false;
        HaveKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        // {
        //     playerRB.AddForce(Vector3.up * Jump, ForceMode.Impulse);
        //     isOnGround = false;
        // }

        // currentHealth -= 1;
        // healthBar.value = currentHealth;
        // if (currentHealth < 0)
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }

    }
    private void FixedUpdate()
    {

        PlayerMovement();
    }
    void PlayerMovement()
    {
        if (target.winMap == true)
        {
            HoriInput = Input.GetAxis("Horizontal");
            VertiInput = Input.GetAxisRaw("Vertical");
        }
        Vector3 move = transform.right * HoriInput + transform.forward * VertiInput;
        Controller.Move(move * Speed * Time.deltaTime);
        // transform.Translate(0, 0, VertiInput);
        // transform.Rotate(0, HoriInput, 0);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            // Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        // else if (collision.gameObject.CompareTag("Ground"))
        // {
        //     isOnGround = true;
        // }

        // else
         if (collision.gameObject.CompareTag("Key"))
        {

            HaveKey = true;
            door1.Play();
            door2.Play();
        }
        else if (collision.gameObject.CompareTag("FightBoss"))
        {
            Boss.SetActive(true);
            healthBarBoss.SetActive(true);
            nameBoss.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            currentHealth -= damage;
            healthBar.value = currentHealth;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            BossAttack = true;
            currentHealth -= damageAttack;
            healthBar.value = currentHealth;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    // public void TakeDamage (float damage)
    // {

    // }
}

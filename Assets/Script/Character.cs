using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject healthText;
    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;

    //If health <=0, unable to move and becomes false
    bool canMove = true;
    

    public Animator playerAnim;
    public Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();

        //Health
        healthText.GetComponent<Text>().text = "Start Function";
        healthText.GetComponent<Text>().text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.W)) 
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.S)) 
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.A)) 
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.D)) 
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                playerAnim.SetTrigger("AttackTrigger");
            }

        }

        else
        {
            playerAnim.SetBool("IsWalkBool", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire" && canMove == true)
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health: " + health.ToString();

            if (health <= 0)
            {
                healthText.GetComponent<Text>().text = "Health: 0";
                playerAnim.SetTrigger("DeadTrigger");
                canMove = false;
            }
        }
    }
}


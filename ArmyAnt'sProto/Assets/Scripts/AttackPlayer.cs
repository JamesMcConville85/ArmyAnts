using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    //public float attackDistance = 15f;
    public float attackDamage = 35f;
    private Transform player;
    public Transform head;
    Animator Insect;
    Collider other;
    // in your Start method
    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0;
   public float rotSpeed = 0.2f;
   public float speed = 1.5f;
   public float accuracyWP = 5.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Ant9.4").GetComponent<Transform>();
        Insect = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);
        if (state == "patrol" && waypoints.Length > 0)
        {
            Insect.SetBool("isIdle", false);
            Insect.SetBool("isWalking", true);

            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }
            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);
        }
        if (Vector3.Distance(player.position, this.transform.position) < 60 && (angle < 180 || state == "pursuing"))
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            Insect.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            //  
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                Insect.SetBool("isWalking", true);
                Insect.SetBool("isAttacking", false);


            }
            else
            {
                Insect.SetBool("isAttacking", true);
                Insect.SetBool("isIdle", false);
                Insect.SetBool("isWalking", false);
            }
        }
        else
        {
            Insect.SetBool("isIdle", false);
            Insect.SetBool("isAttacking", false);
            Insect.SetBool("isWalking", true);
            state = "patrol";
        }

    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthBar>().TakeDamage(attackDamage);
        Insect.SetBool("isAttacking", true);
        Insect.SetBool("isWalking", false);
        // {
        //other.transform.GetComponent<EnemyHealth>().RemoveHealth(attackDamage);
    }
}





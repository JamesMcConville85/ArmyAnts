using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAttackPlayer : MonoBehaviour {

    //public float attackDistance = 15f;
    public float attackDamage = 65f;
    private Transform player;
    public Transform head;
    Animator DragonController;
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
        DragonController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);
        if (state == "patrol" && waypoints.Length > 0)
        {
            DragonController.SetBool("isIdle", false);
            DragonController.SetBool("isRun", true);

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
        if (Vector3.Distance(player.position, this.transform.position) < 260 && (angle < 360 || state == "pursuing"))
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            DragonController.SetBool("isIdle", false);
            if (direction.magnitude > 6.5)
            //  
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                DragonController.SetBool("isRun", true);
                DragonController.SetBool("isAttack", false);


            }
            else if (direction.magnitude < 11.5)
            {
                DragonController.SetBool("isAttack", true);
                DragonController.SetBool("isIdle", false);
                DragonController.SetBool("isRun", false);
            }
        }
        else
        {
            DragonController.SetBool("isIdle", false);
            DragonController.SetBool("isAttack", false);
            DragonController.SetBool("isRun", true);
            state = "patrol";
        }

    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthBar>().TakeDamage(attackDamage);
        DragonController.SetBool("isAttack", true);
        DragonController.SetBool("isRun", false);
        // {
        //other.transform.GetComponent<EnemyHealth>().RemoveHealth(attackDamage);
    }
}





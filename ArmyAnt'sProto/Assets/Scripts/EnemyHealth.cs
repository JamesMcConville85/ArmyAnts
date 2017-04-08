using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyHealth : MonoBehaviour {

    public float health = 100f;
   // public bool isPlayer = true;
    static Animator Insect;
    // Use this for initialization
    void Start()
    {
   
        Insect = GetComponent<Animator>();
    }

    public void RemoveHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //Insect.SetBool("isWalking", true);
            //Insect.SetBool("isIdle", false);
             Destroy(gameObject);
        }
        }
    }



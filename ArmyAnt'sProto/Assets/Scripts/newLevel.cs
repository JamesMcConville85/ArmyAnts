using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class newLevel : MonoBehaviour {
    public float healDamage = 10f;
    Collider other;
    private Transform player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Ant9.4").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<HealthBar>().RecoverHealth(healDamage);
        SceneManager.LoadScene(2);
        Debug.Log("Heal");
        // {
        //other.transform.GetComponent<EnemyHealth>().RemoveHealth(attackDamage);
    }
}

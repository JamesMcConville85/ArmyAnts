using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayers : MonoBehaviour {
    public float healDamage = 10f;
    Collider other;
    private Transform player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Ant9.4").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthBar>().RecoverHealth(healDamage);
        Debug.Log("Heal");
        Destroy(gameObject);
        // {
        //other.transform.GetComponent<EnemyHealth>().RemoveHealth(attackDamage);
    }
}

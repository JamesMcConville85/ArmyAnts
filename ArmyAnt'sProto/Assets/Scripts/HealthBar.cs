using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour {

    public Image currentHealthBar;
    public Text ratioText;

    public float hitpoint = 150;
    public float maxHitpoint = 150;

	
	// Update is called once per frame
	private void Start () {
        UpdateHealthbar();
	}

    private void UpdateHealthbar() {
        float ratio = hitpoint / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio,1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    public void TakeDamage(float damage) {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            SceneManager.LoadScene(0);
        }
        UpdateHealthbar();
    }

    public void RecoverHealth(float heal) {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
            Debug.Log("heal!!");
        }
        UpdateHealthbar();
    }

}

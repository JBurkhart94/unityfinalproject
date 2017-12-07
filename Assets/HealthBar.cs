using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Image healthBar;
    public float currentHealth;
    private float hitPoint;

	// Use this for initialization
	void Start () {
        currentHealth = 150f;
        hitPoint = 150f;
        UpdateHealthBar();

	}

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float ratio = currentHealth / hitPoint;
        healthBar.transform.localScale = new Vector3(ratio,1,1);
    }

    public void takeDamage(float dmg) {
        this.currentHealth -= dmg;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        Debug.Log("RIP");
    }

    public void Heal(float heal) {
        this.currentHealth += heal;
        if (currentHealth > 150) {
            currentHealth = 150;
        }
        Debug.Log("Full");
    }
}

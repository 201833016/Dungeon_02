using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth, maxHealth;    // 현재 체력,  최대 체력
    //[SerializeField] private int currentHealth  = 10;   // 
    //[SerializeField] private GameObject bloodParticle;

    //[SerializeField] private Renderer renderer;
    //[SerializeField] private float flashTime = 0.2f;

    public void AddHealth(int heal) // 회복 아이템 사용시
    {
        currentHealth += heal;
    }

    public void Reduce(int damage)  // 체력 감소 시
    {
        currentHealth -= damage;
        //CreateHitFeedback();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
/*
    private void CreateHitFeedback()
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        StartCoroutine(FlashFeedback());
    }

    private IEnumerator FlashFeedback()
    {
        renderer.material.SetInt("_Flash", 1);
        yield return new WaitForSeconds(flashTime);
        renderer.material.SetInt("_Flash", 0);
    }
    */

    private void Die()
    {
        Debug.Log("Died");
        currentHealth = maxHealth;
    }
}
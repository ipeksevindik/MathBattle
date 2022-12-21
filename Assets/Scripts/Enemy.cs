using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth;

    public Image[] hearts;
    public Question question;



    void Start()
    {
        anim = GetComponent<Animator>();
      
    }

    public void TakeDamage()
    {
        maxHealth--;

        anim.SetTrigger("isHurt");

        hearts[maxHealth].enabled = false;

        if (maxHealth <= 0)
        {
            EnemyDie();
        }


    }

    public void EnemyDie()
    {
        SceneManager.LoadScene("Win");
        
    }


    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Knife")
        {
            Debug.Log("zarar verildi");
            TakeDamage();


        }

    }
}

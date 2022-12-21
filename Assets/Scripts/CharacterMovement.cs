using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Weapon;
    private Animator anim;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public int maxHealth;

    public Image[] hearts1;
    public Question question;


    void Start()
    {
     
        anim = GetComponent<Animator>();
    }


    public void Shoot()
    {
        GameObject tmp = Instantiate(Weapon, parent: FirePoint);
        tmp.transform.localPosition = Vector3.zero;

    }

    public void CharacterAttack()
    {
        anim.SetTrigger("isAttack");
        Shoot();
        
    }

    public void CharacterHurt()
    {
        anim.SetTrigger("isHurt");

        maxHealth--;

        hearts1[maxHealth].enabled = false;

        if (maxHealth <= 0)
        {
            CharacterDie();
        }
    }



    public void CharacterDie()
    {
        SceneManager.LoadScene("Lost");

    }


}

 

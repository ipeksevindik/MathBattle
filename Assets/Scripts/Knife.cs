using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rb;
    public float knifeSpeed;
    public float endTime;

    CharacterMovement character;
    Enemy enemy;



    void Start()
    {
        character = GetComponent<CharacterMovement>();
        enemy = GetComponent<Enemy>();
        
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * knifeSpeed;
        Destroy(gameObject, endTime);
    }

    void Update()
    {
        

    }




}
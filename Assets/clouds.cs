using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class clouds : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float MaxX = 10;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * speed;

    }

    private void Update()
    {

        if (transform.position.x > MaxX) { 
        
            gameObject.SetActive(false);
        
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class player : MonoBehaviour
{

    [SerializeField] float xBounds = 7f;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float strength = 11f;
    [SerializeField] float maxRot = 10f;
    Rigidbody2D rigidbody;

    

    private void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("score", 0);

    }

    private void FixedUpdate()
    {

        if ((transform.position.x < xBounds && Input.GetAxis("Horizontal") > 0) || (transform.position.x > -xBounds && Input.GetAxis("Horizontal") < 0))
        {

            rigidbody.velocity = Vector2.right * xBounds * speed * Input.GetAxis("Horizontal");

        }

        else {

            rigidbody.velocity = Vector2.zero;
        
        }

        if ((transform.rotation.z * Mathf.Rad2Deg < maxRot && Input.GetKey(KeyCode.Mouse0))) {

            transform.Rotate(Vector3.forward);
        
        }

        if ((transform.rotation.z * Mathf.Rad2Deg > -maxRot && Input.GetKey(KeyCode.Mouse1))) {

            transform.Rotate(-Vector3.forward);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("egg")) {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * strength, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<egg>().playSound(collision.gameObject.GetComponent<egg>().bounce);


        }

    }

}

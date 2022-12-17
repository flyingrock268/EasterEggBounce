using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour
{
    [SerializeField] float strength = 5;
    [SerializeField] int side = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("egg"))
        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * strength * side, ForceMode2D.Impulse);

        }

    }
}

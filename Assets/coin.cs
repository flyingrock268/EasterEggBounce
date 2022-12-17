using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("egg")) {

            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);

            gameObject.SetActive(false);
            collision.gameObject.GetComponent<egg>().playSound(collision.gameObject.GetComponent<egg>().bunny);


        }

    }

}

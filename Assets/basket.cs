using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{

    [SerializeField]GameObject egg;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("egg"))
        {

            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);

            GameObject newEgg = Instantiate(egg);
            newEgg.transform.position = Vector3.zero;

            collision.gameObject.GetComponent<egg>().playSound(collision.gameObject.GetComponent<egg>().basket);

            gameObject.SetActive(false);

        }

    }
}

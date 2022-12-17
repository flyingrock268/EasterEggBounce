using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class egg : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float minHeight;
    public AudioClip bounce;
    public AudioClip bunny;
    public AudioClip basket;

    AudioSource AS;

    private void Start()
    {
        
        AS = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        StartCoroutine(DelayGravity(1.5f));

    }

    private void Update()
    {

        if (transform.position.y < minHeight) { 
        
            Destroy(gameObject);
        
        }

    }

    IEnumerator DelayGravity(float wait) {

        yield return new WaitForSeconds(wait);
        rb.gravityScale = 1;
    
    }

    public void playSound(AudioClip sound) {

        AS.PlayOneShot(sound);
    
    }

}

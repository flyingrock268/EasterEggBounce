using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject bunnyPrefab;
    [SerializeField] int maxBunnies = 5;

    [SerializeField] GameObject basketPrefab;
    [SerializeField] int maxBaskets = 1;
    bool enableBasketSpawn = false;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject cloudPrefab;
    [SerializeField] int maxClouds = 15;

    Vector2 min = new Vector2 (-7,-3);
    Vector2 max = new Vector2 (7,2.25f);

    [SerializeField]AudioClip clip;

    GameObject[] bunnies;
    GameObject[] baskets;
    GameObject[] clouds;

    Coroutine end;

    void Start()
    {

        bunnies = new GameObject[maxBunnies];
        baskets = new GameObject[maxBaskets];
        clouds = new GameObject[maxClouds];

        if (bunnyPrefab != null) {

            for (int i = 0; i < maxBunnies; i++) { 
            
                bunnies[i] = Instantiate(bunnyPrefab);
                bunnies[i].SetActive(false);
            
            }
        
        }

        StartCoroutine(spawnBunnies(2, 2));

        if (basketPrefab != null) {

            for (int i = 0; i < maxBaskets; i++)
            {

                baskets[i] = Instantiate(basketPrefab);
                baskets[i].SetActive(false);

            }

        }

        StartCoroutine(spawnBaskets(2, 2));

        if (cloudPrefab != null)
        {

            for (int i = 0; i < maxClouds; i++)
            {

                clouds[i] = Instantiate(cloudPrefab);
                clouds[i].SetActive(false);

            }

        }

        StartCoroutine(spawnClouds(1,3));

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("egg").Length == 0 && end == null) {
            
            end = StartCoroutine(gameOver());
        
        }

        if (PlayerPrefs.GetInt("score") % 10 == 0 && PlayerPrefs.GetInt("score") != 0) { 
        
            enableBasketSpawn = true;
        
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        
        }

    }

    IEnumerator gameOver()
    {

        GetComponent<AudioSource>().PlayOneShot(clip);

        yield return new WaitForSeconds(2);

        Debug.Log("you lose");
        SceneManager.LoadScene("loseScene");

    }

    IEnumerator spawnBunnies(float start, float interval) { 
    
        yield return new WaitForSeconds(start);

        while (true) {

            spawnBunny();

            yield return new WaitForSeconds(interval);
        
        }
    
    }

    GameObject spawnBunny() {

        foreach (GameObject obj in bunnies) {

            if (!obj.activeSelf) {

                obj.transform.position = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
                obj.SetActive(true);

                if (Random.Range(0, 2) == 0)
                {

                    obj.transform.rotation = Quaternion.Euler(0, 180, 0);

                }

                else {

                    obj.transform.rotation = Quaternion.Euler(0, 0, 0);

                }
                return obj;
            
            }
        
        }

        return null;

    }

    IEnumerator spawnBaskets(float start, float interval) {

        yield return new WaitForSeconds(start);

        while (true)
        {

            spawnBasket();

            yield return new WaitForSeconds(interval);

        }

    }

    GameObject spawnBasket()
    {

        foreach (GameObject obj in baskets)
        {

            if (!obj.activeSelf && enableBasketSpawn)
            {

                obj.transform.position = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
                obj.SetActive(true);
                enableBasketSpawn = false;
                return obj;

            }

        }

        return null;

    }

    IEnumerator spawnClouds(float intervalMax, float intervalMin) {

        while (true) { 
        
            yield return new WaitForSeconds (Random.Range(intervalMin, intervalMax));
            spawnCloud();
        
        }
    
    }

    GameObject spawnCloud() {

        foreach (GameObject obj in clouds)
        {

            if (!obj.activeSelf)
            {

                obj.transform.position = new Vector3(-10, Random.Range(1f, 5f), 0);
                obj.SetActive(true);

                if (Random.Range(0, 2) == 0)
                {

                    obj.transform.rotation = Quaternion.Euler(0, 180, 0);

                }

                else
                {

                    obj.transform.rotation = Quaternion.Euler(0, 0, 0);

                }
                return obj;

            }

        }

        return null;

    }



    public void Continue() {

        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }

    public void Quit()
    {

        Application.Quit();

    }
}

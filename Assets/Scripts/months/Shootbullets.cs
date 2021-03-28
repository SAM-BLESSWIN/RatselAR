using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Shootbullets : MonoBehaviour
{
    private int totalscore;
    [SerializeField] private Transform arcamera;
    [SerializeField]
    private GameObject win;
    public GameObject bullet;
    public float shootforce;


    private GameObject clone;
    private bool isend;

    public void shoot()
    { 
        clone = Instantiate(bullet, arcamera.position, arcamera.rotation) as GameObject;
        clone.GetComponent<Rigidbody>().AddForce(arcamera.forward * shootforce);
        
    }

    private void Update()
    {
        isend = clone.GetComponent<Explode>().end();
        if (isend)
        {
            StartCoroutine(loadwin());   
        }
    }

    IEnumerator loadwin()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        win.SetActive(true);
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (currentlevel - 20 >= PlayerPrefs.GetInt("GENERALLEVELUNLOCKED"))
        {
            PlayerPrefs.SetInt("GENERALLEVELUNLOCKED", (currentlevel - 20) + 1);

            totalscore = PlayerPrefs.GetInt("TOTALSCORE") + 100;
            PlayerPrefs.SetInt("TOTALSCORE", totalscore);
        }
    }
}

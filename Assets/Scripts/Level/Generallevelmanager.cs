using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Generallevelmanager : MonoBehaviour
{
    private int levelsunlocked;
    [SerializeField]
    private Button[] button;
    private TMP_Text[] leveltext = new TMP_Text[5];
    [SerializeField]
    private Sprite locked;

    private void Awake()
    {
        for (int i = 0; i < button.Length; i++)
        {
            leveltext[i] = button[i].GetComponentInChildren<TMP_Text>();
        }
    }

    void Start()
    {
        levelsunlocked = PlayerPrefs.GetInt("GENERALLEVELUNLOCKED", 1);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Button>().enabled = false;
            button[i].image.sprite = locked;
            leveltext[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < levelsunlocked; i++)
        {
            button[i].GetComponent<Button>().enabled = true;
            button[i].image.sprite = null;
            leveltext[i].gameObject.SetActive(true);
        }
    }

    public void Loadscene(int levelindex)
    {
        SceneManager.LoadScene(levelindex);
    }

    public void loadback()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}

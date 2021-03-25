using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Changeaction : MonoBehaviour
{
    [SerializeField]
    private TMP_Text word;
    [SerializeField]
    private int start;
    [SerializeField]
    private int end;

    private string currentword;
    private static int count;

    string[] wordlist = { "sit","stand","Run", "walk", "jump","clap","push","pull","left","right","dance","fight"};

    private void Start()
    {
        count = start;
        changeword();
    }

    public void changeword()
    {
        if(count<end)
        {
            currentword = wordlist[count];
            word.text = currentword;
            count++;
        }
        else
        {
            gameover();
        }
    }

    public string Getword()
    {
        return currentword;
    }

    private void gameover()
    {
        //gameover screen
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Direct : MonoBehaviour
{
    [SerializeField]
    private TMP_Text direction;
    [SerializeField]
    private TMP_Text score;

    private string[] dr = new string[] { "Left", "Right"};
    private static int point=0;

    private AnimalPlacement animalplacement;

    private void OnEnable()
    {
        direction.text = dr[Random.Range(0, 2)]; 
    }

    public void left()
    {
        if(direction.text=="Left")
        {
            point++;
            score.text = point.ToString();
        }

        StartCoroutine(nextdir());
        
    }

    public void right()
    {
        if (direction.text == "Right")
        {
            point++;
            score.text = point.ToString();
        }

        StartCoroutine(nextdir());
    }

    IEnumerator nextdir()
    {
        yield return new WaitForSeconds(1f);
        direction.text = dr[Random.Range(0, 2)];

        animalplacement.center();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Touchb : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoretext;
    private int score=0;
    private void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase==TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag=="b")
                {
                    score += 10;
                    scoretext.text = score.ToString();
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag=="d" || hit.collider.tag == "p" || hit.collider.tag == "q")
                {
                    if(score>0)
                    {
                        score -= 10;
                    }
                    scoretext.text = score.ToString();
                }
            }
        }
    }
}

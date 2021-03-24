using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject lboard;
    [SerializeField]
    private GameObject reg;
    [SerializeField]
    private GameObject reset;

    public void login()
    {
        log.SetActive(true);
    }
    public void loginclose()
    {
        log.SetActive(false);
    }
    public void leaderbd()
    {
        lboard.SetActive(true);
    }
    public void leaderbdclose()
    {
        lboard.SetActive(false);
    }
    public void regis()
    {
        reg.SetActive(true);
    }
    public void regisclose()
    {
        reg.SetActive(false);
    }
    public void resetpwd()
    {
        reset.SetActive(true);
    }
    public void resetpwdclose()
    {
        reset.SetActive(false);
    }
}

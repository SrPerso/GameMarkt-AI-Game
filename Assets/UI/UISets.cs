using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISets : MonoBehaviour { 
    
    public GameObject GoSelected = null;
    public bool uiActive = false;

    public GameObject sun;
    
    //Will Change the status of a game object

    public void PauseTime()
    {
        DayNightController dn = sun.GetComponent<DayNightController>();
        dn.SetActive(!dn.isActive());
    }

    public void EnableDisableGo(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
    //Adds money to te counter
    public void AddMoney(float mon)
    {
        Money.money += mon;
    }
    //Substrackt money to te counter
    public void SubtractMoney(float mon)
    {
        Money.money -= mon;
    }
    //Create a citizen
    public void CreateCitiz(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }

    public void SetBillboardEnable(GameObject go)
    {
        if(!go.activeSelf)
         go.SetActive(!go.activeSelf);
    }

    public void SetBillboardDiasabled(GameObject go)
    {
        if (go.activeSelf)
            go.SetActive(!go.activeSelf);
    }

    public void SetNewObject(GameObject go2Enable)
    {
        Instantiate(go2Enable, GoSelected.transform.position, GoSelected.transform.rotation);
        Destroy(GoSelected);
        GoSelected = null;
    }
    public void UISelected(bool ret)
    {
        uiActive = ret;
    }


    //go to a website  //used to repository link
    public void gotoSite(string url)
    {
        System.Diagnostics.Process.Start(url);
    }
}

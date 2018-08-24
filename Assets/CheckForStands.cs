using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class CheckForStands : ActionTask
{

    public BBParameter<GameObject> Stand;
    public BBParameter<GameObject> Game;
    public BBParameter<GameObject> Pay;
    public BBParameter<float> MyMoney;
    public BBParameter<Money> Moneys;
    public BBParameter<GameObject> Leave;

    private List<GameObject> StandList = new List<GameObject>();
  

 

    protected override void OnExecute()
    {    
        
        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;

            if (g.tag == "stand")
            {
                if (StandList.Contains(g) == false)
                {
                    StandList.Add(g);
                }
            }
            if (g.tag == "Money")
            {
                Moneys.value = (Money)g.GetComponent(typeof(Money));
            }
            if (g.tag == "Leave")
            {
                Leave.value = g;
            }
            float randPay = Random.Range(0, 1);
            if (randPay == 0)
            {
                if (g.tag == "Pay")
                {
                    Pay.value = g;
                }
            }
            else
            {
                if (g.tag == "Pay2")
                {
                    Pay.value = g;
                }

            }
        }
        if (StandList.Count > 0)
        {
            int randNumb = Random.Range(0, StandList.Count - 1);
            Stand.value = StandList[randNumb];
            MyMoney.value = Random.Range(20.0f, 65.0f);
            Game.value = null;
            EndAction(true);
        }
        else
        {
            EndAction(false);
        }
    }

    protected override void OnUpdate()
    {
        
    }
}
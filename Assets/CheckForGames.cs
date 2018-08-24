using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class CheckForGames : ActionTask {

    public BBParameter<GameObject> Game;
    public BBParameter<GameObject> Stand;
    public BBParameter<GameObject> Pay;  
    public BBParameter<float> MyMoney;
    public BBParameter<string> color;
    public BBParameter<Money> Money;
    public BBParameter<GameObject> Leave;
    private List<GameObject> GameList=new List<GameObject>();   

    protected override void OnExecute()
    {      
        
        MyMoney.value = Random.Range(20.0f, 65.0f);
            

        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;            
            if (g.tag == color.value)
            {
                if (GameList.Contains(g) == false)
                {
                    GameList.Add(g);
                }
            }
            if (g.tag == "Money")
            {
                Money.value = (Money)g.GetComponent(typeof(Money));
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

        if (GameList.Count > 0)
        {            
            int randNumb = Random.Range(0, GameList.Count - 1);
            Game.value = GameList[randNumb];
            MyMoney.value = Random.Range(20.0f, 65.0f);
            Stand.value = null;
            EndAction(true);
        }
        else
        {
            EndAction(false);
        }
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
    }
}

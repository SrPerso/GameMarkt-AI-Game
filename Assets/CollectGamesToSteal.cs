using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class CollectGamesToSteal : ActionTask {

    public BBParameter<GameObject> Robber;  
    public BBParameter<GameObject> GameToSteal;
    public BBParameter<Money> Money;
   

    private List<GameObject> StealList = new List<GameObject>();   
  
    protected override void OnExecute()
    {       
        
        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;

            if (g.tag == "red"|| g.tag == "blue"|| g.tag == "green"|| g.tag == "yellow")
            {
                if (StealList.Contains(g) == false)
                {
                    StealList.Add(g);
                }
            }
            if (g.tag == "Money")
            {
                Money.value = (Money)g.GetComponent(typeof(Money));
            }

        }

        int RandNum = Random.Range(0, StealList.Count - 1);
        GameToSteal.value = StealList[RandNum];
        EndAction(true);

    }

    // Update is called once per frame
    protected override void OnUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;
public class CheckForRubbishTask : ActionTask
{

    public BBParameter<GameObject> Cleaner;
    public BBParameter<GameObject> Closest;

    public BBParameter<Animator> m_anim;
	public BBParameter<GameObject> GoHome;

    private List<GameObject> myRubbishList= new List<GameObject>();
   
    private float distance = 2000.0f;

    protected override void OnExecute()
    {
       
       
    }
    protected override void OnUpdate()
    {

        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.tag == "Rubish")
            {
				Closest.value = g;
				EndAction(true);
            }

        }

                     
            EndAction(false);
        

        
        

    }
}


	
	


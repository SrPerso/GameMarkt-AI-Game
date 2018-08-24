using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class ChaseRobber : ActionTask {

    
    public BBParameter<GameObject> Police;
    public BBParameter<GameObject> Robber;
    public BBParameter<NavMeshAgent> Mesh;   
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Animator> m_animator;
    public BBParameter<Move> Move;
    public BBParameter<Money> Money;

    private bool calc;

    // Use this for initialization
    protected override void OnExecute()
    {
        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.tag == "Money")
            {
                Money.value = (Money)g.GetComponent(typeof(Money));
            }
        }
    }
    protected override void OnUpdate()
    {
        if (Robber.value != null)
        {
            if (calc == false)
            {
                calc = true;
                m_animator.value.SetBool("Followig", true);
                Move.value.max_mov_velocity = 3.0f;
                NavMeshPath policePath = new NavMeshPath();
                Mesh.value.CalculatePath(Robber.value.transform.position, policePath);
                if (policePath.corners.Length >= 1)
                {
                    Vector3[] path = new Vector3[policePath.corners.Length];
                    policePath.corners.CopyTo(path, 0);
                    steer.value.SetPathCorners(path);
                    calc = false;
                }
               
            }
            
            
        }
        else
        {
            EndAction(true);
        }
        if(Robber.value!=null)
        {

            float distance2 = (Robber.value.transform.position - Police.value.transform.position).magnitude;
            if (distance2 <= 2.0f)
            {
                Money.value.AddMoney(50.0f);
                calc = false;
                EndAction(true);
            }

        }
        else
        {
            EndAction(true);
        }

    }

}
	
	// Update is called once per frame
	

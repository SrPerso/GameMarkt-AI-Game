using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class MoveToPlace : ActionTask
{
    public BBParameter<GameObject> Nerd;
    public BBParameter<GameObject> Game;
    public BBParameter<Money> Money;
    public BBParameter<GameObject> Stand;
    public BBParameter<string> Color;
    public BBParameter<float> Cost;
    public BBParameter<float> MyMoney;
    public BBParameter<Animator> m_animator;
    public BBParameter<Animator> GameAnimator;
    public BBParameter<NavMeshAgent> NavMesh;
    public BBParameter<SteeringArrive> steer;

    private Vector3 vecPos = Vector3.zero;

    private GameObject Target;
    private bool calc = false;
    private bool isStand = false;
    private float WaitTime = 5.0f;


    protected override void OnExecute()
    {
        Target = new GameObject();
        if (Game.value != null)
        {
            Target = Game.value;
           
        }        
        else
        {
            Target = Stand.value;
            isStand = true;
        }
        vecPos = Target.transform.position;
        if (isStand)
        {
            if (Stand.value.name.Contains("r"))
            {
                Color.value = "red";

            }
            else if (Stand.value.name.Contains("b"))
            {
                Color.value = "blue";

            }
            if (Stand.value.name.Contains("g"))
            {
                Color.value = "green";

            }
            if (Stand.value.name.Contains("y"))
            {
                Color.value = "yellow";

            }
        }

    }

    protected override void OnUpdate()
    {
        if (calc == false)
        {
            m_animator.value.SetBool("moving", true);
            NavMeshPath NerdPath = new NavMeshPath();
            NavMesh.value.CalculatePath(vecPos, NerdPath);
            Vector3[] path = new Vector3[NerdPath.corners.Length];
            NerdPath.corners.CopyTo(path, 0);
            steer.value.SetPathCorners(path);
            calc = true;
        }

        float distance2 = (vecPos - Nerd.value.transform.position).magnitude;
        if (distance2 <= 2.0f)
        {             
           

            if (Color.value == "red")
            {
                Cost.value = Money.value.Cost_Canada;
            }
            else if (Color.value == "green")
            {
                Cost.value = Money.value.Cost_Donuts;
            }
            else if (Color.value == "blue")
            {
                Cost.value = Money.value.Cost_Militar;
            }
            else if (Color.value == "yellow")
            {
                Cost.value = Money.value.Cost_Zombie;
            }

           /* if (MyMoney.value >= Cost.value)
            {
                GameAnimator.value.SetTrigger("Create");
                GameAnimator.value.SetBool("HasGame", true);
            }

                GameAnimator.value.SetTrigger("Destroy");
                GameAnimator.value.SetBool("HasGame", false);*/

                calc = false;
                EndAction(true);
            }
        }
    
}

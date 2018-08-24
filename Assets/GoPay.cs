using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class GoPay : ActionTask {

    public BBParameter<GameObject> Nerd;
    public BBParameter<GameObject> Pay;
    public BBParameter<NavMeshAgent> navMesh;
    public BBParameter<SteeringArrive> steer;
    public BBParameter<Animator> m_animator;
    public BBParameter<float> Cost;
    public BBParameter<Money> Money;
    public BBParameter<string> color;
    public BBParameter<AudioManager> Audio;
    


    private float paytime = 4.0f;
    protected override void OnExecute()
    {
        NavMeshPath goPayPath = new NavMeshPath();
        navMesh.value.CalculatePath(Pay.value.transform.position, goPayPath);
        Vector3[] pathCorners = new Vector3[goPayPath.corners.Length];
        goPayPath.corners.CopyTo(pathCorners, 0);
        steer.value.SetPathCorners(pathCorners);
    }

    protected override void OnUpdate()
    {
        float distance2 = (Pay.value.transform.position - Nerd.value.transform.position).magnitude;
        if (distance2 <= 1.0f)
        {
            Audio.value.Play("buy");
            m_animator.value.SetBool("movement", false);
           
                if (color.value == "red")
                {
                    Money.value.AddMoney(Money.value.Cost_Canada);
                    EndAction(true);
                }
                else if (color.value == "green")
                {
                    Money.value.AddMoney(Money.value.Cost_Donuts);
                    EndAction(true);
                }
                else if (color.value == "blue")
                {
                    Money.value.AddMoney(Money.value.Cost_Militar);
                    EndAction(true);
                }
                else if (color.value == "yellow")
                {
                    Money.value.AddMoney(Money.value.Cost_Zombie);
                    EndAction(true);
                }
               
            
            
        }

    }
}

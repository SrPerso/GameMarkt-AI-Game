using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class Detected : ActionTask
{
    public BBParameter<GameObject> Robber;
    public BBParameter<GameObject> Object;
    public BBParameter<bool> Following;
    public BBParameter<bool> Followed;
    public BBParameter<bool> Chasing;
    public BBParameter<float> DayRotation;

    private float prevdist;

    protected override void OnExecute()
    {

        prevdist = 1000;
    }


    protected override void OnUpdate()
    {
        if (Following.value == true)
        {
            float distance = (Robber.value.transform.position - Object.value.transform.position).magnitude;
            if (distance < prevdist)
            {
                prevdist = distance;
                if (distance <= 2.0f)
                {
                    Robber.value = null;
                    Followed.value = false;
                    Following.value = false;
                    Chasing.value = false;
                    EndAction();
                }

                else
                {

                    Followed.value = true;
                    EndAction();
                }
            }

        }
        else
        {
            EndAction();
        }
    }
}

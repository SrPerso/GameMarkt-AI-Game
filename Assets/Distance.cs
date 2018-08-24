using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class Distance : ActionTask {

    public BBParameter<GameObject> Cleaner;
    public BBParameter<GameObject> Closest;
    public BBParameter<bool> Check;
    public BBParameter<Animator> m_anim;
    public BBParameter<List<GameObject>> RubbishList;
    private float prevdist = 1000.0f;
    private float cleanTime = 5.0f;
    // Use this for initialization
    protected override void OnExecute()
    {
        base.OnExecute();
    }



    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (Closest.value != null)
        {
            float distance = (Closest.value.transform.position - Cleaner.value.transform.position).magnitude;
            if (distance < prevdist)
            {
                prevdist = distance;
                if (distance <= 1.5f)
                {
                    m_anim.value.SetBool("Clean", true);
                    cleanTime -= Time.deltaTime;
                    if (cleanTime <= 0.1f)
                    {
                        Closest.value = null;
                        Check.value = false;
                        RubbishList = null;
                        EndAction();
                    }
                    
                }

                else
                {
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

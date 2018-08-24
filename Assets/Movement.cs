using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : SteeringAbstract
{
    Move move;
    private NavMeshAgent agent;
    private Animator m_animator;
    private List<GameObject> CleanerList = new List<GameObject>();
    private float distance = 2000;
    public GameObject thisOne = null;

    private Animator RAnimator;
    public GameObject rubishGo = null;

    public Vector3 cleanerhome = new Vector3(19.71f, 0.25f, 10.96f);
    private float cleanTimer = 5.0f;
    private SteeringArrive seek;
	private bool goingHome = false;
    public bool avoidance;
  
    // Use this for initialization  

    // Update is called once per frame
   
   
    void Start()
    {

        RAnimator = rubishGo.GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        seek=GetComponent<SteeringArrive>();
  
        //avoidance = false;

    }
    // Update is called once per frame
    void Update()
	{
		
		object[] obj = GameObject.FindSceneObjectsOfType (typeof(GameObject));
		foreach (object o in obj) {
			GameObject g = (GameObject)o;
			if (g.tag == "Rubish") {
				if (CleanerList.Contains (g) == false) {
					CleanerList.Add (g);
				}
			}

		}

		if (CleanerList.Count != 0) {
			goingHome = false;
			if (thisOne == null) {
				for (int i = 0; i < CleanerList.Count; i++) {
					float otherdist = (CleanerList [i].transform.position - transform.position).magnitude;
					if (otherdist <= distance) {
						distance = otherdist;
						thisOne = CleanerList [i];
						NavMeshPath rubbishPath = new NavMeshPath ();
						agent.CalculatePath (thisOne.transform.position, rubbishPath);
						Vector3[] pathCorners = new Vector3[rubbishPath.corners.Length];
						rubbishPath.corners.CopyTo (pathCorners, 0);
						seek.SetPathCorners (pathCorners);
					}
				}
			} else {
				float distance2 = (thisOne.transform.position - transform.position).magnitude;

				if (distance2 > 1.5f) {
					
					m_animator.SetBool ("movement", true);
                    RAnimator.SetTrigger("Destroy");
                    m_animator.SetBool ("clean", false);
					
				} else {                
					m_animator.SetBool ("movement", false);
					m_animator.SetBool ("clean", true);
                    RAnimator.SetTrigger("Create");

                    cleanTimer -= Time.deltaTime;
					if (cleanTimer <= 0.1f) {
						CleanerList.Remove (thisOne);
						Destroy (thisOne);
						thisOne = null;
						distance = 2000;
						cleanTimer = 5.0f;
					}               
				}
			}
		}
        else
        {
			if (goingHome == false) {
				NavMeshPath rubbishPath = new NavMeshPath ();
				agent.CalculatePath (cleanerhome, rubbishPath);
				Vector3[] pathCorners = new Vector3[rubbishPath.corners.Length];
				rubbishPath.corners.CopyTo (pathCorners, 0);
				seek.SetPathCorners (pathCorners);
				goingHome = true;
			}

            m_animator.SetBool("clean", false);
            RAnimator.SetTrigger("Destroy");

            float distance3 = (cleanerhome - transform.position).magnitude;
            if (distance3 > 1.5f)
            {
                
                m_animator.SetBool("movement", true);
            
            }
            else
            {
				
                m_animator.SetBool("movement", false);
                distance = 2000;
            }
        }
    }


}


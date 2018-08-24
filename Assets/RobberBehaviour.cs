using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{

    Move move;
    SteeringArrive seek;
    private Animator robber;
    private NavMeshAgent m_robber;
    public GameObject robberGame = null;
    private Animator animatorGame;
    private List<GameObject> StealList = new List<GameObject>();

    private bool steal = false;
    private float distance;
    private int randNumb;
    private int randStealNumb;
    float StealTimer = 3.0f;
    private bool stealed = false;
    private GameObject home = null;

    bool goingHome = false;
    // Use this for initialization
    void Start()
    {
        //animatorGame = robberGame.GetComponent<Animator>();
        move = GetComponent<Move>();
        seek = GetComponent<SteeringArrive>();
        robber = GetComponent<Animator>();
        m_robber = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (StealList != null)
        {
            object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;

                if (g.tag == "red" || g.tag == "green" || g.tag == "blue")
                {
                    if (StealList.Contains(g) == false)
                    {
                        StealList.Add(g);
                    }
                }
                else if (g.tag == "Leave")
                {
                    home = g;
                }

            }
        }

        if (StealList != null)
        {
            if (steal == false)
            {
                steal = true;
                randNumb = Random.Range(0, StealList.Count - 1);

                distance = (StealList[randNumb].transform.position - transform.position).magnitude;
                NavMeshPath nerdPath = new NavMeshPath();
                m_robber.CalculatePath(StealList[randNumb].transform.position, nerdPath);
                Vector3[] pathCorners = new Vector3[nerdPath.corners.Length];
                nerdPath.corners.CopyTo(pathCorners, 0);
                seek.SetPathCorners(pathCorners);
            }
            else
            {
                float distance2 = (StealList[randNumb].transform.position - transform.position).magnitude;
                if (distance2 <= 1.5f)
                {


                    robber.SetBool("Arrive", true);
                    //robberGame.SetBool("Robbed", true);

                    StealTimer -= Time.deltaTime;
                    if (StealTimer <= 0.1f)
                    {

                        randStealNumb = Random.Range(0, 2);
                        if (randStealNumb == 1)//steal
                        {
                            robber.SetBool("Steal", true);
                            robber.tag = "Robber";
                            stealed = true;
                        }
                        else
                        {                            
                            stealed = false;
                        }
                        robber.SetBool("Arrive", false);
                        StealList.Clear();
                        StealList = null;

                        StealTimer = 5.0f;

                    }
                }


            }

        }
        else
        {
            if (stealed == true)
            {
                move.max_mov_velocity = 3;
            }
            if (goingHome == false)
            {
                goingHome = true;               

                distance = (home.transform.position - transform.position).magnitude;
                NavMeshPath nerdPath = new NavMeshPath();
                m_robber.CalculatePath(home.transform.position, nerdPath);
                Vector3[] pathCorners = new Vector3[nerdPath.corners.Length];
                nerdPath.corners.CopyTo(pathCorners, 0);
                seek.SetPathCorners(pathCorners);
            }
            else
            {
                float distance2 = (home.transform.position - transform.position).magnitude;
                if (distance2 <= 1.5f)
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}

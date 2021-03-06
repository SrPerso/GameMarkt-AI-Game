﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusinessBehaviour : MonoBehaviour
{

    Move move;
    SteeringArrive seek;
    private NavMeshAgent m_agent;
    private Animator animator;
    public float max_angle = 0.5f;
    private float distance;
    private Vector3 velocity = Vector3.zero;
    private List<GameObject> PlayList = new List<GameObject>();
    public float BuyTimer = 10.0f;
    //private Vector3 casher;
    public GameObject pay = null;
    public GameObject Game = null;

    private Animator animatorGame;
    bool bought = false;
    bool goingPay = true;
    //bool prepareToPay = false;
    int randNumb;
    // Use this for initialization
    void Start()
    {
        animatorGame = Game.GetComponent<Animator>();
        move = GetComponent<Move>();
        m_agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        seek = GetComponent<SteeringArrive>();
        //casher = new Vector3(-23.22f, 21.41f, 42.22f);
        animator.SetBool("Buy", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayList != null)
        {
            object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;

                if (g.tag == "stand")
                {
                    if (PlayList.Contains(g) == false)
                    {
                        PlayList.Add(g);
                    }
                }
                float randPay = Random.Range(0, 1);
                if (randPay == 0)
                {
                    if (g.tag == "Pay")
                    {
                        pay = g;
                    }
                }
                else
                {
                    if (g.tag == "Pay2")
                    {
                        pay = g;
                    }

                }
            }
        }


        if (PlayList != null)
        {
            goingPay = true;
            if (bought == false)
            {
                bought = true;
                randNumb = Random.Range(0, PlayList.Count - 1);

                distance = (PlayList[randNumb].transform.position - transform.position).magnitude;
                NavMeshPath nerdPath = new NavMeshPath();
                m_agent.CalculatePath(PlayList[randNumb].transform.position, nerdPath);
                Vector3[] pathCorners = new Vector3[nerdPath.corners.Length];
                nerdPath.corners.CopyTo(pathCorners, 0);
                seek.SetPathCorners(pathCorners);

            }
            else
            {
                float distance2 = (PlayList[randNumb].transform.position - transform.position).magnitude;
                if (distance2 <= 2.0f)
                {
                    animator.SetBool("Buy", true);
                    animatorGame.SetTrigger("Create");
                    animatorGame.SetBool("HasGame", true);
                    BuyTimer -= Time.deltaTime;
                    if (BuyTimer <= 0.1f)
                    {
                        PlayList.Clear();
                        PlayList = null;
                        BuyTimer = 10.0f;

                    }
                }
            }
        }
        else
        {
            if (goingPay == true)
            {

                goingPay = false;

                distance = (pay.transform.position - transform.position).magnitude;
                NavMeshPath goHome = new NavMeshPath();
                m_agent.CalculatePath(pay.transform.position, goHome);
                Vector3[] goHomePath = new Vector3[goHome.corners.Length];
                goHome.corners.CopyTo(goHomePath, 0);
                seek.SetPathCorners(goHomePath);

            }
            else
            {
                float distance3 = (pay.transform.position - transform.position).magnitude;
                if (distance3 > 1.5f)
                {
                    animator.SetBool("Buy", false);
                    animatorGame.SetTrigger("Destroy");
                    animatorGame.SetBool("HasGame", false);
                }
                else
                {

                    animator.SetBool("Buy", true);
                    BuyTimer -= Time.deltaTime;
                    if (BuyTimer <= 0.1f)
                    {
                        Destroy(this.gameObject);
                        BuyTimer = 5.0f;
                    }


                }
            }
        }

    }

}

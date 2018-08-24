using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject[] consumers;
    public Vector3 SpawnPos;
    public float SpawnDelay;

    public int segsPlaying;

    public float MaxDelay;
    public float MinDelaY;

    public float MaxDelayDay1=0;
    public float MinDelaYDay1 = 0;

    public float MaxDelayDay2 = 0;
    public float MinDelaYDay2 = 0;

    public float MaxDelayDay3 = 0;
    public float MinDelaYDay3 = 0;

    public float ProbCanada = 0.225f;
    public float ProbZombie = 0.225f;
    public float ProbDonuts = 0.225f;
    public float ProbMilitar = 0.225f;
    public float Probthief = 0.1f;

    public bool stop;
    public int StartTToW8;
    public Light sun;

    public Money moneyManager;

    bool iniciated = true;
    int randCostumer;
    float startTime = 10.0f;


    private void DalayByDay()
    {
        if(moneyManager.Day <0 && MaxDelayDay1!=0)
        {
            MaxDelay = MaxDelayDay1;
            MinDelaY = MinDelaYDay1;




        }
      else  if (moneyManager.Day == 1 && MaxDelayDay2 != 0)
        {
            MaxDelay = MaxDelayDay2;
            MinDelaY = MinDelaYDay2;
        }
      else  if (moneyManager.Day > 1 && MaxDelayDay3 != 0)
        {
            MaxDelay = MaxDelayDay3;
            MinDelaY = MinDelaYDay3;
        }
    }



	void Start ()
    {        
       StartCoroutine(Wspawner());        
    }

    void Update()
    {
       
            SpawnDelay = Random.Range(MinDelaY, MaxDelay);

            if (sun.tag == "Night")
            {
                StopCoroutine(Wspawner());
            }
            else if (sun.tag == "Day" && iniciated == false)
            {
               DalayByDay();    
              iniciated = true;
                stop = false;
                StartCoroutine(Wspawner());
            }        
    }



    IEnumerator Wspawner()
    {

        if(sun.tag =="Day")
        {
            stop = false;

            yield return new WaitForSeconds(StartTToW8);

            while(!stop)
            {
                //Rand Consumers


                float rand = Random.value;
          

                if(rand <= ProbCanada)
                {
                    randCostumer = 0;

                }
                else if(rand > ProbCanada && rand <= ProbZombie+ ProbCanada)
                {
                    randCostumer = 1;
                }
                else if (rand > ProbZombie + ProbCanada && rand <= ProbZombie + ProbCanada+ ProbDonuts)
                {
                    randCostumer = 2;
                }
                else if (rand > ProbZombie + ProbCanada + ProbDonuts && rand <= ProbZombie + ProbCanada + ProbDonuts + ProbMilitar)
                {
                    randCostumer = 3;
                }        
                else
                {
                    randCostumer = 4;
                }

                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnPos.x, SpawnPos.x), 1, Random.Range(-SpawnPos.z, SpawnPos.z));
                
                    Instantiate(consumers[randCostumer], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

                    yield return new WaitForSeconds(SpawnDelay);

                if (sun.tag == "Night")
                {
                    stop = true;
                    iniciated = false;
                }                
                else
                {
                    stop = false;
                    iniciated = true;
                }
            }
        }
        else
        {
            stop = true;
        }
    }
}

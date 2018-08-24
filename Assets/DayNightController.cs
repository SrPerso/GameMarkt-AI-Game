using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {

    public Light sun;

    public UISets main;
    public float secondsInFullDay = 120f;
    public GameObject finish;

    public eventManager events;

    [Range(0,1)]
    public float currentTimeOfDay = 0;

    [HideInInspector]
    public float timeMultiplier = 1f;

    [Space]
    private bool Acelerated = false;
    public bool Acelerate = false;
    public bool Paused = true;
    public int Day;
    [Space]
    [Space]

    [Range(0, 1)]
    public float timeToStartsNight = 0.60f;
    [Range(0, 1)]
    public float timeToNextNight = 0.70f;
    [Range(0, 1)]
    public float timeToStartsDay = 0.15f;
    [Space]
    [Space]

    public Money MoneyManager;
    [Range(0, 1)]
    public float timeToSubstractExpenses = 0.75f;
    [Range(0, 1)]
    public float timeToCloseExpenses = 0.85f;
    [Space]
    [Space]

    float sunInitialIntensity;

    public void SetActive(bool act)
    {
        this.enabled = act;
    }

    public bool isActive()
    {
        return this.enabled;
    }

    void Start()
    {
        SetStopedTime();
        sunInitialIntensity = sun.intensity;
    }

    void Update() {

        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (!Paused)
        {

            if (currentTimeOfDay >= 1)
            {
                currentTimeOfDay = 0;
            }

            if (Acelerate == true && Acelerated == false)
            {
                Time.timeScale = 5.0f;
                Acelerated = true;
            }
            else if (Acelerate == false && Acelerated == true)
            {
                Time.timeScale = 1.0f;
                Acelerated = false;
            }
        }

     
    }

    public void SetNormalTime()
    {
        Time.timeScale = 1.0f;
        Paused = false;
    }
    public void SetStopedTime()
    {
      
        Time.timeScale = 0.0f;
        Paused = true;
    }

    void UpdateSun() {

        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfDay <= 0.12 || currentTimeOfDay >= 0.87f)
        {

            intensityMultiplier = 0;
            tag = "Night";
        }

        else if (currentTimeOfDay <= timeToStartsDay)
        {

            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.15f) * (1 / 0.02f));
            tag = "Day";
        }
  
        else if (currentTimeOfDay >= 0.9f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.9f) * (1 / 0.02f)));
            tag = "Night";
        }

        if (currentTimeOfDay >= timeToStartsNight)
        {
         
    
            tag = "Night";
        }

        if (currentTimeOfDay >= timeToNextNight)
        {
            tag = "Night";
          
        }

        if(currentTimeOfDay >= timeToSubstractExpenses && currentTimeOfDay <= timeToCloseExpenses)
        {
            events.SetNewEvent();
            SetStopedTime();

            MoneyManager.SetExpenses();    
            if(MoneyManager.GetMoney()<0)
            {
                main.EnableDisableGo(finish);
                SetStopedTime();
            }
        }
        if (currentTimeOfDay >= timeToCloseExpenses)
        {
            MoneyManager.CloseExpenses(); 
        }


        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
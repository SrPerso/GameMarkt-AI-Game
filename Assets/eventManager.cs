using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventManager : MonoBehaviour
{
    public Money moneyMan;
    public GameObject UI; 
    public UISets main;
    public spawner spawn;

    [Space]
    public float Max_Stand_popu;
    public float Min_Stand_popu;

    public float Max_Stand_noPop;
    public float Min_Stand_noPop;

    [Space]
    public float Max_billboard_popu;
    public float Min_billboard_popu;

    public float Max_billboard_noPop;
    public float Min_billboard_noPop;

    [Space]
    public float Max_shelf_popu;
    public float Min_shelf_popu;

    public float Max_shelf_noPop;
    public float Min_shelf_noPop;

    [Space]
    public Text uiText;

    [Space]
    public int PopularGame = 2; // 1.Canada 2.Zombie 3.Militar 4.Donuts

    public void SetNewEvent()
    {
        main.EnableDisableGo(UI);

        PopularGame = Random.Range(1, 5);

        switch (PopularGame)
        {
            case 1:
                SetCanada();
                uiText.text = "Canada";
                break;
            case 3:
                SetZombie();
                uiText.text = "Zombie";
                break;
            case 4:
                SetMilitar();
                uiText.text = "Militar vs Cooker";
                break;
            case 5:
                SetDonuts();
                uiText.text = "Donuts!";
                break;

        }
       moneyMan.SetNewPrices();

    }

    private void SetCanada()
    {
        PopuCanada();
        UnPopuZombie();
        UnPopuDonuts();
        UnPopuMilitar();

        spawn.ProbCanada = 0.395f;
        spawn.ProbDonuts = 0.15f;
        spawn.ProbMilitar = 0.18f;
        spawn.ProbZombie = 0.175f;

    }
    private void SetZombie()
    {
        PopuZombie();
        UnPopuCanada();
        UnPopuDonuts();
        UnPopuMilitar();

        spawn.ProbCanada = 0.175f;
        spawn.ProbDonuts = 0.18f;
        spawn.ProbMilitar = 0.15f;
        spawn.ProbZombie = 0.395f;
    }
    private void SetMilitar()
    {
        PopuMilitar();
        UnPopuCanada();
        UnPopuZombie();
        UnPopuDonuts();

        spawn.ProbCanada = 0.18f;
        spawn.ProbDonuts = 0.175f;
        spawn.ProbMilitar = 0.395f;
        spawn.ProbZombie = 0.15f;
    }
    private void SetDonuts()
    {
        PopuDonuts();

        UnPopuCanada();
        UnPopuZombie();
        UnPopuMilitar();

        spawn.ProbCanada = 0.15f;
        spawn.ProbDonuts = 0.395f;
        spawn.ProbMilitar = 0.18f;
        spawn.ProbZombie = 0.175f;
    }

    //--------------------------------------------------------------------
    private void PopuCanada()
    {
        moneyMan.CostCanada_Billboard = Random.Range(Min_billboard_popu, Max_billboard_popu);
        moneyMan.CostCanada_shelf = Random.Range(Min_shelf_popu, Max_shelf_popu);
        moneyMan.CostCanada_Stand = Random.Range(Min_Stand_popu, Max_Stand_popu);
    }

    private void UnPopuCanada()
    {
        moneyMan.CostCanada_Billboard = Random.Range(Min_billboard_noPop, Max_billboard_noPop);
        moneyMan.CostCanada_shelf = Random.Range(Min_shelf_noPop, Max_shelf_noPop);
        moneyMan.CostCanada_Stand = Random.Range(Min_Stand_noPop, Max_Stand_noPop);
    }
    //--------------------------------------------------------------------

    private void PopuZombie()
    {
        moneyMan.CostZombie_Billboard = Random.Range(Min_billboard_popu, Max_billboard_popu);
        moneyMan.CostZombie_shelf = Random.Range(Min_shelf_popu, Max_shelf_popu);
        moneyMan.CostZombie_Stand = Random.Range(Min_Stand_popu, Max_Stand_popu);
    }
    private void UnPopuZombie()
    {
        moneyMan.CostZombie_Billboard = Random.Range(Min_billboard_noPop, Max_billboard_noPop);
        moneyMan.CostZombie_shelf = Random.Range(Min_shelf_noPop, Max_shelf_noPop);
        moneyMan.CostZombie_Stand = Random.Range(Min_Stand_noPop, Max_Stand_noPop);
    }
    //--------------------------------------------------------------------
    private void PopuDonuts()
    {
        moneyMan.CostDonuts_Billboard = Random.Range(Min_billboard_popu, Max_billboard_popu);
        moneyMan.CostDonuts_shelf = Random.Range(Min_shelf_popu, Max_shelf_popu);
        moneyMan.CostDonuts_Stand = Random.Range(Min_Stand_popu, Max_Stand_popu);
    }
    private void UnPopuDonuts()
    {
        moneyMan.CostDonuts_Billboard = Random.Range(Min_billboard_noPop, Max_billboard_noPop);
        moneyMan.CostDonuts_shelf = Random.Range(Min_shelf_noPop, Max_shelf_noPop);
        moneyMan.CostDonuts_Stand = Random.Range(Min_Stand_noPop, Max_Stand_noPop);
    }
    //--------------------------------------------------------------------
    private void PopuMilitar()
    {
        moneyMan.CostMilitar_Billboard = Random.Range(Min_billboard_popu, Max_billboard_popu);
        moneyMan.CostMilitar_shelf = Random.Range(Min_shelf_popu, Max_shelf_popu);
        moneyMan.CostMilitar_Stand = Random.Range(Min_Stand_popu, Max_Stand_popu);
    }
    private void UnPopuMilitar()
    {
        moneyMan.CostMilitar_Billboard = Random.Range(Min_billboard_noPop, Max_billboard_noPop);
        moneyMan.CostMilitar_shelf = Random.Range(Min_shelf_noPop, Max_shelf_noPop);
        moneyMan.CostMilitar_Stand = Random.Range(Min_Stand_noPop, Max_Stand_noPop);
    }

}

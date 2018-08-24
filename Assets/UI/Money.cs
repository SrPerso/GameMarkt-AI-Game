using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public static float money;
    public float StartMoney;
    [Space]
    public float Cost_Zombie;
    public float Cost_Canada;
    public float Cost_Militar;
    public float Cost_Donuts;

    [Space]
    public float Salary_Cashier;
    public float Salary_Cleaner;
    public float Salary_Guard;
    public float Light_Cost;

    [Space]
    public int nCashiers;
    public int nCleaners;
    public int nGuards;

    [Space]
    public Text MoneyCounter;

    [Space]
    public Text CostZombie;
    public Text CostCanada;
    public Text CostMilitar;
    public Text CostDonuts;


    [Space]
    public Text CostZombie_shelves;
    public Text CostCanada_shelves;
    public Text CostMilitar_shelves;
    public Text CostDonuts_shelves;

    [Space]
    public Text Expenses_light;
    public Text Expenses_Cashiers;
    public Text Expenses_Cleaners;
    public Text Expenses_Guards;
    
    [Space]
    public float CostZombie_Billboard;
    public float CostCanada_Billboard;
    public float CostMilitar_Billboard;
    public float CostDonuts_Billboard;

    public float Min_Cost_Billboard;
    [Space]

    public float CostZombie_shelf;
    public float CostCanada_shelf;
    public float CostMilitar_shelf;
    public float CostDonuts_shelf;
    [Space]
    public float Min_Cost_Shelf;
    [Space]
    public float CostZombie_Stand;
    public float CostCanada_Stand;
    public float CostMilitar_Stand;
    public float CostDonuts_Stand;

    public float Min_Cost_Stand;
    [Space]

    public Text text_CostZombie_Billboard;
    public Text text_CostCanada_Billboard;
    public Text text_CostMilitar_Billboard;
    public Text text_CostDonuts_Billboard;

    [Space]
    public Text text_CostZombie_Stand;
    public Text text_CostCanada_Stand;
    public Text text_CostMilitar_Stand;
    public Text text_CostDonuts_Stand;


    [Space]

    public Slider slider_Militar;
    public Slider slider_Donuts;
    public Slider slider_Canada;
    public Slider slider_Zombie;

    [Space]
    public GameObject ExpensesGO;
    public UISets maincameraUISets;

    public eventManager events;

    private bool ExpensesSubstract = false;
    public int Day = 0;
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------

    private void Start()
    {
       money = StartMoney;
        SetNewPrices();
       

    }
    //--------------------------------------------------------------------

    public void SetNewPrices()
    {
        MoneyCounter.text = money + "€";
        CostZombie.text = Cost_Zombie + "€";
        CostCanada.text = Cost_Canada + "€";
        CostDonuts.text = Cost_Donuts + "€";
        CostMilitar.text = Cost_Militar + "€";
        slider_Canada.value = Cost_Canada;
        slider_Zombie.value = Cost_Zombie;
        slider_Donuts.value = Cost_Donuts;
        slider_Militar.value = Cost_Militar;

        float minCost = 0.0f;

        CostZombie_shelves.text = CostZombie_shelf + "€";
        minCost = CostZombie_shelf;

        CostCanada_shelves.text = CostCanada_shelf + "€";
        if (CostCanada_shelf < minCost) minCost = CostCanada_shelf;

        CostMilitar_shelves.text = CostMilitar_shelf + "€";
        if (CostMilitar_shelf < minCost) minCost = CostMilitar_shelf;

        CostDonuts_shelves.text = CostDonuts_shelf + "€";
        if (CostDonuts_shelf < minCost) minCost = CostDonuts_shelf;
        Min_Cost_Shelf = minCost;

        minCost = 0.0f;  
        text_CostZombie_Billboard.text = CostZombie_Billboard + "€";
        minCost = CostZombie_Billboard;

        text_CostCanada_Billboard.text = CostCanada_Billboard + "€";
        if (CostCanada_Billboard < minCost) minCost = CostCanada_Billboard;

        text_CostMilitar_Billboard.text = CostMilitar_Billboard + "€";
        if (CostMilitar_Billboard < minCost) minCost = CostMilitar_Billboard;

        text_CostDonuts_Billboard.text = CostDonuts_Billboard + "€";
        if (CostDonuts_Billboard < minCost) minCost = CostDonuts_Billboard;
        Min_Cost_Billboard = minCost;


        minCost = 0.0f;
        text_CostZombie_Stand.text = CostZombie_Stand + "€";
        minCost = CostZombie_Stand;

        text_CostCanada_Stand.text = CostCanada_Stand + "€";
        if (CostCanada_Stand < minCost) minCost = CostCanada_Stand;

        text_CostMilitar_Stand.text = CostMilitar_Stand + "€";
        if (CostMilitar_Stand < minCost) minCost = CostMilitar_Stand;

        text_CostDonuts_Stand.text = CostDonuts_Stand + "€";
        if (CostDonuts_Stand < minCost) minCost = CostDonuts_Stand;

        Min_Cost_Stand = minCost;
    }

    //--------------------------------------------------------------------

    public float GetMoney()
    {
        return money;
    }
    //set the money to the couner
    public void SetMoneyToCounter()
    {
        MoneyCounter.text = money + "€";
    }
    //Adds money to te counter
    public void AddMoney(float mon)
    {
        money += mon;
        SetMoneyToCounter();
    }
    //Substrackt money to te counter
    public void SubtractMoney(float mon)
    {
        money -= mon;
        SetMoneyToCounter();
    }
    //Substract billboards && stands money

    //-- Zombie
    public void SubstractZombieBill()
    {
        SubtractMoney(CostZombie_Billboard);
    }
    public void SubstractZombieStand()
    {
        SubtractMoney(CostZombie_Stand);
    }
    public void SubstractZombieShelf()
    {
        SubtractMoney(CostZombie_shelf);
    }
    //--  Militar
    public void SubstractMilitarBill()
    {
        SubtractMoney(CostMilitar_Billboard);
    }
    public void SubstractMilitarStand()
    {
        SubtractMoney(CostMilitar_Stand);
    }
    public void SubstractMilitarShelf()
    {
        SubtractMoney(CostMilitar_shelf);
    }
    //--  Donuts
    public void SubstractDonutsBill()
    {
        SubtractMoney(CostDonuts_Billboard);
    }
    public void SubstractDonutsStand()
    {
        SubtractMoney(CostDonuts_Stand);
    }
    public void SubstractDonutsShelf()
    {
        SubtractMoney(CostDonuts_shelf);
    }
    //--  Canada
    public void SubstractCanadaBill()
    {
        SubtractMoney(CostCanada_Billboard);
    }
    public void SubstractCanadaStand()
    {
        SubtractMoney(CostCanada_Stand);
    }
    public void SubstractCanadaShelf()
    {
        SubtractMoney(CostCanada_shelf);
    }

    //---

    public void SubstractShelfs()
    {
        SubtractMoney(Min_Cost_Shelf);
    }


    //Set the costs 
    public void SetCostZombie(Slider valors)
    {
        Cost_Zombie = valors.value;
        CostZombie.text = valors.value + "€";
    }
    public void SetCostCanada(Slider valors)
    {
        Cost_Canada = valors.value;
        CostCanada.text = valors.value + "€";
    }
    public void SetCostDonuts(Slider valors)
    {
        Cost_Donuts = valors.value;
        CostDonuts.text = valors.value + "€";
    }
    public void SetCostMilitar(Slider valors)
    {
        Cost_Militar = valors.value;
        CostMilitar.text = valors.value + "€";
    }
    public void SetExpenses()
    {
        if(ExpensesSubstract == false)
        {
            Day++;
            maincameraUISets.EnableDisableGo(ExpensesGO);

            Expenses_Cashiers.text = (Salary_Cashier * nCashiers) + "€";
            Expenses_Cleaners.text = (Salary_Cleaner * nCleaners) + "€";
            Expenses_Guards.text = (Salary_Guard * nGuards) + "€";
            Expenses_light.text = Light_Cost + "€";

            SubtractMoney(Salary_Cashier * nCashiers);
            SubtractMoney(Salary_Cleaner * nCleaners);
            SubtractMoney(Salary_Guard * nGuards);
            SubtractMoney(Light_Cost);
            ExpensesSubstract = true;
        }

    }
    public void CloseExpenses()
    {
        if (ExpensesSubstract == true)
        {
            maincameraUISets.EnableDisableGo(ExpensesGO);
            ExpensesSubstract = false;
        }
    }




}

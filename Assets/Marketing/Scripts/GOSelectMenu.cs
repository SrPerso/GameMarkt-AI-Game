using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOSelectMenu : MonoBehaviour
{
    public GameObject gameObjectGameStands;
	public GameObject gameObjectBillboard;
	public GameObject gameObjectShelfs;

    public GameObject gameObjectError;

    public UISets GOScriptEnDis; // main camera has the script function calls -> Enable/Disable 
    public Money MoneyManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //press mouse
        {
            if (GOScriptEnDis.uiActive == false)
            {
                bool hasHit = false;

                RaycastHit hit = new RaycastHit();
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(raycast, out hit)) //compares the ray
                {
                    if (hit.transform.gameObject.tag == "GameStand")//
                    {             
                        hasHit = true;
                        GOScriptEnDis.uiActive = true;

                        if (MoneyManager.GetMoney() > MoneyManager.Min_Cost_Stand)
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectGameStands);
                        }
                        else
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectError);
                        }

                    }
				    else if (hit.transform.gameObject.tag == "Billboard")
					{        
						hasHit = true;
						GOScriptEnDis.uiActive = true;

                        if (MoneyManager.GetMoney() > MoneyManager.Min_Cost_Billboard)
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectBillboard);
                        }
                        else
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectError);

                        }
               
					}
					else if (hit.transform.gameObject.tag == "Shelf")
					{        

                		hasHit = true;
						GOScriptEnDis.uiActive = true;

                        if(MoneyManager.GetMoney() > MoneyManager.Min_Cost_Shelf)
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectShelfs);
                        }
                        else
                        {
                            GOScriptEnDis.EnableDisableGo(gameObjectError);

                        }
				
					}
                }
                // assign the last GO

                if (hasHit)
                {
                    GOScriptEnDis.GoSelected = hit.transform.gameObject;
                    // Debug.Log( GOScriptEnDis.GoSelected.transform.position.x );
                }
                else
                {
                    GOScriptEnDis.GoSelected = null;
                }
            }
        }
    }
}
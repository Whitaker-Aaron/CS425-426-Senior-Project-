using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenuTransition : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainButtons;
    GameObject mainSelection;
    GameObject weaponsScroll;
    void Start()
    {
        mainButtons = GameObject.Find("MainButtons");
        mainSelection = GameObject.Find("MainSelection");
        weaponsScroll = GameObject.Find("WeaponsScroll");
        weaponsScroll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NavigateToMaterialMenu()
    {
        Debug.Log("Back Button pressed");
        GameObject.Find("MenuManager").GetComponent<MenuManager>().navigateToMaterialMenu();
    }

    public void NavigateToWeaponCraftMenu()
    {
        Debug.Log("Weapon Button pressed");
        mainButtons.SetActive(false);
        mainSelection.SetActive(false);
        weaponsScroll.SetActive(true);
    }

    public void NavigateToRunesCraftMenu()
    {
        Debug.Log("Rune Button pressed");
        mainButtons.SetActive(false);
        mainSelection.SetActive(false);
    }

    public void NavigateToItemsCraftMenu()
    {
        Debug.Log("Items Button pressed");
        mainButtons.SetActive(false);
        mainSelection.SetActive(false);
    }




}

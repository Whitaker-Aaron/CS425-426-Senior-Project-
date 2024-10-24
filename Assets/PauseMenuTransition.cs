
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;


public class PauseMenuTransition : MonoBehaviour
{
    GameObject ReturnToBaseButton;
    GameObject SaveButton;

    [SerializeField] GameObject SkillMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject KnightSkillMenu;
    [SerializeField] GameObject GunnerSkillMenu;
    [SerializeField] GameObject EngineerSkillMenu;

    [SerializeField] WeaponClass knightRef;
    [SerializeField] WeaponClass gunnerRef;
    [SerializeField] WeaponClass engineerRef;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SkillMenu.SetActive(false);
        KnightSkillMenu.SetActive(false);
        EngineerSkillMenu.SetActive(false);
        GunnerSkillMenu.SetActive(false);

        ReturnToBaseButton = GameObject.Find("ReturnToBaseButton");
        SaveButton = GameObject.Find("SaveButton");

        

        if (GameObject.Find("RoomManager").GetComponent<RoomManager>().IsCheckpoint())
        {
            SaveButton.GetComponent<Button>().interactable = true;
            if (GameObject.Find("LifetimeManager").GetComponent<LifetimeManager>().currentScene != "BaseCamp")
            {
                ReturnToBaseButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                ReturnToBaseButton.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            SaveButton.GetComponent<Button>().interactable = false;
            ReturnToBaseButton.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        GameObject.Find("SaveManager").GetComponent<SaveManager>().SaveGame();
    }

    public void returnToMainSkills()
    {
        SkillMenu.SetActive(true);
        KnightSkillMenu.SetActive(false);
        EngineerSkillMenu.SetActive(false);
        GunnerSkillMenu.SetActive(false);
    }

    public void ReturnToBase()
    {
        //Time.timeScale = 1.0f;
        var reference = GameObject.Find("TransitionScreen").GetComponent<Image>();
        Color imgColor = reference.color;
        imgColor.a = 1;
        reference.color = imgColor;


        GameObject.Find("LifetimeManager").GetComponent<LifetimeManager>().ReturnToBase();



        //StartCoroutine(GameObject.Find("LifetimeManager").GetComponent<LifetimeManager>().ReturnToScene(1));

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSkills()
    {
        PauseMenu.SetActive(false);
        SkillMenu.SetActive(true);
    }

    public void OpenKnightSkills()
    {
        SkillMenu.SetActive(false);
        KnightSkillMenu.SetActive(true);
    }

    public void OpenGunnerSkills()
    {
        SkillMenu.SetActive(false);
        GunnerSkillMenu.SetActive(true);
    }

    public void OpenEngineerSkills()
    {
        SkillMenu.SetActive(false);
        EngineerSkillMenu.SetActive(true);
    }



}

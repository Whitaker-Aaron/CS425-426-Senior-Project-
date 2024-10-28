using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject CheckpointText;
    [SerializeField] GameObject levelUpText;
    [SerializeField] GameObject mainHUD;
    [SerializeField] GameObject knightHUD;
    [SerializeField] GameObject engineerHUD;
    [SerializeField] GameObject gunnerHUD;
    [SerializeField] Slider ExperienceBar;
    GameObject currentCheckpointText;
    CharacterBase character;
    // Start is called before the first frame update
    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
        knightHUD.SetActive(false);
        gunnerHUD.SetActive(false);
        engineerHUD.SetActive(false);
    }
    public void Initialize()
    {
        ExperienceBar.value = character.weaponClass.totalExp;
        UpdateClass(character.weaponClass.classType, character.weaponClass.currentLvl);
        //UpdateExperienceBar(character.weaponClass.getCurrentLvlExperienceAmount(), character.weaponClass.getNextLvlExperienceAmount(), character.weaponClass.totalExp);
    }
    
    public void UpdateClass(WeaponBase.weaponClassTypes weaponClass, int experienceLVL, bool changingClass = false)
    {
        switch (weaponClass)
        {
            case WeaponBase.weaponClassTypes.Knight:
                knightHUD.SetActive(true);
                gunnerHUD.SetActive(false);
                engineerHUD.SetActive(false);
                
                break;
            case WeaponBase.weaponClassTypes.Gunner:
                knightHUD.SetActive(false);
                gunnerHUD.SetActive(true);
                engineerHUD.SetActive(false);
                break;
            case WeaponBase.weaponClassTypes.Engineer:
                knightHUD.SetActive(false);
                gunnerHUD.SetActive(false);
                engineerHUD.SetActive(true);
                break;
        }
        UpdateExperienceLevel(weaponClass, experienceLVL, changingClass);
        
    }

    public void UpdateExperienceBar(float current)
    {
        
        StartCoroutine(AnimateExperienceBar(current));
        //ExperienceBar.value = current;
    }

    public IEnumerator AnimateExperienceBar(float current)
    {
        while (ExperienceBar.value < current)
        {
            ExperienceBar.value = Mathf.Lerp(ExperienceBar.value, current, 3.0f * Time.deltaTime);
            if (Mathf.Abs(ExperienceBar.value - current) < 0.5) ExperienceBar.value = current;
            if (Mathf.Abs(ExperienceBar.value - ExperienceBar.maxValue) < 0.5) yield break;
            yield return null;
        }
        Debug.Log("Bar finished in AnimateExperienceBar");
        yield break;
    }

    public void ChangeExperienceLvl(float min, float max)
    {
        ExperienceBar.minValue = min;
        ExperienceBar.maxValue = max;
    }

    public IEnumerator AnimateExperienceUpdate(WeaponBase.weaponClassTypes weaponClass, int experienceLVL, bool changingClass = false)
    {
        if (!changingClass)
        {
            yield return StartCoroutine(AnimateExperienceBar(character.weaponClass.getCurrentLvlExperienceAmount()));
            Debug.Log("Bar finished in AnimateExperienceUpdate");
        }
        

        switch (weaponClass)
        {
            case WeaponBase.weaponClassTypes.Knight:
                knightHUD.transform.Find("KnightLVLTextMain").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                knightHUD.transform.Find("KnightLVLTextSub").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                break;
            case WeaponBase.weaponClassTypes.Gunner:
                gunnerHUD.transform.Find("GunnerLVLTextMain").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                gunnerHUD.transform.Find("GunnerLVLTextSub").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                break;
            case WeaponBase.weaponClassTypes.Engineer:
                engineerHUD.transform.Find("EngineerLVLTextMain").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                engineerHUD.transform.Find("EngineerLVLTextSub").GetComponent<TMP_Text>().text = experienceLVL.ToString();
                break;
        }
        ChangeExperienceLvl(character.weaponClass.getCurrentLvlExperienceAmount(), character.weaponClass.getNextLvlExperienceAmount());
        if (!changingClass)
        {
            yield return StartCoroutine(AnimateExperienceBar(character.weaponClass.totalExp));
        }
        else
        {
            ExperienceBar.value = character.weaponClass.totalExp;
        }
        yield break;
        //
        
    }

    public void UpdateExperienceLevel(WeaponBase.weaponClassTypes weaponClass, int experienceLVL, bool changingClass = false)
    {
        StartCoroutine(AnimateExperienceUpdate(weaponClass, experienceLVL, changingClass));
       
    }

    public void StartLevelUpText()
    {
        StartCoroutine(AnimateLevelUpText());
    }

    public IEnumerator AnimateLevelUpText()
    {
        Vector3 ogPosition = levelUpText.transform.localPosition;
        levelUpText.transform.localPosition = new Vector3(levelUpText.transform.localPosition.x - 2000.0f, levelUpText.transform.localPosition.y, levelUpText.transform.localPosition.z);
        
        bool increasingOpacity = false;
        while (levelUpText.transform.localPosition.x < ogPosition.x)
        {
             if((levelUpText.transform.localPosition.x > ogPosition.x - 1000.0f) && !increasingOpacity)
            {
                StartCoroutine(IncreaseImageOpacity(levelUpText, 4.0f));
            }
             if(Mathf.Abs(levelUpText.transform.localPosition.x - ogPosition.x) < 0.3f){
                levelUpText.transform.localPosition = ogPosition;
             }
             else
             {
                levelUpText.transform.localPosition = Vector3.Lerp(levelUpText.transform.localPosition, ogPosition, 15.0f*Time.deltaTime);
             }
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(DecreaseImageOpacity(levelUpText, 1.0f));
        yield break;
    }

    public IEnumerator AnimateCheckpointReached()
    {
        Debug.Log("Animating Checkpoing text");
        currentCheckpointText = Instantiate(CheckpointText);
        currentCheckpointText.transform.SetParent(mainCanvas.transform, false);
        currentCheckpointText.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        var rate = new Vector3(20f, 20f, 20f);
        while(currentCheckpointText.transform.localScale.x != 1.0f)
        {
           Debug.Log(currentCheckpointText.transform.localScale);
            if((currentCheckpointText.transform.localScale.x - (rate.x * Time.deltaTime)) <= 1.0f)
            {
                currentCheckpointText.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                yield return null;
            }
            else
            {
                currentCheckpointText.transform.localScale -= (rate * Time.deltaTime);
                yield return null;
            }

        }
        //yield return new WaitForSeconds(2.8f);
        yield return StartCoroutine(ReduceTextOpacity(currentCheckpointText, 1.00f));
        Destroy(currentCheckpointText);
        yield break;
    }

    private IEnumerator DecreaseImageOpacity(GameObject image, float rate)
    {
        var reference = image.GetComponent<Image>();
        while (reference.color.a >= 0.0 && reference != null)
        {
            Color imgColor = reference.color;
            imgColor.a -= rate * Time.deltaTime;
            reference.color = imgColor;

            yield return null;
        }
        yield break;
    }

    private IEnumerator IncreaseImageOpacity(GameObject image, float rate)
    {
        var reference = image.GetComponent<Image>();
        while (reference.color.a < 1.0 && reference != null)
        {
            Color imgColor = reference.color;
            imgColor.a += rate * Time.deltaTime;
            reference.color = imgColor;

            yield return null;
        }
        yield break;
    }

    private IEnumerator ReduceTextOpacity(GameObject text, float rate)
    {
        var reference = text.GetComponent<TMP_Text>();
        while (reference.color.a >= 0.0 && reference != null)
        {
            Color imgColor = reference.color;
            imgColor.a -= rate * Time.deltaTime;
            reference.color = imgColor;

            yield return null;
        }
        yield break;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RuneInt
{

    //string runeName { get; }
    void Apply();
    void Remove();
    void ResetRunes();

    void ChangeClass(WeaponBase.weaponClassTypes newClass);
}

public class runeInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

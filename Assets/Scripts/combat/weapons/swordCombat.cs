using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCombat : MonoBehaviour
{
    public int damage = 50;
    bool isAttacking = false;


    //rune ability combat mechanic
    public bool isFire = false;
    public int fireDmg = 10;
    public float fireTime = 5f;
    public float fireDmgInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        //isFire = true;
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateAttack(Transform attackPoint, float radius, LayerMask layer)
    {
        print("activating sword attack");
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, radius, layer);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                if (isFire)
                {
                    collider.GetComponent<EnemyFrame>().StartCoroutine(collider.GetComponent<EnemyFrame>().dmgOverTime(fireDmg, fireTime, fireDmgInterval));
                }
                collider.GetComponent<EnemyFrame>().takeDamage(damage);
            }
        }
        //isAttacking = true;
        //yield return new WaitForSeconds(time);
        //print("Deactivating");
        //isAttacking = false;
        //yield break;
    }

    public void activateFire(bool activate)
    {
        isFire = activate;
    }


    
}

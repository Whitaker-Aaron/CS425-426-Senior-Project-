using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public GameObject rocketFireAura;

    public float explosionRadius = 3f;
    public int damage, directHitDamage;
    public int fireDmg;
    public float fireT, fireR, fireRadius, abilityTime;

    public bool fireB = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void explode()
    {
        //GameObject currentExplosion = Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
        //currentExplosion.GetComponent<ParticleSystem>().Play();

        if(fireB)
        {
            EffectsManager.instance.getFromPool("rocketFireCircle", gameObject.transform.position);
            GameObject tempAura = Instantiate(rocketFireAura, gameObject.transform.position, Quaternion.identity);
            tempAura.GetComponent<areaOfEffect>().startCheck(gameObject.transform.position, fireRadius, fireDmg, fireT, fireR, abilityTime);
        }
        else
        {
            EffectsManager.instance.getFromPool("rocketHit", gameObject.transform.position);
        }
        
        
        Collider[] hitEnemies = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
        foreach (Collider collider in hitEnemies)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                collider.gameObject.GetComponent<EnemyFrame>().takeDamage(damage, Vector3.zero, EnemyFrame.DamageSource.Player, EnemyFrame.DamageType.Explosion);
            }
        }
        //Destroy(currentExplosion, 2f);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, explosionRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyFrame>().takeDamage(directHitDamage, Vector3.zero, EnemyFrame.DamageSource.Player, EnemyFrame.DamageType.Projectile);
            explode();
        }
        else
            explode();
    }

    public void increaseBlastRadius(float amount)
    {
        explosionRadius += amount;
    }
}

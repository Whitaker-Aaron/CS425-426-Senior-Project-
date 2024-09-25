using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class playerAnimationController : MonoBehaviour, PlayerAnimation
{
    new Transform camera;
    private Animator animator;
    Vector3 moveInput, camForward, movement;
    float forwardAmount, turnAmount;
    GameObject player;
    


    //General movement functions---------------

    public void updatePlayerAnimation(Vector3 movementDirection)
    {
        Move(movementDirection);
    }

    private void Move(Vector3 moving)
    {
        if (moving.magnitude > 1)
        {
            moving.Normalize();
        }

        this.moveInput = moving;

        convertMoveInput();
        updateAnimator();
    }

    void convertMoveInput()
    {
        Vector3 localMove = player.transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.z;

        forwardAmount = localMove.x;
    }
    void updateAnimator()
    {
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }
    //-------------------------------------------------------

    //Knight Functions---------------------------------------

    public AnimatorStateInfo getAnimationInfo()
    {
        if (gameObject.GetComponent<masterInput>().currentClass == WeaponBase.weaponClassTypes.Knight)
            return animator.GetCurrentAnimatorStateInfo(0);
        else if (gameObject.GetComponent<masterInput>().currentClass == WeaponBase.weaponClassTypes.Engineer)
            return animator.GetCurrentAnimatorStateInfo(1);
        else if (gameObject.GetComponent<masterInput>().currentClass == WeaponBase.weaponClassTypes.Engineer)
            return animator.GetCurrentAnimatorStateInfo(2);
        else
               return animator.GetCurrentAnimatorStateInfo(0);
    }

    public IEnumerator startKnightBlock(float time)
    {
        animator.SetBool("blocking", true);
        animator.Play("startBlock");
        yield return new WaitForSeconds(time);
        animator.Play("blocking");
        yield break;
    }

    public IEnumerator stopKnightBlock(float time)
    {
        animator.SetBool("blocking", false);
        animator.SetBool("isWalking", false);
        animator.Play("stopBlock");
        yield return new WaitForSeconds(time);
        animator.Play("Locomotion");
        yield break;
    }

    public void blocking()
    {
        animator.SetBool("blocking", true);
        animator.SetBool("isWalking", true);
        animator.Play("blocking");
    }

    IEnumerator attackWait(float time, string animName)
    {
        yield return new WaitForSeconds(time);
        //if (getAnimationInfo().IsName("attack2") || getAnimationInfo().IsName("Attack3") || getAnimationInfo().IsName("engAttack3"))
            //yield break;
        //print("animation: " + animName);
        animator.Play(animName);
        yield break;
    }


    public void knightAttackOne(float time)
    {
        
        //if (getAnimationInfo().IsName("Attack2") || getAnimationInfo().IsName("Attack3"))
            //return;
        animator.SetBool("attack1", true);
        animator.Play("attackOne");
        StartCoroutine(attackWait(time, "waitOne"));
    }
    public void knightAttackTwo(float time)
    {
        animator.SetBool("attack1", false);
        animator.SetBool("attack2", true);
        animator.Play("attackTwo");
        StartCoroutine(attackWait(time, "waitTwo"));
    }

    public void knightAttackThree()
    {

        animator.SetBool("attack1", false);
        animator.SetBool("attack2", false);
        animator.SetBool("attack3", true);
        animator.Play("attackThree");

    }

    public void stop()
    {
        animator.StopPlayback();
        //resetKnight();
        //animator.enabled = !animator.enabled;
    }

    public void resetKnight()
    {
        if(animator.GetBool("attack3") == true)
        {
            animator.SetBool("attack1", false);
            animator.SetBool("attack2", false);
            animator.SetBool("attack3", false);
        }
        else if (animator.GetBool("attack2") == true)
        {
            animator.SetBool("attack1", false);
            animator.SetBool("attack2", false);
        }
        else
        {
            animator.SetBool("attack1", false);
        }
    }
    //-------------------------------------------------------

    //GUNNER ANIMATIONS--------------------------------------

    public void gunnerReload()
    {
        animator.SetBool("reload", true);
        animator.Play("Reload Blend Tree");
        animator.SetBool("reload", false);
    }


    //-------------------------------------------------------


    //Engineer Animations------------------------------------

    public void engAttackOne(float time)
    {
        if (getAnimationInfo().IsName("engAttackTwo") || getAnimationInfo().IsName("engAttackThree"))
            return;
        animator.SetBool("engAttack1", true);
        animator.Play("engAttackOne");
        StartCoroutine(attackWait(time, "engWaitOne"));
    }

    public void engAttackTwo(float time)
    {
        animator.SetBool("engAtack1", false);
        animator.SetBool("engAttack2", true);
        animator.Play("engAttackTwo");
        StartCoroutine(attackWait(time, "engWaitTwo"));
    }

    public void engAttackThree()
    {
        animator.SetBool("engAttack1", false);
        animator.SetBool("engAttack2", false);
        animator.SetBool("engAttack3", true);
        animator.Play("engAttackThree");
    }
    public void resetEngineer()
    {
        if (animator.GetBool("engAttack3") == true)
        {
            animator.SetBool("engAttack1", false);
            animator.SetBool("engAttack2", false);
            animator.SetBool("engAttack3", false);
        }
        else if (animator.GetBool("engAttack2") == true)
        {
            animator.SetBool("engAttack1", false);
            animator.SetBool("engAttack2", false);
        }
        else
        {
            animator.SetBool("engAttack1", false);
        }
    }

    //-------------------------------------------------------

    //Change animation layer---------------------------------

    public void changeClassLayer(int layerOne, int layerTwo)
    {
        animator.SetLayerWeight(layerOne, 0);
        animator.SetLayerWeight(layerTwo, 1);
    }


    //-------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}

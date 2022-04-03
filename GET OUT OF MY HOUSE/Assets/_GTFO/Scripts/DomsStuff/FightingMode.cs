using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingMode : MonoBehaviour
{
    public Animator startAnim;
    public bool isFighting;
    public GameObject enemy;
    public FPS playerLock; //Locks player

    float leanLeftAmount;
    float leanRightAmount;

     private bool isDodgeLeft; // Use these for A.I to tell when player dodges
     private bool isDodgeRight; // Use these for A.I to tell when player dodges

     private bool canDodgeL;
     private bool canDodgeR;

     private bool punchingLeft; //is punching L
     private bool punchingRight; //is punching R

    private bool canPunchL;
    private bool canPunchR;
    private bool canOverallDoIt;

    public float countDownTimer;
    public float punchTimer;
    
    float savedCounter;
    float savedPunch;
    Quaternion savedRot;

    private void Start()
    {
        savedRot = transform.rotation;
        savedCounter = countDownTimer;
        savedPunch = punchTimer;
        canDodgeL = true;
        canDodgeR = true;
        canPunchL = true;
        canPunchR = true;


    }
    private void Update()
    {
        if (isFighting)
        {
            playerLock.canLook = false;
            playerLock.canMove = false;

            LeftPunch();
            RightPunch();
            DodgeMode();

            if (isDodgeLeft && countDownTimer >= 0)
            {
                countDownTimer -= Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 10)), 10 * Time.deltaTime);


                if (countDownTimer <= 0)
                {
                    canPunchL = true;
                    canPunchR = true;
                    isDodgeLeft = false;
                    countDownTimer = savedCounter;
                    StartCoroutine(ReturnRot());

                }

            }
            

            if (isDodgeRight && countDownTimer >= 0)
            {
                countDownTimer -= Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -10)), 10 * Time.deltaTime);

                if (countDownTimer <= 0)
                {
                    canPunchL = true;
                    canPunchR = true;
                    isDodgeRight = false;
                    countDownTimer = savedCounter;
                    StartCoroutine(ReturnRot());
                }
            }

            if (punchingLeft && punchTimer >= 0)
            {
                startAnim.SetBool("punchLeft", true);
                punchTimer -= Time.deltaTime;

                if (punchTimer <= 0)
                {
                    startAnim.SetBool("punchLeft", false);

                    canOverallDoIt = true;

                    canPunchL = true;
                    canPunchR = true;
                    punchingLeft = false;
                    punchTimer = savedPunch;
                }
            }

            if (punchingRight && punchTimer >= 0)
            {
                startAnim.SetBool("punchRight", true);
                punchTimer -= Time.deltaTime;

                if (punchTimer <= 0)
                {
                    startAnim.SetBool("punchRight", false);

                    canPunchL = true;
                    canPunchR = true;
                    canOverallDoIt = true;
                    punchingRight = false;
                    punchTimer = savedPunch;
                }
            }


        }

       

    }

    private void DodgeMode()
    {

        if (canOverallDoIt)
        {
            if (canDodgeL)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (countDownTimer >= 0)
                    {
                        isDodgeLeft = true;
                        canDodgeR = false;
                        canDodgeL = false;
                        canPunchL = false;
                        canPunchR = false;


                    }
                }
            }

            if (canDodgeR)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (countDownTimer >= 0)
                    {
                        isDodgeRight = true;
                        canDodgeL = false;
                        canDodgeR = false;
                        canPunchL = false;
                        canPunchR = false;

                    }

                }
            }
        }


    }

    void LeftPunch()
    {
        if (canPunchL)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (punchTimer >= 0)
                {
                    punchingLeft = true;
                    canPunchR = false;
                    canPunchL = false;
                    canOverallDoIt = false;


                }

            }
        }
    }
    
    void RightPunch()
    {
        if (canPunchR)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                
                    if (punchTimer >= 0)
                    {
                        punchingRight = true;
                        canPunchL = false;
                        canPunchR = false;
                        canOverallDoIt = false;



                }

            }
        }
    }


    //When i come back make punchy haha.
    IEnumerator ReturnRot()
    {
        float timeElapsed = 0;
        float lerpDur = 1;

        while (timeElapsed < lerpDur)
        {
            transform.rotation = transform.rotation = Quaternion.Slerp(transform.rotation, savedRot, 10 * Time.deltaTime);

            timeElapsed += Time.deltaTime;
            yield return null;

        }
        yield return new WaitForSeconds(1.2f);
        canDodgeR = true;
        canDodgeL = true;
        canPunchL = true;
        canPunchR = true;




    }

    IEnumerator PunchCD()
    {
        yield return new WaitForSeconds(punchTimer);
        canDodgeR = true;
        canDodgeL = true;
        canPunchL = true;
        canPunchR = true;
    }



}

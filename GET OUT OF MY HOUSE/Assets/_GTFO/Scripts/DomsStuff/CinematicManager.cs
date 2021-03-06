using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    //In this manager we can have cinematic events happen, like the player waking up, talking to the phone, etc. 
    //Anything that involves locking player movement do it in HERE! - Dom

    public GameObject lockPlayer;

    public AudioManager audioManage;

    public GameObject eInteract;

    [Header("Player Event 1: Phone Answer")]

    public CinematicManager turnOffPhoneRing;

    private Vector3 direction;
    
    private Quaternion lookRot;
   
    public GameObject spawnEnemy;
    public GameObject phone;
    public GameObject flashLight;
    public GameObject arms;
    public GameObject throwHANDS;

    public bool playerLocked;
    public bool isEvent1;
    private bool playEvent1;
    private bool playCutscene;
    private bool endEvent;

    public float countDownTimer;

    public AudioSource talk;

    public Material skySwitch1;
    public Material skySwitch2;

    public GameObject creepySound;


    [Header("Player Event 2: The Light")]
    
    public GameObject light;
    public bool isEvent2;
    private bool playEvent2;

    [Header("Player Event 3: Wake Up")]
    public GameObject blackScreen;
    public bool playEvent3;
    public bool isEvent3;

    [Header("Player Event 4: Phone Ring")]
    public bool playEvent4;
    public bool isEvent4;
    public bool phoneRinging;
    private bool alreadyPlayed;
    public AudioSource phoneRing;


    private void Start()
    {
        endEvent = true;
        RenderSettings.skybox = skySwitch1;


    }

    private void Update() // Plays events
    {
        if(isEvent1 && endEvent)
        {

            if (Input.GetKeyDown(KeyCode.E) && playEvent1 == true && playerLocked == true && turnOffPhoneRing.phoneRinging == true)
            {
                PlayerEvent1();
                turnOffPhoneRing.playEvent4 = false;
                turnOffPhoneRing.phoneRing.Stop();
                audioManage.Play("phone_intro");

            }


            if (playCutscene)
            {
                PlayerEvent1_LookRot();

            }
        }

        if(isEvent2)
        {
            if (Input.GetKeyDown(KeyCode.E) && playEvent2 == true)
            {
                PlayerEvent2();
            }
        }

        if (isEvent3)
        {
            if (playEvent3 == true)
            {
                PlayerEvent3();
            }
        }

        if (isEvent4)
        {
            if (playEvent4 == true)
            {
                PlayerEvent4();
               
            }
        }


    }

    public void PlayerEvent1()
    {


        lockPlayer.GetComponent<FPS>().canLook = false;
        lockPlayer.GetComponent<FPS>().canMove = false;

        playCutscene = true;


       
    }

    public void PlayerEvent2()
    {
        light.SetActive(true);
        playEvent2 = false;
        //Turn on light switch option
    }

    public void PlayerEvent3()
    {
        lockPlayer.GetComponent<FPS>().canLook = false;
        lockPlayer.GetComponent<FPS>().canMove = false;

        if (countDownTimer >= 0)
        {
            countDownTimer -= Time.deltaTime;

        }

       
        if (countDownTimer <= 0)
        {
            audioManage.Play("glass_break");
            blackScreen.SetActive(false);
            lockPlayer.GetComponent<FPS>().canLook = true;
            lockPlayer.GetComponent<FPS>().canMove = true;
            playEvent3 = false;

        }
    }

    public void PlayerEvent4()
    {
        if (countDownTimer >= 0)
        {
            
            countDownTimer -= Time.deltaTime;
        }

        if (countDownTimer <= 0)
        {
            phoneRinging = true;
            if(alreadyPlayed == false)
            {
                phoneRing.Play();

                alreadyPlayed = true;
            }



        }
    }

    //Look rotation (PLAYEREVENT1)
    public void PlayerEvent1_LookRot()
    {
        if (playerLocked)
        {
            if (countDownTimer >= 0)
            {
                direction = (phone.transform.position - Camera.main.transform.position).normalized;
                lookRot = Quaternion.LookRotation(direction);

                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, lookRot, 5 * Time.deltaTime);


                countDownTimer -= Time.deltaTime;
            }


            //Countdown
            if (countDownTimer <= 0)
            {
                if (alreadyPlayed == false)
                {
                    audioManage.Play("sting");


                    alreadyPlayed = true;
                }
                direction = (spawnEnemy.transform.position - Camera.main.transform.position).normalized;
                lookRot = Quaternion.LookRotation(direction);

                throwHANDS.SetActive(true);

                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, lookRot, 5 * Time.deltaTime);

                Quaternion currentRotate = Camera.main.transform.rotation;
                //Raycast

                spawnEnemy.SetActive(true);

                RaycastHit hit;
                Vector3 enemyNewForward = spawnEnemy.transform.position - Camera.main.transform.position;
                Physics.Raycast(Camera.main.transform.position, enemyNewForward, out hit, 15);

                if (hit.transform.name == "Enemy")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        lockPlayer.transform.position =  new Vector3(spawnEnemy.transform.position.x, spawnEnemy.transform.position.y, spawnEnemy.transform.position.z);

                        throwHANDS.SetActive(false);

                        spawnEnemy.GetComponent<StateManager>().startMachine = true;
                        //Enable combat here also
                        lockPlayer.GetComponent<FightingMode>().isFighting = true;
                       
                        lockPlayer.GetComponent<FPS>().canLook = true;
                        
                        lockPlayer.GetComponent<FPS>().canMove = true;
                        
                        RenderSettings.skybox = skySwitch2;
                        RenderSettings.ambientIntensity = 1;
                        
                        lockPlayer.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
                        
                        flashLight.gameObject.SetActive(false);
                        
                        arms.gameObject.SetActive(true);
                        
                        playerLocked = false;
                        
                        endEvent = false;

                        creepySound.SetActive(false);

                        audioManage.Play("epic_sponge");

                        light.SetActive(true);
       

                    }
                }

                else 
                {
                    Debug.Log("No enemy");
                }


            }
        }

    }

    //Starts event
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            eInteract.SetActive(true);
            if (isEvent1)
            {
                playEvent1 = true;
                playerLocked = true;

            }

            if(isEvent2)
            {
                playEvent2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            eInteract.SetActive(false);

        }
    }



}

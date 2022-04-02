using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    //In this manager we can have cinematic events happen, like the player waking up, talking to the phone, etc. 
    //Anything that involves locking player movement do it in HERE! - Dom

    public GameObject lockPlayer;

    public List<GameObject> stuff = new List<GameObject>();
    

    [Header("Player Event 1: Phone")]
    
    private Vector3 direction;
    
    private Quaternion lookRot;
   
    public GameObject spawnEnemy;
    public GameObject phone;

    public bool playerLocked;
    public bool isEvent1;
    private bool playEvent1;
    private bool playCutscene;
    private bool endEvent;

    public float countDownTimer;

    public AudioSource talk;

    [Header("Player Event 2: The Light")]
    
    GameObject light;
    public bool isEvent2;
    private bool playEvent2;

    private void Start()
    {
        endEvent = true;
    }

    private void Update()
    {
        if(isEvent1 && endEvent)
        {
            if(Input.GetKeyDown(KeyCode.E) && playEvent1 == true && playerLocked == true)
            {
                PlayerEvent1();
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
                direction = (spawnEnemy.transform.position - Camera.main.transform.position).normalized;
                lookRot = Quaternion.LookRotation(direction);

                Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, lookRot, 5 * Time.deltaTime);

                Quaternion currentRotate = Camera.main.transform.rotation;
                //Raycast

                RaycastHit hit;
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5);

                if (hit.transform.name == "Enemy")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //Enable combat here also
                        lockPlayer.GetComponent<FPS>().canLook = true;
                        lockPlayer.GetComponent<FPS>().canMove = true;

                        lockPlayer.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);

                        playerLocked = false;
                        endEvent = false;
       

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
            if(isEvent1)
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

}

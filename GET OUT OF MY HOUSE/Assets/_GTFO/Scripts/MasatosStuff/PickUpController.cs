using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //prop components
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, itemContainer, fpsCam;
    public Enemy enemy;

    //values for the bash anim
    static float lerpSpeed = 0.3f;
    static float raiseSpeed = 0.4f;
    static float bashSpeed = 0.3f;
    
    //values for picking up and dropping
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    //bools
    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

        Vector3 distanceToEnemy = player.position - enemy.transform.position;
        //Bash if equipped and "E" is pressed and in range to enemy
        if (equipped && distanceToEnemy.magnitude <= enemy.attackRange && Input.GetMouseButtonDown(0)) StartCoroutine(Bash());
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        //if item is a prop, then explode
        GetComponent<Prop>()?.Explode();
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }

    IEnumerator Bash()
    {
        //sets up values
        float timeElapsed = 0;
        Vector3 basePos = player.position;
        Quaternion baseRot = player.rotation;

        Vector3 targetPos = enemy.attackLocation.position;
        Quaternion targetRot = Quaternion.LookRotation((enemy.transform.position - enemy.attackLocation.position).normalized);

        //lerping player to right place
        while (timeElapsed < lerpSpeed)
        {
            player.position = Vector3.Lerp(basePos, targetPos, timeElapsed / lerpSpeed);
            player.rotation = Quaternion.Slerp(baseRot, targetRot, timeElapsed / lerpSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //sets up values
        timeElapsed = 0;
        basePos = transform.position;
        targetPos = basePos;
        targetPos.y += 1.5f;

        //lerping object up
        while (timeElapsed < raiseSpeed)
        {
            transform.position = Vector3.Lerp(basePos, targetPos, timeElapsed / raiseSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        //sets up values
        timeElapsed = 0;
        basePos = transform.position;
        targetPos = enemy.transform.position;

        //lerping object towards the enemy
        while(timeElapsed < bashSpeed)
        {
            transform.position = Vector3.Lerp(basePos, targetPos, timeElapsed / bashSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Drop();
    }
}

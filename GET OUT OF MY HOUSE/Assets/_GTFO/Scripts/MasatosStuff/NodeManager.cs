using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Node[] nodes;
    [SerializeField] float speed = 2;
    int index = 0;

    public void ChangeNode()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        //sets up values
        float timeElapsed = 0;
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = enemy.transform.position;
        Quaternion playerRot = player.transform.rotation;
        Quaternion enemyRot = enemy.transform.rotation;

        if (index < nodes.Length)
        {
            Vector3 playerTargetPos = nodes[index].player.position;
            Vector3 enemyTargetPos = nodes[index].enemy.position;

            Quaternion playerTargetRot = nodes[index].player.transform.rotation;
            Quaternion enemyTargetRot = nodes[index].enemy.transform.rotation;

            //lerping player to right place
            while (timeElapsed < speed)
            {
                player.transform.position = Vector3.Lerp(playerPos, playerTargetPos, timeElapsed / speed);
                player.transform.rotation = Quaternion.Slerp(playerRot, playerTargetRot, timeElapsed / speed);
                enemy.transform.position = Vector3.Lerp(enemyPos, enemyTargetPos, timeElapsed / speed);
                enemy.transform.rotation = Quaternion.Slerp(enemyRot, enemyTargetRot, timeElapsed / speed);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            index++;
        }
        
        
    }
}

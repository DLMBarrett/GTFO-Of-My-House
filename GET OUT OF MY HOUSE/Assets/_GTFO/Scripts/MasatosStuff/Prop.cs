using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    [SerializeField] GameObject[] components;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Explode()
    {
        //for each piece of the prop,
        //sets collider and rigidbody
        //and removes parent
        foreach(GameObject piece in components)
        {
            piece.transform.SetParent(null);
            piece.GetComponent<Collider>().isTrigger = false;
            piece.GetComponent<Rigidbody>().isKinematic = false;
        }

        //destroys original object
        Destroy(this.gameObject);
    }
}

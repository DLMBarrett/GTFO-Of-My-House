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
        foreach(GameObject piece in components)
        {
            piece.transform.SetParent(null);
            piece.GetComponent<Collider>().isTrigger = false;
            piece.GetComponent<Rigidbody>().isKinematic = false;
        }

        Destroy(this.gameObject);
    }
}

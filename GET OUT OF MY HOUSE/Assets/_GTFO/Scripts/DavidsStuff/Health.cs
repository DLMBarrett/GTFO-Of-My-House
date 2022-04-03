using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int damagePerPunch = 10;
    private int currHealth;
    void Start()
    {
        maxHealth = 100;
    }
    
    public void Damage()
    {
        currHealth -= damagePerPunch;
    }

    public int GetHealth()
    {
        return currHealth;
    }

    public void ResetHealth()
    {
        currHealth = maxHealth;
    }
}

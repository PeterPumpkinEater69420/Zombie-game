using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
   public delegate void EnemyKilled();
   public static event EnemyKilled OnEnemyKilled;
    
    // Start is called before the first frame update
    void Start()
    {
        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
    }

    private void setColliderState(bool v)
    {
        throw new NotImplementedException();
    }

    public void die()
    {
        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);

        if (gameObject == null)
        {
        }
        else
        {
            Destroy(gameObject, 3f);
        }

        OnEnemyKilled?.Invoke();

    }

void setRigidbodyState(bool state)
{
    Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

    foreach (Rigidbody rigidbody in rigidbodies)
    {
        rigidbody.isKinematic = state;
    }
    GetComponent<Rigidbody>().isKinematic = !state;

}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunForceScript : NetworkBehaviour
{
    public GameObject parent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == parent)
            return;

        var target = collision.gameObject;
        var health = target.GetComponent<Health>();

        if (health != null)
            health.TakeDamage(2);

        Destroy(gameObject);
    }
}

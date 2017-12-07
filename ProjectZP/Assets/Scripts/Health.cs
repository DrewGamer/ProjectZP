using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    public GameObject deathExplosion;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();
        }
    }

    void OnChangeHealth(int newHealth)
    {
        currentHealth = newHealth;
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, gameObject.transform.Find("WIPship").rotation);

        NetworkServer.Spawn(explosion);

        Destroy(explosion, 2.2f);


        if (isLocalPlayer)
        {
            //GetComponentInParent<GunAmmo>().currentAmmo = GetComponentInParent<GunAmmo>().GetMaxAmmo() + 1;
            GetComponentInParent<GunAmmo>().CmdResetAmmo();

            //GetComponentInParent<LaserEnergy>().currentEnergy = 101;
            GetComponentInParent<LaserEnergy>().CmdLoseEnergy(-100);
            transform.position = Vector3.zero;
        }
    }

}

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GunAmmo : NetworkBehaviour
{
    public const float maxAmmo = 250;

    [SyncVar(hook = "OnChangeAmmo")]
    public float currentAmmo;

    public RectTransform ammoBar;

    private float maxToCurrentRatio;

    void Start()
    {
        currentAmmo = maxAmmo;
        maxToCurrentRatio = maxAmmo / 100;
        ammoBar.sizeDelta = new Vector2(ammoBar.sizeDelta.x, currentAmmo / maxToCurrentRatio);
    }

    public float GetMaxAmmo()
    {
        return maxAmmo;
    }

    [Command]
    public void CmdLoseAmmo(float amount)
    {
        currentAmmo -= amount;
    }

    void OnChangeAmmo(float newAmmo)
    {
        currentAmmo = newAmmo;
        ammoBar.sizeDelta = new Vector2(ammoBar.sizeDelta.x, currentAmmo/maxToCurrentRatio);
    }

    [Command]
    public void CmdResetAmmo()
    {
        currentAmmo = maxAmmo;
    }
}

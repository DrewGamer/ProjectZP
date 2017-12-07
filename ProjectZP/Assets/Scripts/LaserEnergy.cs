using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LaserEnergy : NetworkBehaviour
{
    public const float maxEnergy = 100;

    [SyncVar(hook = "OnChangeEnergy")]
    public float currentEnergy;

    public RectTransform energyBar;

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.sizeDelta = new Vector2(energyBar.sizeDelta.x, currentEnergy);
    }

    [Command]
    public void CmdLoseEnergy(float amount)
    { 
        currentEnergy -= amount;
    }

    [Command]
    public void CmdRegenEnergy()
    {
        currentEnergy += 0.2f;
        if (currentEnergy >= maxEnergy)
            currentEnergy = maxEnergy;
    }

    void OnChangeEnergy(float newEnergy)
    {
        currentEnergy = newEnergy;
        energyBar.sizeDelta = new Vector2(energyBar.sizeDelta.x, currentEnergy);
    }
}

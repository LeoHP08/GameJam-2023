using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health_Player playerHealth;
    [SerializeField] private UnityEngine.UI.Image totalhealthBar;
    [SerializeField] private UnityEngine.UI.Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 100f;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 100f;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
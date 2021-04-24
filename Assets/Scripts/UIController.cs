using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text coolDownText;
    [SerializeField]
    private Text lifeTimeText;
    [SerializeField]
    private GameObject deathPanel;

    private void Start()
    {
        if (instance) Destroy(this);
        instance = this;
    }

    public void SetSpeedText(string text)
    {
        speedText.text = text;
    }

    public void SetCoolDownText(string text)
    {
        coolDownText.text = text;
    }

    public void SetLifeTimeText(string text)
    {
        lifeTimeText.text = text;
    }

    public void ActivateDeathPanel()
    {
        deathPanel.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Start()
    {
        text.text = PlayerPrefs.GetFloat("deathTimer", -1f).ToString();
    }
}

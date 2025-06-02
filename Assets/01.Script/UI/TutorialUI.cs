using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public static TutorialUI Instance { get; private set; }
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private TextMeshProUGUI tutorialPrompt;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnPrompt (int tutorialIndex, string description)
    {
        Debug.Log($"Tutorial Index : {tutorialIndex}");
        tutorialPrompt.text = description;

        tutorialUI.SetActive(true);
    }

    public void OffPrompt()
    {
        tutorialUI.SetActive(false);
    }
}

using UnityEngine;

public class TutorialObstacle : MonoBehaviour
{
    [SerializeField] private int tutorialIndex;
    [SerializeField, TextArea(3, 10)] private string description;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TutorialUI.Instance == null)
            {
                Debug.LogError("TutorialUI.Instance is null!");
            }
            else
            {
                TutorialUI.Instance.OnPrompt(tutorialIndex, description);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TutorialUI.Instance.OffPrompt();
        }
    }
}

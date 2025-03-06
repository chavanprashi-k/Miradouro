using UnityEngine;
using UnityEngine.UI;

public class PhoneUIController : MonoBehaviour
{
    public GameObject messagePanel; // The ScrollView containing the chat image
    public Button messageButton;    // The button that opens the messages

    void Start()
    {
        // Set up the button click listener to show/hide the chat panel
        messageButton.onClick.AddListener(ToggleMessages);

        // Make sure the message panel starts hidden
        messagePanel.SetActive(false);
    }

    // Method to toggle visibility of the chat window
    void ToggleMessages()
    {
        // Toggle the active state of the message panel
        messagePanel.SetActive(!messagePanel.activeSelf);
    }
}

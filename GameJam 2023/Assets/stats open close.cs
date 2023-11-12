using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel; // Assign your UI panel in the Unity Editor

    void Start() =>
         // Ensure the UI panel is initially closed
         uiPanel.SetActive(false);

    void Update()
    {
        // Check if the 'M' key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle the visibility of the UI panel
            uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }
}
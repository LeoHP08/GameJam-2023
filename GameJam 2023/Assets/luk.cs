using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to show/hide
    public Button closeButton;   // Reference to the button that will close the UI

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the UI element is initially hidden
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }

        // Add a listener to the button's onClick event
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseUIElement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for button press to open the UI element (you can change "Fire1" to the button you want to use)
        if (Input.GetButtonDown("Fire1"))
        {
            // Toggle the visibility of the UI element
            showuielement();
        }
    }

    public void ToggleUIElement()
    {
        // Toggle the active state of the UI element
        if (uiElement != null)
        {
            uiElement.SetActive(!uiElement.activeSelf);
        }
    }
    public void showuielement()
    {
        // Toggle the active state of the UI element
        if (!uiElement.activeSelf)
        {
            uiElement.SetActive(true);
        }
    }

    void CloseUIElement()
    {
        // Close the UI element
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
    }
}
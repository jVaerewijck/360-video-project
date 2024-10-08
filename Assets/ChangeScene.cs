using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public List<Texture> textureList; // List to store textures
    private int currentIndex = 0; // Index to track the current texture
    public Material targetMaterial; // Material to update the texture
    public bool forward;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnButtonPressed);

        if (textureList.Count > 0)
        {
            targetMaterial.mainTexture = textureList[currentIndex]; // Display the first texture
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for button presses (replace with actual VR button press detection)
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) // Next texture
        {
            ShowNextTexture();
            Debug.Log("Right Arrow Pressed");
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame) // Previous texture
        {
            ShowPreviousTexture();
            Debug.Log("Left Arrow Pressed");
        }
    }

    void ShowNextTexture()
    {
        currentIndex = (currentIndex + 1) % textureList.Count; // Increment index and loop
        targetMaterial.mainTexture = textureList[currentIndex]; // Update displayed texture
    }

    void ShowPreviousTexture()
    {
        currentIndex = (currentIndex - 1 + textureList.Count) % textureList.Count; // Decrement index and loop
        targetMaterial.mainTexture = textureList[currentIndex]; // Update displayed texture
    }
    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (forward)
        {
            ShowNextTexture();
            Debug.Log("Right button pressed!");

        }
        else{
            ShowPreviousTexture();
            Debug.Log("Left button pressed!");
        }
        
        // Add your button press logic here
    }
}

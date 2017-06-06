using UnityEngine;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public class Interactible : MonoBehaviour
{
    private Material[] defaultMaterials;

    void Start()
    {
        // Add a BoxCollider if the interactible does not contain one.
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void GazeEntered()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Sphere")
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    void GazeExited()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Sphere")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}
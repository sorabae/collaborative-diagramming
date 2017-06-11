using UnityEngine;

public class PlusAction : MonoBehaviour
{
    GameObject connectedObject;
    LineRenderer lr;

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    private void Start()
    {
        // Add a BoxCollider if the interactible does not contain one.
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();

        }
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        GameObject parentComponent = transform.parent.gameObject;
        connectedObject = Instantiate(parentComponent, parentComponent.transform.parent);
        connectedObject.transform.Find("Text").GetComponent<TextMesh>().text = "";
        connectedObject.transform.position = parentComponent.transform.position + new Vector3(0.5f, 0.25f);

        GameObject line = new GameObject();
        //lr = line.AddComponent<LineRenderer>();
        line.AddComponent<EdgeManager>();
        GameObject[] connection = { gameObject.transform.parent.gameObject, connectedObject };
        line.SendMessage("OnConnectedToComponents", connection);
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        //lr.startColor = Color.blue;
        //lr.endColor = Color.blue;
    }

    /*private void Update()
    {
        if (lr != null)
        {
            lr.startWidth = 0.03f;
            lr.endWidth = 0.03f;

            lr.positionCount = 2;
            // Position of the selected cube
            Vector3 start = transform.parent.position;
            lr.SetPosition(0, start);
            // Position of the created cube
            Vector3 end = connectedObject.transform.position;
            lr.SetPosition(1, end);
        }
    }*/

    // Will be called after all regular rendering is done
    /*void OnPostRender()
    {
        if (connectedObject != null)
        {
            CreateLineMaterial();
            GL.PushMatrix();
            // Apply the line material
            lineMaterial.SetPass(0);

            // Set transformation matrix for drawing to
            // match our transform
            GL.MultMatrix(transform.localToWorldMatrix);

            // Draw lines
            GL.Begin(GL.LINES);
            // One vertex at transform position
            GL.Vertex3(transform.position.x, transform.position.y, transform.position.z);
            // Another vertex at edge of circle
            GL.Vertex3(connectedObject.transform.position.x, connectedObject.transform.position.y, connectedObject.transform.position.z);

            GL.End();
            GL.PopMatrix();
        }
    }*/


}


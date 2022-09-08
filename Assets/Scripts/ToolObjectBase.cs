using UnityEngine;

public class ToolObjectBase : MonoBehaviour
{
    [SerializeField]
    ToolInfo toolInfo;

    public void ToolLoad()
    {
        var mesh = GetComponent<MeshFilter>();
        mesh.mesh = toolInfo.mesh;
        transform.localScale *= 100;
        
    }
}

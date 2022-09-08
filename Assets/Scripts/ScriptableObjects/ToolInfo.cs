using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Tool", menuName ="Tools")]
public class ToolInfo : ScriptableObject
{
    public Mesh mesh;
    public Color32 toolColor;
    public int toolForce;
}

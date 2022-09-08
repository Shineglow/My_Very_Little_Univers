using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform selfTransform;

    [SerializeField]
    float angle;
    float height, radius; 
    const float heightMin = 3f, heightMax = 7f;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
        angle = 0;
        MoveCameraUp(2);
    }

    public void MoveCameraUp(float newHeight)
    {
        height += newHeight * -1;
        if (height > heightMax)
            height = heightMax;
        else if (height < heightMin)
            height = heightMin;

        radius = Mathf.Sqrt(height) + 1;
        RecalculatePosition();
    }

    public void RotateAround(float newAngle)
    {
        angle += newAngle;
        angle += angle > 180 ? -360f : angle < -180 ? 360f : 0f; 
        
        RecalculatePosition();
    }

    void RecalculatePosition()
    {
        var angleInRadians = angle * Mathf.Deg2Rad;
        selfTransform.localPosition = new Vector3(Mathf.Cos(angleInRadians) * radius, height, Mathf.Sin(angleInRadians) * radius);
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;

    [SerializeField]
    float movementSpeed = 6f;
    [SerializeField]
    float minimgSpeed = 6f;

    [SerializeField]
    float hitDamage = 2f;
    [SerializeField]
    float hitSpeed = 6f;
    private float rotationDelta = 0.2f;

    Rigidbody selfRB;

    BaseResource curentResource;

    

    private void Start()
    {
        selfRB = GetComponent<Rigidbody>();
    }

    public void MoveOn(Vector3 delta)
    {
        delta *= Time.deltaTime * movementSpeed;
        Debug.Log(delta);
        selfRB.MovePosition(transform.position + delta);
        RotateToForward(delta);
    }

    private void RotateToForward(Vector3 delta)
    {
        var a = GetTrueForwardVector(playerBody.rotation.eulerAngles.y);
        var angleDelta = Vector3.Angle(playerBody.TransformVector(a), delta) - 90;
        if (Mathf.Abs(angleDelta) > rotationDelta)
            playerBody.Rotate(0, rotationDelta * Mathf.Sign(angleDelta), 0, Space.World);
        else
            playerBody.Rotate(0, angleDelta, 0, Space.World);
    }

    private static Vector3 GetTrueForwardVector(float a)
    {
        return new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a));
    }

    public void StartAction(BaseResource resource, ResourceType rType)
    {
        curentResource = resource;
        switch (rType)
        {
            case ResourceType.WeakWood:
            case ResourceType.Wood:
            case ResourceType.HardWood:
                Cut();
                break;
            case ResourceType.Stone:
                break;
            case ResourceType.HardStone:
                break;
            case ResourceType.Crystal:
                break;
        }
    }

    private void Mine()
    {

    }

    private void Cut()
    {

    }

    private void Atack()
    {

    }
}

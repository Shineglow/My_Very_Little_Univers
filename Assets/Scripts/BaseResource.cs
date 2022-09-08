using UnityEngine;

public enum ResourceType
{
    WeakWood,
    Wood,
    HardWood,
    Stone,
    HardStone,
    Crystal
}

public class BaseResource : MonoBehaviour
{
    ResourceType resourceType;
    Color resourceColor;
    private void OnTriggerEnter(Collider other)
    {
        Player player;
        if (other.TryGetComponent<Player>(out player))
        {
            player.StartAction(this, resourceType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}

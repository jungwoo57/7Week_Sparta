using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("MapData")]
    [SerializeField] private int _bombCount;
    [SerializeField] private Vector3 playerStartPosition;
    public Vector3 PlayerStartPosition => playerStartPosition;
    [SerializeField] private Vector3 destination;
    public Vector3 Destination => destination;

}

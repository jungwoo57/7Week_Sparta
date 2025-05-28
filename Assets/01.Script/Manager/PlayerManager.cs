using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
}

using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public GameObject Player => _player;
}

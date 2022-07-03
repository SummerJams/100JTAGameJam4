using UnityEngine;

public class MineCollider : MonoBehaviour
{
    private Mine _mine;

    private void Start() => _mine = GetComponentInParent<Mine>();

    private void OnCollisionEnter2D(Collision2D collision) => _mine.Explosion();
}

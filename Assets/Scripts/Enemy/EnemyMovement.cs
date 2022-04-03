using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Min(0)] [SerializeField] private float speed = 5;
    private Vector3 movementDir = new Vector3(0, 0, 0);

    private void Update()
    {
        transform.position += movementDir * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        movementDir = dir;
    }

    public Vector3 GetDirection()
    {
        return movementDir;
    }
}

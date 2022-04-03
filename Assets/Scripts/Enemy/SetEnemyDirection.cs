using UnityEngine;

public class SetEnemyDirection : MonoBehaviour
{
    [SerializeField] private Vector3 dir;
    [SerializeField] private string enemyTag = "Enemy";
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == enemyTag)
        {
            Vector3 enemyPos = other.gameObject.transform.position;
            if(enemyPos.x > transform.position.x - 0.1f && enemyPos.x < transform.position.x + 0.1f
            && enemyPos.y > transform.position.y - 0.1f && enemyPos.y < transform.position.y + 0.1f)
            {
                EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
                if(enemyMovement.GetDirection() == dir) {return;}

                other.gameObject.transform.position = transform.position;
                enemyMovement.SetDirection(dir);
            }
        }
    }
}

using UnityEngine;

public class GoalEnemyDetection : MonoBehaviour
{
    [SerializeField] private string entityTag = "Enemy";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == entityTag)
        {
            GameManager._instance.DecreaseLife();
            Destroy(other.gameObject);
        }
    }
}

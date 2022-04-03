using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Min(0)] [SerializeField] private int damages = 1;
    [Min(0)] [SerializeField] private float speed = 5;
    [SerializeField] private string entityTag = "Enemy";
    private GameObject target = null;
    private Vector3 movementDir = new Vector3(0, 0, 0);

    void Update()
    {
        if(target)
        {
            UpdateDir();
            transform.position += movementDir * speed * Time.deltaTime;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void UpdateDir()
    {
        movementDir = (target.transform.position - transform.position).normalized;
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == entityTag)
        {
            other.GetComponent<Health>().DecreaseHealth(damages);
            print(other.GetComponent<Health>().GetHealth());
            Destroy(gameObject);
        }
    }
}

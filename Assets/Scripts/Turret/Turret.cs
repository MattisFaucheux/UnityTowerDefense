using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [Min(0)] [SerializeField] private float timeBetweenShoot = 1;
    [Min(0)] [SerializeField] private float shootingRange = 2;
    [SerializeField] private bool shootAtStart = true;
    [SerializeField] private LayerMask enemyLayer;
    private float currentTimer;
    private Collider2D turretPosition = null;

    void Start()
    {
        if(shootAtStart)
        {
            Shoot();
        }
        else
        {
            currentTimer = timeBetweenShoot;
        }
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, shootingRange, Vector2.zero, Mathf.Infinity, enemyLayer);

        if(!hit.collider) {return;}
        GameObject target = hit.collider.gameObject;

        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetTarget(target);

        currentTimer = timeBetweenShoot;
    }

    public void SetTurretPosition(Collider2D newTurretPosition)
    {
        turretPosition = newTurretPosition;
    }

    public Collider2D GetTurretPosition()
    {
        return turretPosition;
    }
}

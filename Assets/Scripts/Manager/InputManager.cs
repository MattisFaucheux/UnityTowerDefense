using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private LayerMask turretInteractiontionLayer;

    void Update()
    {
        if (Input.GetButtonDown("TurretInteract"))
        {
            Vector3 clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 click2D = new Vector2(clickpos.x, clickpos.y);

            RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero, Mathf.Infinity, turretInteractiontionLayer);
            Collider2D hitCollider = hit.collider;
            if (!hitCollider) {return;}

            Turret turret = hitCollider.gameObject.GetComponent<Turret>();
            if(turret)
            {
                turret.GetTurretPosition().enabled = true;
                Destroy(turret.gameObject);
            }
            else
            {
                GameObject turretObject = Instantiate(turretPrefab, hit.transform.position, Quaternion.identity);
                turretObject.GetComponent<Turret>().SetTurretPosition(hitCollider);
                hitCollider.enabled = false;
            }
                
        }
    }
}

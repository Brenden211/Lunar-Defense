using UnityEngine;

public class HeavyTurret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float fireRate = 0.5f;
    public float range = 2f;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public Transform partToRotate2;
    public float turnSpeed = 10f;

    public GameObject HeavyBulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Vector3 rotation2 = Quaternion.Lerp(partToRotate2.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation2.y, 0f);
        partToRotate2.rotation = Quaternion.Euler(0f, rotation2.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 0.5f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {

        GameObject HbulletGO = (GameObject)Instantiate(HeavyBulletPrefab, firePoint.position, firePoint.rotation);
        HeavyBullet Hbullet = HbulletGO.GetComponent<HeavyBullet>();

        if (Hbullet != null)
            Hbullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

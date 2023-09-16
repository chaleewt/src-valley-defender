using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCTower : MonoBehaviour
{
	private Transform target;

	[SerializeField]
	private Transform towerTurret; // Part to Rotate..

	[SerializeField]
	private Transform firePoint;

	[SerializeField]
	private GameObject projectilePrefab;

	[SerializeField]
	private string monsterTag = "Monster";

	[SerializeField]
	private float detectRange = 20f;

	[SerializeField]
	private float turretTurnSpeed = 1f; // Turret Turn Speed..

	[SerializeField]
	private float fireRate = 0.5f;

	[SerializeField]
	private float reloadTime = 1f;

	//private Transform monsterPostionLastFrame;

	private string towerType;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 2f); // default repeat rate 0.5f
	}

	void Update()
	{

		if (target == null)
		{
			return;
		}

		LockOnTarget();

		if (reloadTime <= 0f)
		{
			Fire();
			reloadTime = 1f / fireRate;
		}
		reloadTime -= Time.deltaTime;
	}

	void Fire()
	{
		GameObject instanceProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
		WCProjectile projectile = instanceProjectile.GetComponent<WCProjectile>();

		if (projectile)
		{
			projectile.Seek(target);
		}

		if (towerType == "CannonTower")
        {
			FindObjectOfType<WCSoundManager>().PlaySound("CannonShotSound");
		}

		if (towerType == "ArcherTower")
		{
			FindObjectOfType<WCSoundManager>().PlaySound("ArrowShotSound");
		}
	}

	void UpdateTarget()
	{
		GameObject[] monsters = GameObject.FindGameObjectsWithTag(monsterTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestMonster = null;
		foreach (GameObject monster in monsters)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, monster.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestMonster = monster;
			}
		}

		if (nearestMonster != null && shortestDistance <= detectRange)
		{
			target = nearestMonster.transform;
		}
		else
		{
			target = null;
		}
	}

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(towerTurret.rotation, lookRotation, Time.deltaTime * turretTurnSpeed).eulerAngles;
		towerTurret.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, detectRange);
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Placeable")
        {
			other.GetComponent<WCPlane>().PlanIsOccupied();
        }
    }

	public void SetTowerType(string type)
    {
		towerType = type;
    }
}

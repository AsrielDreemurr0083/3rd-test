using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerCreatorManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public float bulletSpeed = 10f;
    public float spawnRadius = 50.0f; 

    private Transform playerTransform;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            SpawnBullet();
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    void SpawnBullet()
    {
        // 플레이어 주변의 랜덤한 위치 계산
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomCircle.x, 0, randomCircle.y);

        // 플레이어 방향 계산
        Vector3 directionToPlayer = (playerTransform.position - spawnPosition).normalized;

        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.LookRotation(directionToPlayer));

        // 총알에 속도 적용
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = directionToPlayer * bulletSpeed;
        }

    }
}
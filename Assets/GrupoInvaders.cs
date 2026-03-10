using UnityEngine;

public class GrupoInvaders : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float shootInterval = 3f;
    public int maxEnemyBulletsOnScreen = 2;

    private float shootTimer = 0f;
    private invaders[] allInvaders;

    void Start()
    {
        allInvaders = GetComponentsInChildren<invaders>();
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            TryShoot();
            shootTimer = 0f;
        }
    }

    void TryShoot()
    {
        GameObject[] bulletsOnScreen = GameObject.FindGameObjectsWithTag("TiroInimigo");

        if (bulletsOnScreen.Length >= maxEnemyBulletsOnScreen)
            return;

        allInvaders = GetComponentsInChildren<invaders>();

        if (allInvaders.Length == 0)
            return;

        invaders shooter = allInvaders[Random.Range(0, allInvaders.Length)];

        Vector3 spawnPos = shooter.transform.position + new Vector3(0f, -0.5f, 0f);
        Instantiate(enemyBulletPrefab, spawnPos, Quaternion.identity);
    }
}
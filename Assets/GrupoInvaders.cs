using UnityEngine;
using UnityEngine.SceneManagement;

public class GrupoInvaders : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float shootInterval = 3f;
    public int maxEnemyBulletsOnScreen = 2;

    public Transform player;
    public string cenaVitoria = "History";

    private float shootTimer = 0f;
    private invaders[] allInvaders;
    private bool faseTerminou = false;

    void Start()
    {
        allInvaders = GetComponentsInChildren<invaders>();
    }

    void Update()
    {
        if (faseTerminou) return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            TryShoot();
            shootTimer = 0f;
        }

        VerificarSeInvadersChegaramNoPlayer();
        VerificarVitoriaCompleta();
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

    void VerificarSeInvadersChegaramNoPlayer()
    {
        if (player == null) return;

        allInvaders = GetComponentsInChildren<invaders>();

        if (allInvaders.Length == 0)
            return;

        float menorY = float.MaxValue;

        foreach (invaders inimigo in allInvaders)
        {
            if (inimigo != null && inimigo.transform.position.y < menorY)
            {
                menorY = inimigo.transform.position.y;
            }
        }

        if (menorY <= player.position.y)
        {
            faseTerminou = true;
            GameManager.instance.PerderVida();
        }
    }

    void VerificarVitoriaCompleta()
    {
        allInvaders = GetComponentsInChildren<invaders>();
        NaveMae naveMae = FindFirstObjectByType<NaveMae>();

        bool semInvaders = allInvaders.Length == 0;
        bool semNaveMae = naveMae == null;

        if (semInvaders && semNaveMae)
        {
            faseTerminou = true;
            SceneManager.LoadScene(cenaVitoria);
        }
    }
}
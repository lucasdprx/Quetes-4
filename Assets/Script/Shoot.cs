using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float TimeShoot = 4;
    [SerializeField] private float deceleration;
    [SerializeField] private float rotation;
    private PlayerHealth ph;
    private PlayerHealth ph2;
    void Start()
    {
        if (GameObject.Find("JoeBiden") != null) 
            if (GameObject.Find("JoeBiden").TryGetComponent<PlayerHealth>(out PlayerHealth temp)) 
                ph = temp;
        if (GameObject.Find("DonaldTrump") != null) 
            if (GameObject.Find("DonaldTrump").TryGetComponent<PlayerHealth>(out PlayerHealth temp)) 
                ph2 = temp;
                StartCoroutine(Despawn());
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(TimeShoot);
        Destroy(gameObject);
        if (ShootPlayer.turnPlayer)
        {
            ShootPlayer.turnPlayer = false;
            ShootPlayer.isShootPlayer = false;
            Timer.timeRemaining = 11;
        }
        else 
            ShootPlayer.turnPlayer = true;
            ShootPlayer.isShootIA = false;
            moveIA._direction.x = -moveIA._direction.x;
            Timer.timeRemaining = 11;
    }
    void Update()
    {
        gameObject.transform.Rotate( new Vector3(0, 0, rotation));
        rotation *= deceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "JoeBiden")
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            ph.TakeDamage(1);
            Destroy(gameObject);
            Timer.timeRemaining = 11;
            ShootPlayer.turnPlayer = false;
            ShootPlayer.isShootPlayer = false;
        }

        if (collision.gameObject.name == "DonaldTrump")
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            ph2.TakeDamage(1);
            Destroy(gameObject);
            Timer.timeRemaining = 11;
            ShootPlayer.turnPlayer = true;
            ShootPlayer.isShootIA = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Bal;
    [SerializeField] private float shootSpeed = 100f;
    [SerializeField] private GameObject posShoot;
    private Transform transformShoot;
    [Range(1, 20)] public float Gravity;
    public GameObject SpeedGizmo;
    public static bool turnPlayer = true;
    public static bool isShootIA = false;
    public static bool isShootPlayer = false;
    public GameObject Line;
    public static List<GameObject> compteur = new List<GameObject>();
    void Start()
    {
        transformShoot = posShoot.transform;
    }
    void Update()
    {
        if (PauseMenu.gameIsPaused == false && turnPlayer == true && isShootPlayer == false && Time.timeScale != 0)
        {
            Vector3 v = SpeedGizmo.transform.position - transform.position;
            Vector3 pCur = transform.position;
            if (Input.GetKey(KeyCode.W) && pCur.y < 25 && SpeedGizmo.transform.position.y < 30)
            {
                SpeedGizmo.transform.position += new Vector3(0, 1) / shootSpeed;
            }

            if (Input.GetKey(KeyCode.S) && pCur.y > 0 && SpeedGizmo.transform.position.y > 0)
            {
                SpeedGizmo.transform.position -= new Vector3(0, 1) / shootSpeed;
            }

            if (Input.GetKey(KeyCode.A) && pCur.x > -2 && SpeedGizmo.transform.position.x > -2)
            {
                SpeedGizmo.transform.position -= new Vector3(1, 0) / shootSpeed;
            }

            if (Input.GetKey(KeyCode.D) && pCur.x < 41 && SpeedGizmo.transform.position.x < 41)
            {
                SpeedGizmo.transform.position += new Vector3(1, 0) / shootSpeed;
            }

            for (int i = 0; i < compteur.Count; i++)
            {
                Destroy(compteur[i]);
            }


            for (int i = 0; i < 1000; i++)
                {
                    if (pCur.y < -4.0f || pCur.y > 21.0f || pCur.x > 42.0f || pCur.x < -4.0f)
                        break;
                    v += (Vector3.right + Gravity * Vector3.down) * Time.fixedDeltaTime;
                    Vector3 pNext = pCur + v * Time.fixedDeltaTime;

                    if (i < 40)
                    {
                        Debug.DrawLine(pCur, pNext, Color.red);

                        if (i % 2 == 0)
                        {
                        //compteur[i] = Instantiate(Line, pCur, Quaternion.identity);            
                        compteur.Add(Instantiate(Line, pCur, Quaternion.identity));
                        }
                    }
                    pCur = pNext;

                }

                


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(transformShoot, SpeedGizmo.transform.position - transform.position);
                isShootPlayer = true;
            }
        }
        if (isShootPlayer == true)
        {
            for (int i = 0; i < compteur.Count; i++)
            {
                Destroy(compteur[i]);
            }
        }
    }
    private void Shoot(Transform spawnbal, Vector2 shootDirection)
    {
        GameObject bal = Instantiate(Bal, spawnbal.position, Quaternion.identity);
        bal.GetComponent<Rigidbody2D>().velocity = shootDirection;

    }
    
}

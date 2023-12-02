using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class shootIA : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip sound;
    private float _timer = 0;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minRange;
    [SerializeField] private float _maxRange;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _stepForce;
    private Transform _transform;

    private float _angle = 270;
    private float _force = 0;


    private Vector2 _previousPositionBullet;
    private Vector2 _positionBullet;
    private Vector2 _acceleration = new Vector2(0, -9.80665f);
    private Vector2 _speedV;
    private bool _notFound = false;
    private Coroutine _coroutine;
    private Vector2 vSpawn = Vector2.zero;
    private bool _shot = false;
    private moveIA mIA;
    private void Awake()
    {
        _maxRange += Difficult.difficult * 2;
        _minRange -= Difficult.difficult * 2;
        _transform = transform;
        _positionBullet = _transform.position;
        mIA = GameObject.Find("JoeBiden").GetComponent<moveIA>();
    }
    private void FixedUpdate()
    {
        if (_timer < 3)
        {
            _timer += Time.fixedDeltaTime;
        }
        else
        {
            _previousPositionBullet = _transform.position;
            _speedV.x = Mathf.Cos(_angle * Mathf.Deg2Rad) * _force;
            _speedV.y = Mathf.Sin(_angle * Mathf.Deg2Rad) * _force;
            if (!mIA.is_move())
            {
                Coroutine(5);
            }

        }
    }
    private void Coroutine(int num)
    {
        float base_angle = 180 / num;
        _force += _stepForce;

        if (_force >= _maxForce)
        {
            _notFound = true;
            _force = 0;
            return;
        }

        for (int i = 0; i < num; i++)
        {
            float _angleOffSet = base_angle * i + 180;
            StartCoroutine(Search(_angle + _angleOffSet));
        }
    }

    IEnumerator Search(float angle)
    {
        if (ShootPlayer.turnPlayer == false && ShootPlayer.isShootIA == false)
        {
            {

            }
            _positionBullet = _transform.position;
            vSpawn.x = Mathf.Cos((angle) * Mathf.Deg2Rad) * _force * 1.01f;
            vSpawn.y = Mathf.Sin((angle) * Mathf.Deg2Rad) * _force * 1.01f;
            _speedV = vSpawn;
            for (int i = 0; i < 400; i++)
            {
                Debug.DrawLine(_previousPositionBullet, _positionBullet, Color.blue);
                _previousPositionBullet = _positionBullet;
                _speedV += _acceleration * Time.fixedDeltaTime;
                _positionBullet += _speedV * Time.fixedDeltaTime;
                RaycastHit2D[] _raycast = Physics2D.CircleCastAll(_positionBullet, 0.5f,
                    Vector2.zero);

                if (_positionBullet.y < -15)
                {
                    break;
                }
                foreach (var raycast in _raycast)
                {
                    if (raycast.collider.tag == "wall")
                    {
                        yield break;
                    }
                }
                if (_target.GetComponent<CapsuleCollider2D>().OverlapPoint(_positionBullet) && !_shot)
                {
                    audioSource.PlayOneShot(sound);
                    var _ball = Instantiate(_projectile, _transform.position, Quaternion.identity);
                    _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos((angle + Random.Range(_minRange, _maxRange)) * Mathf.Deg2Rad) * (_force + Random.Range(_minRange, _maxRange)) * 1.01f, Mathf.Sin((angle + Random.Range(_minRange, _maxRange)) * Mathf.Deg2Rad) * (_force + Random.Range(_minRange, _maxRange)) * 1.01f);
                    _shot = true;
                    _timer = 0;
                    moveIA._direction.x = -moveIA._direction.x;
                    ShootPlayer.isShootIA = true;
                    if (Random.Range(0, 100) < 50)
                    {
                        GameObject.Find("JoeBiden").GetComponent<moveIA>().Move(false);
                    }
                    else
                    {
                        GameObject.Find("JoeBiden").GetComponent<moveIA>().Move(true);
                    }
                    break;
                }

            }

            yield return new WaitForSeconds(1);
            _shot = false;
            yield return null;
        }
    }
    public bool is_not_found()
    {
        return _notFound;
    }

    public void set_is_not_found(bool state)
    {
        _notFound = state;

        _angle = 270;
        _force = 1;
    }

    public void reset_shot()
    {
        _shot = false;
    }
}
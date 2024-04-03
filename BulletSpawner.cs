using System.Collections;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    [SerializeField, Min(0)] private float _shootVelocity;
    [SerializeField, Min(0)] private float _timeBetweeShoot;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_timeBetweeShoot);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            Vector3 shootDirection = (_spawnPoint.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + shootDirection, Quaternion.identity);

            newBullet.transform.up = shootDirection;
            newBullet.velocity = shootDirection * _shootVelocity;

            yield return _delay;
        }
    }
}
using System.Collections;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    [SerializeField, Min(0)] private float _bulletVelocity;
    [SerializeField, Min(0)] private float _timeBetweeShoot;
    [SerializeField] private GameObject _bulletPrefab;
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
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position + shootDirection, Quaternion.identity);

            newBullet.transform.up = shootDirection;
            newBullet.GetComponent<Rigidbody>().velocity = shootDirection * _bulletVelocity;

            yield return _delay;
        }
    }
}

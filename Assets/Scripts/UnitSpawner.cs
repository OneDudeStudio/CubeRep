using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public float SpawnCoolDown;
    public float UnitSpeed;

    [SerializeField] private Transform _targetPoint;
    private Vector3 _unitTarget;

    [SerializeField] private Transform _spawnPoint;

    private float _spawnTimer;

    private void Update()
    {
        _unitTarget = _targetPoint.position;
        SpawnUnit();
    }

    public void SpawnUnit()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= SpawnCoolDown)
        {
            Unit unit = ObjectPool.SharedInstance.GetPooledObject();
            if (unit != null)
            {
                unit.transform.position = _spawnPoint.position;
                unit.transform.rotation = Quaternion.identity;
                unit.EnableUnit();
                unit.InitUnit(UnitSpeed, _unitTarget);
                _spawnTimer = 0;
            }
        }
    }

    public void ChangeSpeed(float speed)
    {
        UnitSpeed = speed;
    }
    public void ChangeSpawnCoolDown(float coolDown)
    {
        SpawnCoolDown = coolDown;
    }
}

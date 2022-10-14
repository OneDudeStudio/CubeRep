using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _unitSpeed;
    [SerializeField] private Vector3 _target;

    private void Update()
    {
        Locomotion();
    }

    private void Locomotion()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _unitSpeed * Time.deltaTime);
        transform.LookAt(_target);
        if (Vector3.Distance(transform.position, _target) < 0.1f)
        {
            DisableUnit();
        }
    }

    public void InitUnit(float speed, Vector3 target)
    {
        _unitSpeed = speed;
        _target = target;
    }

    public void EnableUnit()
    {
        gameObject.SetActive(true);
    }

    public void DisableUnit()
    {
        gameObject.SetActive(false);
    }
    
}

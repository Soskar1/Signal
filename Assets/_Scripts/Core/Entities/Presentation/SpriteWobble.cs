using UnityEngine;

public class SpriteWobble : MonoBehaviour
{
    [Header("Wobble Settings")]
    [SerializeField] private float rotationAmount = 10f;
    [SerializeField] private float speed = 10f;

    private float _timer;
    private Quaternion _baseRotation;

    void Start()
    {
        _baseRotation = transform.localRotation;
    }

    void Update()
    {
        ApplyWobble();
    }

    void ApplyWobble()
    {
        _timer += Time.deltaTime * speed;

        float tilt = Mathf.Sin(_timer) * rotationAmount;
        transform.localRotation = _baseRotation * Quaternion.Euler(0, 0, tilt);
    }
}
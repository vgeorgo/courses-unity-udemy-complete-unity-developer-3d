using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    protected float _movementFactor; // 0 not moved, 1 fully moved
    protected Vector3 _startingPos;

	void Start ()
    {
        _startingPos = transform.position;
    }
	
	void Update ()
    {
        // protecte against 0
        if (period <= Mathf.Epsilon)
            return;

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = _movementFactor * movementVector;
        transform.position = _startingPos + offset;
	}
}

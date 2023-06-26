using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private Transform projectilePrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private float launchForce = 1.5f;

    [SerializeField]
    private float trajectoryTimeStep = 0.05f;

    [SerializeField]
    private int trajectoryStepCount = 15;

    [SerializeField]
    private float gravityFactor = 0.9f;

    private GameObject _flare;
    private Vector2 _velocity, _startMousePos, _currentMousePos;
    private bool _startThrowing;
    private bool _throwing;
    
    private static readonly int MaterialColor = Shader.PropertyToID("_Color");

    private void Start() {
        lineRenderer.material.SetColor(MaterialColor, Color.yellow);
    }

    private void Update() {
        _flare = GameObject.FindGameObjectWithTag("Flare");

        if (_startThrowing) {
            if (Input.GetMouseButtonDown(0) && _flare == null) {
                _startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && _flare == null) {
                _currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _velocity = (_startMousePos - _currentMousePos) * launchForce;

                DrawTrajectory();
                RotateLauncher();
            }
        }

        if (!_throwing || _flare != null)
            return;
        
        FireProjectile();
        ClearTrajectory();
        _throwing = false;
    }

    public void SetStartThrowing() {
        _startThrowing = true;
    }

    public void SetThrowing() {
        _startThrowing = false;
        _throwing = true;
    }

    private void DrawTrajectory() {
        var positions = new Vector3[trajectoryStepCount];
        for (var i = 0; i < trajectoryStepCount; i++) {
            var t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + _velocity * t + Physics2D.gravity * (gravityFactor * t * t);

            positions[i] = pos;
        }

        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    private void FireProjectile() {
        var pr = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        pr.GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    private void RotateLauncher() {
        var angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void ClearTrajectory() {
        lineRenderer.positionCount = 0;
    }
}
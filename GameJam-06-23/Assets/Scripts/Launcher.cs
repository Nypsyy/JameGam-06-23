using UnityEngine;
using UnityEngine.Events;

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

    private GameObject _flare;

    private bool _mcFacingRight = true;

    private Vector2 _velocity, _startMousePos, _currentMousePos;

    private bool startThrowing;
    private bool throwing;

    private void Start() {
        lineRenderer.material.SetColor("_Color", Color.yellow);
    }

    private void Update() {
        _flare = GameObject.FindGameObjectWithTag("Flare");

        if (startThrowing == true)
        {

            if (Input.GetMouseButtonDown(1) && _flare == null)
            {
                _startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(1) && _flare == null)
            {
                _currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _velocity = (_startMousePos - _currentMousePos) * launchForce;

                DrawTrajectory();
                RotateLauncher();
            }

        }

        if (throwing == true)
        {
            if (Input.GetMouseButtonUp(1) && _flare == null)
            {
                FireProjectile();
                ClearTrajectory();
                throwing = false;
            }
        }
    }

    public void SetStartThrowing()
    {
        startThrowing = true;
    }

    public void SetThrowing()
    {
        startThrowing = false;
        throwing = true;

    }

    private void DrawTrajectory() {
        var positions = new Vector3[trajectoryStepCount];
        for (var i = 0; i < trajectoryStepCount; i++) {
            var t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + _velocity * t + Physics2D.gravity * (0.5f * t * t);

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

    private void Flip() {
        _mcFacingRight = !_mcFacingRight;
    }

    private void ClearTrajectory() {
        lineRenderer.positionCount = 0;
    }
}
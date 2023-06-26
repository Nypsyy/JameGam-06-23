using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Launcher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public LineRenderer lineRenderer;
    public float launchForce = 1.5f;
    public float trajectoryTimeStep = 0.05f;
    public int trajectoryStepCount = 15;
    public float gravityFactor = 0.9f;

    public GameObject _beanProjectile;
    private Vector2 _velocity, _startMousePos, _currentMousePos;
    private bool _startThrowing;
    public BeanAnimation beanAnimation;
    private static readonly int MaterialColor = Shader.PropertyToID("_Color");
    public float intensity = 0.25f;
    public float pointLightOuterRadius = 0.2f;
    public float pointLightInnerRadius = 0.75f;
    
    
    private void Start() {
        lineRenderer.material.SetColor(MaterialColor, Color.yellow);
    }

    private void Update() {
        if (!_startThrowing) return;
        _currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _velocity = (_startMousePos - _currentMousePos) * launchForce;

        DrawTrajectory();
        RotateLauncher();
    }

    public void StartThrowingProjectile() {
        
        _startThrowing = true;
        if (Camera.main != null)
            _startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void ThrowProjectile() {
        _startThrowing = false;
        FireProjectile();
        ClearTrajectory();
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
        var beanProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        beanProjectile.GetComponent<Rigidbody2D>().velocity = _velocity;
        var light = beanProjectile.GetComponent<Light2D>();
        light.intensity -= beanAnimation._currentAssetIndex * intensity;
        light.pointLightOuterRadius -= beanAnimation._currentAssetIndex * pointLightOuterRadius;
        light.pointLightInnerRadius -= beanAnimation._currentAssetIndex * pointLightInnerRadius;
    }

    private void RotateLauncher() {
        var angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void ClearTrajectory() {
        lineRenderer.positionCount = 0;
    }
}
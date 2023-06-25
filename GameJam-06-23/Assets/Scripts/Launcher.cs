using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Transform projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.05f;
    [SerializeField] int trajectoryStepCount = 15;

    private GameObject flare;

    private bool mc_FacingRight = true;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Start()
    {
        lineRenderer.material.SetColor("_Color", Color.yellow);
    }

    private void Update() 
    {
        flare = GameObject.FindGameObjectWithTag("Flare");
        if (Input.GetMouseButtonDown(0) && flare==null)
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && flare == null)
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos - currentMousePos) * launchForce;
            
            DrawTrajectory();
            RotateLauncher();
        }

        if (Input.GetMouseButtonUp(0) && flare == null)
        {
            FireProjectile();
            ClearTrajectory() ;
        }
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;
        }
        
        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    void FireProjectile() 
    {
        Transform pr = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        
        pr.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void RotateLauncher() 
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Flip() 
    {
        mc_FacingRight = !mc_FacingRight;
    }

    void ClearTrajectory() 
    {
        lineRenderer.positionCount = 0;
    }
}
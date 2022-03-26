using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] Transform[] pathPoints;
    [SerializeField] float moveSpeed;

    int currentPointIndex = 0;
    int changer = 1;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = pathPoints[currentPointIndex].position - transform.position;
        direction = (new Vector3(direction.x, 0, direction.z)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance())
        {
            GetNextIndex();
            direction = pathPoints[currentPointIndex].position - transform.position;
            direction = (new Vector3(direction.x, 0, direction.z)).normalized;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) <= 0.1f;
    }

    private void GetNextIndex()
    {
        if (currentPointIndex + changer >= pathPoints.Length || currentPointIndex + changer < 0)
            changer *= -1;

        currentPointIndex += changer;

    }
}

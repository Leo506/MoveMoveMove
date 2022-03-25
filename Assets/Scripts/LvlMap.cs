using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class LvlMap : MonoBehaviour
{
    NavMeshSurface surface;

    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

}

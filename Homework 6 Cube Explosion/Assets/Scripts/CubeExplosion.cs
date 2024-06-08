﻿using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Cube> cubes, Vector3 explosionCentrer)
    {
        foreach (Cube cube in cubes)
        {
            cube.TryGetComponent<Rigidbody>(out Rigidbody exploadableCube);
            exploadableCube.AddExplosionForce(_explosionForce, explosionCentrer, _explosionRadius);
        }
    }
}
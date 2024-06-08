using System.Collections.Generic;
using UnityEngine;

public class ExplosionToDelete : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube)
    {
        foreach (Rigidbody exploadableObject in GetExplodableObjects(cube))
        {
            float distansToCube = Vector3.Distance(cube.transform.position, exploadableObject.transform.position) / _radius;
            float forceImpact = Mathf.Lerp(_force / cube.transform.localScale.magnitude, 0, distansToCube);

            Instantiate(_effect, cube.transform.position, transform.rotation);
            exploadableObject.AddExplosionForce(forceImpact, cube.transform.position, _radius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _radius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
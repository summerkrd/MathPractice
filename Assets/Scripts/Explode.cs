using UnityEngine;

public class Explode
{
    private float _explotionForce = 5f;
    private float _explosionRadius = 5f;
    private float _upwardsModifier = 0f;

    public void DoExplode(Vector3 explosionPosition)
    {        
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            Iexplode iexplode = hit.GetComponent<Iexplode>();

            if (rigidbody != null && iexplode != null)
            {
                rigidbody.AddExplosionForce(_explotionForce, explosionPosition, _explosionRadius, _upwardsModifier, ForceMode.Impulse);               
            }
        }
    }
}

using Main.Character.Module;
using UnityEngine;

public class LookDebug : MonoBehaviour
{
    [SerializeField] private AVector2 _input;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _input.GetVector2() * 100f);
    }
}

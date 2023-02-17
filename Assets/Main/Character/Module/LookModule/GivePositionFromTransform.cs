using Main.Character.Module.LookModule;
using UnityEngine;

namespace Main.Character.LookModule
{
    public class GivePositionFromTransform : MonoBehaviour
    {
        
        [SerializeField] private LookToPositionLazy _lookToPositionLazy;
        [SerializeField] private Transform _transform;
        
        // Start is called before the first frame update
        void Update()
        {
            _lookToPositionLazy.SetTargetPosition(_transform.position);
        }

    
    }
}

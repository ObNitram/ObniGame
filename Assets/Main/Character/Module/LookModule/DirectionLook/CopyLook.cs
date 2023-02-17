using UnityEngine;

namespace Main.Character.Module.LookModule.DirectionLook
{
    public class CopyLook : MonoBehaviour
    {
        [SerializeField] private AVector2 _aDirectLookInput;
        [SerializeField] private AVector2 _aDirectLookOutput;

        // Update is called once per frame
        void Update()
        {
            _aDirectLookOutput.SetVector2(_aDirectLookInput.GetVector2());
        }
    }
}

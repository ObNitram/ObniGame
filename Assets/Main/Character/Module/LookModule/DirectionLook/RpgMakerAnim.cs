using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Main.Character.LookModule.DirectionLook
{
    [CreateAssetMenu(fileName = "RpgMakerAnim", menuName = "RpgMakerAnim", order = 0)]
    public class RpgMakerAnim : ScriptableObject
    {
        public Sprite[] sprites;
    }
}

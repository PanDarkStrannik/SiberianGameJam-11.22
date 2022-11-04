using UnityEngine;

namespace GameCore.Proto
{
    public class ProtoInstance : MonoBehaviour
    {
        [SerializeField] private ProtoData _protoData = new ProtoData();

        public ProtoData ProtoData => _protoData;
    }
}
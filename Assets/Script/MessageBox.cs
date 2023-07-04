using UnityEngine;

namespace Assets.Script
{
    public class MessageBox : MonoBehaviour
    {
        public int ImageNum;

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}

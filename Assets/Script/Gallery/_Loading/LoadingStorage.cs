using System;

namespace Assets.Script.Gallery._Loading
{
    public class LoadingStorage : ILoadingStorage
    {
        #region Singltone
        public static LoadingStorage Instance
        {
            get
            {
                return _instance;
            }
        }
        private static LoadingStorage _instance;
        #endregion

        private float _process;

        public LoadingStorage()
        {
            _instance = this;
            _process = 0;
        }

        public float GetProgress()
        {
            return _process;
        }

        public void SetProgress(float value)
        {
            _process = Math.Clamp(value, 0, 1);
        }

        public void AddProgress(float value)
        {
            _process += MathF.Abs(value);
            _process = Math.Clamp(_process += value, 0, 1);
        }
    }
}

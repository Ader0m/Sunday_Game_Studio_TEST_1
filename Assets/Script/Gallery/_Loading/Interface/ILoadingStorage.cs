namespace Assets.Script.Gallery._Loading
{
    public interface ILoadingStorage
    {
        public float GetProgress();
        public void SetProgress(float value);
        public void AddProgress(float value);
    }
}

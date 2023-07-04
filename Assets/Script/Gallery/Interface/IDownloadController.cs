namespace Assets.Script.Gallery
{
    public interface IDownloadController
    {
        public void LoadAll();

        public void SafetyLoadPicture(int i);

        public void LoadPicture(int i);

        public void AbortDownloads();
    }
}

namespace Assets.Script.Gallery
{
    public interface IErrorStorage
    {
        public string GetError(int ingNum);
        public void AddError(int ingNum, string error);
    }
}

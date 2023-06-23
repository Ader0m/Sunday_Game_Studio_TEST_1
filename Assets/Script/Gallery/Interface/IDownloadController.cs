using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

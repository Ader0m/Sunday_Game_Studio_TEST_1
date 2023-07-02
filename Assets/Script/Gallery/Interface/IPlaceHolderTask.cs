using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Gallery
{
    public interface IPlaceHolderTask
    {
        public void SetImgNum(int imgNum);
        public void SetTask(int imgNum);
    }
}

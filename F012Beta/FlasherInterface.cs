using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F012Beta
{
    /// <summary>
    /// Observer, when flasherButton clicked notify classes are attached to subject.
    /// </summary>
    public interface FlasherInterface
    {
        void UpdateFlash(SenderFlashStatus aFlasherButton);
    }
}

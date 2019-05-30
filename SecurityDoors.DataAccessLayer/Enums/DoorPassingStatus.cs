using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Enums
{
    public enum DoorPassingStatus
    {
        /// <summary>
        /// Без контроля.
        /// </summary>
        WithoutСontrol = 0,

        /// <summary>
        /// На контроле.
        /// </summary>
        OnControl = 1,

        /// <summary>
        /// Аннулирован.
        /// </summary>
        IsAnnul = 2
    }
}

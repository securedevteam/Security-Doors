﻿using Secure.SecurityDoors.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// DoorAction view model.
    /// </summary>
    public class DoorActionViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// AccessController identifier.
        /// </summary>
        public int AccessControllerId { get; set; }

        /// <summary>
        /// Card identifier.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public DoorActionStatusType Status { get; set; }

        /// <summary>
        /// Time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Card view model.
        /// </summary>
        public CardViewModel Card { get; set; }

        /// <summary>
        /// DoorReader view model.
        /// </summary>
        public DoorReaderViewModel DoorReader { get; set; }

        

        
    }
}

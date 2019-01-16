﻿using System;

namespace Mbc.Pcs.Net
{
    /// <summary>
    /// Interface that provide a Heart beat event and also a died event
    /// </summary>
    public interface IHeartBeat
    {
        /// <summary>
        /// The intervall time the heart will beat
        /// </summary>
        TimeSpan HeartBeatIntervall { get; set; }

        /// <summary>
        /// The beat of the heart
        /// </summary>
        event EventHandler<HeartBeatEventArgs> HeartBeats;

        /// <summary>
        /// Hert beat has exposed
        /// </summary>
        event EventHandler<HeartBeatDiedEventArgs> HeartDied;
    }
}

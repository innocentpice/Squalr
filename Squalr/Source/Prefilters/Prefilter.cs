﻿namespace Squalr.Source.Prefilters
{
    using Snapshots;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Filters the initial search space of a snapshot by filtering out unwanted sections.
    /// </summary>
    internal class Prefilter
    {
        /// <summary>
        /// Singleton instance of the <see cref="Prefilter"/> class.
        /// </summary>
        private static Lazy<Prefilter> snapshotPrefilterInstance = new Lazy<Prefilter>(
            () => { return new Prefilter(); },
            LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Prevents a default instance of the <see cref="SettingsPrefilter" /> class from being created.
        /// </summary>
        private Prefilter()
        {
            this.Prefilters = new List<ISnapshotPrefilter>();

            this.Prefilters.Add(new SystemModulePrefilter());
        }

        /// <summary>
        /// Gets or sets the list of prefilters to apply.
        /// </summary>
        private IList<ISnapshotPrefilter> Prefilters { get; set; }

        /// <summary>
        /// Gets a singleton instance of the <see cref="Prefilter"/> class.
        /// </summary>
        /// <returns>A singleton instance of the class.</returns>
        public static Prefilter GetInstance()
        {
            return Prefilter.snapshotPrefilterInstance.Value;
        }

        /// <summary>
        /// Gets the snapshot generated by the prefilter.
        /// </summary>
        /// <returns>The snapshot generated by the prefilter.</returns>
        public Snapshot GetPrefilteredSnapshot()
        {
            Snapshot snapshot = SnapshotManager.GetInstance().GetSnapshot(SnapshotRetrievalMode.FromSettings);

            foreach (ISnapshotPrefilter prefilter in this.Prefilters)
            {
                snapshot = prefilter.Apply(snapshot);
            }

            return snapshot;
        }
    }
    //// End class
}
//// End namespace
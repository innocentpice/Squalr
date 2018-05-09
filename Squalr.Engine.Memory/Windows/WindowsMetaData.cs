﻿namespace Squalr.Engine.Memory.Windows
{
    using PeNet;
    using PeNet.Structures;
    using Squalr.Engine.Logging;
    using Squalr.Engine.OS;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Class for getting static metadata in a remote process.
    /// </summary>
    internal class WindowsMetaData : IMetaData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsAdapter"/> class.
        /// </summary>
        public WindowsMetaData()
        {
            // Subscribe to process events
            Processes.Default.Subscribe(this);
        }

        /// <summary>
        /// Gets or sets a reference to the target process.
        /// </summary>
        public Process ExternalProcess { get; set; }

        private static Dictionary<String, PeFile> PeCache = new Dictionary<string, PeFile>();

        private static Object CacheLock = new Object();

        /// <summary>
        /// Recieves a process update. This is an optimization over grabbing the process from the <see cref="IProcessInfo"/> component
        /// of the <see cref="EngineCore"/> every time we need it, which would be cumbersome when doing hundreds of thousands of memory read/writes.
        /// </summary>
        /// <param name="process">The newly selected process.</param>
        public void Update(Process process)
        {
            this.ExternalProcess = process;
        }

        public IList<NormalizedRegion> GetDataSegments(UInt64 moduleBase, String modulePath)
        {
            List<NormalizedRegion> regions = new List<NormalizedRegion>();

            // Normalize module path format to avoid caching on variants
            DirectoryInfo modulePathInfo = new DirectoryInfo(modulePath);
            modulePath = modulePathInfo.ToString();

            try
            {
                PeFile file;

                lock (WindowsMetaData.CacheLock)
                {
                    if (WindowsMetaData.PeCache.ContainsKey(modulePath))
                    {
                        file = WindowsMetaData.PeCache[modulePath];
                    }
                    else
                    {
                        file = new PeFile(modulePath);
                    }
                }

                foreach (IMAGE_SECTION_HEADER section in file.ImageSectionHeaders)
                {
                    const UInt32 IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040;
                    const UInt32 IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080;

                    // TODO: Not sure whether these are really data
                    const UInt32 IMAGE_SCN_LNK_COMDAT = 0x00001000;
                    const UInt32 IMAGE_SCN_GPREL = 0x00008000;

                    if ((section.Characteristics & IMAGE_SCN_CNT_INITIALIZED_DATA) != 0 ||
                        (section.Characteristics & IMAGE_SCN_CNT_UNINITIALIZED_DATA) != 0 ||
                        (section.Characteristics & IMAGE_SCN_LNK_COMDAT) != 0 ||
                        (section.Characteristics & IMAGE_SCN_GPREL) != 0)
                    {
                        regions.Add(new NormalizedRegion(moduleBase + section.VirtualAddress, (Int32)section.VirtualSize));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, "Error parsing the PE of module: " + (modulePath ?? "{null}"), ex);
            }

            return regions;
        }
    }
    //// End class
}
//// End namespace
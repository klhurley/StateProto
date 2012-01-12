using System;
using System.Collections.Generic;
using System.Configuration;

namespace MurphyPA.H2D.TestApp.Properties
{
    public sealed partial class Settings
    {
        private static ApplicationSettingsBase defaultInstance;
        
        public Settings(ApplicationSettingsBase srcSettings)
        {
            defaultInstance = srcSettings;
        }

        public static ApplicationSettingsBase Default 
        {
            get 
            {
                return defaultInstance;
            }
        }

    }
}

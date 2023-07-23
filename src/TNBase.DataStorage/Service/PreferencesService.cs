using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNBase.Objects;

namespace TNBase.DataStorage.Service
{
    public class PreferencesService
    {
        private readonly ITNBaseContext context;
        private readonly ApplicationSettingsBase applicationSettings;

        public PreferencesService(ITNBaseContext context, ApplicationSettingsBase applicationSettings)
        {
            this.context = context;
            this.applicationSettings = applicationSettings;
        }

        public Preferences GetPreferences()
        {
            Preferences result;

            result = context.Preferences.FirstOrDefault();
            if (result == null)
            {
                result = new Preferences();
                result.ApplicationTitle = applicationSettings["AssociationName"] as string ?? "";
                result.LogoFileName = applicationSettings["Logo"] as string ?? "";
            }

            return result;
        }

        public void UpdatePreferences(Preferences preferences) {
            context.Preferences.Update(preferences);
            context.SaveChanges();
        }
    }
}

using System;

namespace Multiscan.Utils
{
    public static class Constants
    {
        // Path related
        public static readonly string FolderDocuments = Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments
        );
        public static readonly string FilepathDataJson = $"{FolderDocuments}/data.json";
        public static readonly string FilepathUserSettings = $"{FolderDocuments}/settings.xml";
        public static readonly string FilepathConfigYaml = $"{FolderDocuments}/settings.xml";
    }
}

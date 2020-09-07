using static System.Environment;

namespace LibSettings
{
    public class PathSettingOptions
    {
        public PathType PathType { get; }
        public bool? ExpectedToExist { get; }
        public SpecialFolder RootFolder { get; }
        public string? FileFilter { get; }

        public PathSettingOptions() : this(null, null, null, null) { }

        public PathSettingOptions(PathType? pathType = null, bool? expectedToExist = null, SpecialFolder? rootFolder  = null, string? fileFilter = null)
        {
            PathType = pathType ?? PathType.File;
            ExpectedToExist = expectedToExist;
            RootFolder = rootFolder ?? SpecialFolder.UserProfile;
            FileFilter = fileFilter;
        }
    }
}
using System;
using static System.Environment;

namespace LibSettings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PathSettingAttribute: SettingAttribute
    {
        public override object? Options => new PathSettingOptions(pathType, expectedToExist, rootFolder, fileFilter);

        private PathType pathType;
        public bool? expectedToExist = null;
        public SpecialFolder? rootFolder;
        public string? fileFilter;

        public PathSettingAttribute(string? name, PathType pathType = PathType.File) : base(SettingType.Path, name)
        {
            this.pathType = pathType;
        }
    }

    public enum PathType
    {
        File,
        Directory,
        Socket,
        Pipe,
        Device
    }
}

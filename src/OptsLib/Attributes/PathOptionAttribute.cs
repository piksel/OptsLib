using System;
using static System.Environment;

namespace OptsLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PathOptionAttribute: OptionAttributeBase
    {
        public override object? Options => new PathSettingOptions(pathType, ExpectedToExist, RootFolder, FileFilter);

        private readonly PathType pathType;
        public bool? ExpectedToExist = null;
        public SpecialFolder? RootFolder;
        public string? FileFilter;

        public PathOptionAttribute(string? name, PathType pathType = PathType.File) : base(OptionValueType.Path, name)
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

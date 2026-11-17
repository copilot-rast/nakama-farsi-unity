namespace PolicePatrol.Sdk.Editor
{
    public sealed class ContentFile
    {
        public ContentFile(string path, string sha256, long size)
        {
            Path = path;
            Sha256 = sha256;
            Size = size;
        }

        public string Path { get; }

        public string Sha256 { get; }

        public long Size { get; }
    }
}

namespace Medic.Entities
{
    public partial class FileType
    {
        public FileType Copy()
        {
            return base.Copy<FileType>(this);
        }
    }
}

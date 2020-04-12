using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class FileType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<FileType>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Name).IsRequired();
            });
        }
    }
}

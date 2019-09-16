using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class EventMap
    {
        public EventMap(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.ToTable("EVENT");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).HasColumnName("Event_Id");
            entityBuilder.Property(x => x.Title).HasMaxLength(100);
            entityBuilder.Property(x => x.Body).HasMaxLength(3000);
            entityBuilder.Property(x => x.PostedOn).HasColumnName("Posted_On").IsRequired();
            entityBuilder.Property(x => x.UpdatedOn).HasColumnName("Updated_On");
            entityBuilder.Property(x => x.PostedBy).HasMaxLength(450).HasColumnName("Posted_By").IsRequired();
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(450).HasColumnName("Updated_By");
            entityBuilder.Property(x => x.DisplayOrder).HasColumnName("Display_Order");
            //entityBuilder.Property(x => x.MediaTypeId).HasColumnName("Media_Type_Id");
            entityBuilder.Property(x => x.MediaId).HasColumnName("Media_Id");



        }

    }
}

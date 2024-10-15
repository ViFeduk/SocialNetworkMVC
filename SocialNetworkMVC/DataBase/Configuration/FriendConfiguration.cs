using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.DataBase.Configuration
{
    public class FriendConfiguration: IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("UserFriends").HasKey(p => p.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder
           .HasOne(f => f.User)
           .WithMany() // Предполагаем, что User может не иметь коллекции Friends, если это не нужно
           .HasForeignKey(f => f.UserId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

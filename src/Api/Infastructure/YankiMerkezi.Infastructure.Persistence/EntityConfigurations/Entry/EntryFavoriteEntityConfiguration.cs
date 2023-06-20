using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankiMerkezi.Api.Domain.Models;
using YankiMerkezi.Infastructure.Persistence.Context;
using YankiMerkezi.Infastructure.Persistence.EntityConfigurations.EntryComment;

namespace YankiMerkezi.Infastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", YankiMerkeziContext.DEFAULET_SCHEMA);

            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser)
               .WithMany(i => i.EntryFavorites)
               .HasForeignKey(i => i.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

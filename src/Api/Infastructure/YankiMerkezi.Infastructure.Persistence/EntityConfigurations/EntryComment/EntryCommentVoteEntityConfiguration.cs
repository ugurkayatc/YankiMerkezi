using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankiMerkezi.Api.Domain.Models;
using YankiMerkezi.Infastructure.Persistence.Context;

namespace YankiMerkezi.Infastructure.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", YankiMerkeziContext.DEFAULET_SCHEMA);

            builder.HasOne(i => i.EntryComment)
                .WithMany(i => i.EntryCommentVotes)
                .HasForeignKey(i => i.EntryCommentId);
        }
    }
}

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
    public class UserEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.User>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", YankiMerkeziContext.DEFAULET_SCHEMA);
        }
    }
}

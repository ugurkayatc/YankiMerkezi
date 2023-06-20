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
    public class EmailEntityConfirmation : BaseEntityConfiguration<Api.Domain.Models.EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", YankiMerkeziContext.DEFAULET_SCHEMA);
        }
    }
}

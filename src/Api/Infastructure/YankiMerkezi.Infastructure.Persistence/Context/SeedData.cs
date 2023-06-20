﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankiMerkezi.Api.Domain.Models;
using YankiMerkezi.Common.Infastructure;
using YankiMerkezi.Infastructure.Persistence.Extensions;

namespace YankiMerkezi.Infastructure.Persistence.Context
{
    internal class SeedData
    {
        private static List<User> GetUsers()
        {
            var result = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-20), DateTime.UtcNow))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.EmailAddress, i => i.Internet.Email())
                .RuleFor(i => i.NickName, i => i.Internet.UserName())
                .RuleFor(i => i.Password, i => PasswordEncryptor.Encryptor(i.Internet.Password()))
                .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
                .Generate(500);

            return result;

        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseNpgsql(Configuration.ConnectionString);
            var context = new YankiMerkeziContext(dbContextBuilder.Options);

            var users = GetUsers();
            var userIds = users.Select(i => i.Id);
            await context.Users.AddRangeAsync(users);


            var guids = Enumerable.Range(0, 150).Select(i => Guid.NewGuid()).ToList();
            int counter = 0;

            var entries = new Faker<Entry>("tr")
                .RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-20), DateTime.UtcNow))
                .RuleFor(i => i.Subject, i => i.Lorem.Sentence(10, 10))
                .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                .Generate(150);
            await context.Entries.AddRangeAsync(entries);

            var comments = new Faker<EntryComment>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.UtcNow.AddDays(-20), DateTime.UtcNow))
                .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                .RuleFor(i => i.EntryId, i => i.PickRandom(guids))
                .Generate(1000);
            await context.EntryComments.AddRangeAsync(comments);

            await context.SaveChangesAsync();
        }
    }
}

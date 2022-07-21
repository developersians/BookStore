using BookStore.Domain.Entities;
using BookStore.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            builder.HasData(
                Book.GetInstance("War and Peace", BookGenre.Fiction, 1, Convert.ToDateTime("1867/01/01"), 1),
                Book.GetInstance("The Diary of a Young Girl", BookGenre.NonFiction, 2, Convert.ToDateTime("1947/01/01"), 2)
                );
        }
    }
}

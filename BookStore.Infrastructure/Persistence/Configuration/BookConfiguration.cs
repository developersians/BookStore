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
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            builder.HasData(
                Book.GetInstance("War and Peace", BookGenre.Fiction, Author.GetInstance("Leo Tolstoy"), Convert.ToDateTime(1867)),
                Book.GetInstance("The Diary of a Young Girl", BookGenre.NonFiction, Author.GetInstance("Anne Frank"), Convert.ToDateTime(1947))
                );
        }
    }
}

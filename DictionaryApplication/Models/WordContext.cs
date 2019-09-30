using System;
using DictionaryApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DictionaryApplication.Models
{
    public partial class WordContext : DbContext
    {
        public WordContext()
        {
        }

        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@""); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.WordEn)
                    .IsRequired()
                    .HasColumnName("Word_En")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WordTr)
                    .IsRequired()
                    .HasColumnName("Word_Tr")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

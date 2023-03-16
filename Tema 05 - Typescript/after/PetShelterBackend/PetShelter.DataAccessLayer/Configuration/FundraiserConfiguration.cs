using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Configuration
{
    public class FundraiserConfiguration : IEntityTypeConfiguration<Fundraiser>
    {
        public void Configure(EntityTypeBuilder<Fundraiser> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(f => f.DonationTarget)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(f=>f.RaisedAmount).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(f => f.CreationTime).IsRequired();
            builder.Property(f=>f.DueDate).IsRequired();


            //// Relationship with Person
            //builder.HasMany(f => f.Donors)
            //         .WithMany(p => p.Fundraisers)
            //         .UsingEntity(j => j.ToTable("Donation"));

            //// Relationship with Donation
            //builder.HasMany(f => f.Donations)
            //         .WithOne(d => d.Fundraiser)
            //         .HasForeignKey(d => d.FundraiserId)
            //         .IsRequired();


            builder.HasOne(f => f.Owner).WithMany(p => p.Fundraisers).HasForeignKey(f=>f.OwnerId);


        }
    }
}

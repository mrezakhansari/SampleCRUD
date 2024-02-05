using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleCRUD.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "0a7f0aab-0033-4ee1-bd86-016d7765721f",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            },
            new IdentityRole
            {
                Id = "e8dd73a4-2e03-4001-a4f8-210b0abe0058",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            });
    }
}

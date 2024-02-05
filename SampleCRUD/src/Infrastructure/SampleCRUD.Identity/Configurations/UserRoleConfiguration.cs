using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleCRUD.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "0a7f0aab-0033-4ee1-bd86-016d7765721f",
                UserId = "b049abc6-0cae-4800-8bf6-3be35f1a975d"
            },
            new IdentityUserRole<string>
            {
                RoleId = "e8dd73a4-2e03-4001-a4f8-210b0abe0058",
                UserId = "1d170fe1-842e-4f0f-a7b9-3b150c30fdce"
            }
            );
    }
}

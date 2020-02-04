 using System.Threading.Tasks;
 using Microsoft.Extensions.Logging;
 using Microsoft.AspNetCore.Identity;
 using MiniBlog.Areas.Identity.Data;
 public class FirstTimeAdminRegistration 
 {
     private readonly ILogger<FirstTimeAdminRegistration> _logger;
     private readonly MiniBlogIdentityDbContext _context;
     private readonly UserManager<IdentityUser> _userManager;
     private readonly RoleManager<IdentityRole> _roleManager;

     public FirstTimeAdminRegistration(
        ILogger<FirstTimeAdminRegistration> logger,
        MiniBlogIdentityDbContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
     {
         _logger = logger;
         _context = context;
         _userManager = userManager;
         _roleManager = roleManager;
     }

     // Checks if the role 'Administrator' exists and if not creates the role.
     public async Task CheckOrCreateAdmin()
     {
         bool adminExists = await _roleManager.RoleExistsAsync("Administrator");
         if (!adminExists)
         {
             await _roleManager.CreateAsync(new IdentityRole("Administrator"));
         }
     }

    // Checks if the first user is an administrator or not.
     public async Task<bool> CheckIsThereAnAdmin()
     {
        var firstUser = await _context.Users.FindAsync("1");

        // If the users database is empty then it will return false.
        if (firstUser == null)
            return false;

        if (await _userManager.IsInRoleAsync(firstUser, "Administrator"))
            return true;

        // If there is no administrator the database return false.            
        return false;    
     }

    // Creates the admin user if it's not available.
     public async Task CreateAdministrator()
     {
        var firstUser = await _userManager.FindByEmailAsync("farhad@farhad.com");
        await _userManager.AddToRoleAsync(firstUser, "Administrator");
    }
 }
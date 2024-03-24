using Microsoft.AspNetCore.Identity;

namespace ContactMenager.API.Models
{
    //model użytkownika, pusty ale dodany w razie jak by była potrzeba modyfikacji. dziedziczy po identityUser ponieważ kożystam z paczki identity która dostarcza mechanizm logowania 
    public class ApplicationUser : IdentityUser
    {
    }
}

using Microsoft.AspNetCore.Identity;
using RunGroopWebAppp.Models;

namespace RunGroopWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public Address? Address { get; set; }

        public int? pace { get; set; }

        public int? Mileage { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public ICollection<Race> Races { get; set; }



    }
}

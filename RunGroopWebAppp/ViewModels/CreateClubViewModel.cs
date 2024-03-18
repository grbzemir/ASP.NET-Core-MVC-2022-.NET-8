using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;

namespace RunGroopWebAppp.ViewModels
{
    public class CreateClubViewModel
    {

        //public string Tittle { get; set; }

        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public IFormFile Image { get; set; }

        public ClubCategory ClubCategory { get; set; }
        public string Title { get; internal set; }
    }
}

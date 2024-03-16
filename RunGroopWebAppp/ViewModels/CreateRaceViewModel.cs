using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;

namespace RunGroopWebAppp.ViewModels
{
    public class CreateRaceViewModel
    {

        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public IFormFile Image { get; set; }

        public RaceCategory RaceCategory { get; set; }
        public string Title { get; internal set; }
    }
}

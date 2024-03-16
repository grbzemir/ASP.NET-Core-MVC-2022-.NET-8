using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;
using RunGroopWebAppp.Interfaces;
using RunGroopWebAppp.ViewModels;

namespace RunGroopWebAppp.Controllers
{
    public class ClubController : Controller
    {


        private readonly IClubRepository _clubRepository;
        private readonly IPhotoServices _photoServices;
        public ClubController( IClubRepository clubRepository , IPhotoServices photoServices)
        {

            _clubRepository = clubRepository;
            _photoServices = photoServices;
           
            
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs =await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)

        {

            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);


        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateClubViewModel clubVM)

        {

            if(ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(clubVM.Image);

                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        City = clubVM.Address.City,
                        Street = clubVM.Address.Street,
                        State = clubVM.Address.State,
                    }
                };

             _clubRepository.Add(club);
             return RedirectToAction("Index");

            
           }

            else

            {

                ModelState.AddModelError("", "Please fill all the fields");
            }

            return View(clubVM);
           
        }
          
    }
}

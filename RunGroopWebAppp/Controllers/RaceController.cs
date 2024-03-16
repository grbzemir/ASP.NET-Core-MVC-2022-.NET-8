using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;
using RunGroopWebAppp.Interfaces;
using RunGroopWebAppp.Repository;
using RunGroopWebAppp.Services;
using RunGroopWebAppp.ViewModels;

namespace RunGroopWebAppp.Controllers
{
    public class RaceController : Controller
    {

        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoServices _photoServices;

        public RaceController( IRaceRepository raceRepository , IPhotoServices photoServices)
        {

            _raceRepository = raceRepository;
            _photoServices = photoServices;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)

        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateRaceViewModel raceVN)

        {

            if (ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(raceVN.Image);

                var race = new Race
                {
                    Title = raceVN.Title,
                    Description = raceVN.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        City = raceVN.Address.City,
                        Street = raceVN.Address.Street,
                        State = raceVN.Address.State,
                    }
                };

                _raceRepository.Add(race);
                return RedirectToAction("Index");


            }

            else

            {

                ModelState.AddModelError("", "Please fill all the fields");
            }

            return View(raceVN);

        }

    }
}


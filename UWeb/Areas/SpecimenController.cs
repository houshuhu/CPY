using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UService.Repositories;

namespace UWeb.Areas
{
    public class SpecimenController : ApiController
    {
        private readonly ISpecimenRepository _specimenRepository;

        public SpecimenController(ISpecimenRepository specimenRepository)
        {
            _specimenRepository = specimenRepository;
        }

        [HttpPost]
        public void Add()
        {
            _specimenRepository.Save();
        }

        protected override void Dispose(bool disposing)
        {
            //_specimenRepository.Save();
            base.Dispose(disposing);
        }
    }
}

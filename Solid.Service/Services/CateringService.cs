using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service.Services
{
    public class CateringService : ICateringService
    {
        private readonly ICateringRepository _cateringRepository;
        public CateringService(ICateringRepository cateringRepository)
        {
            _cateringRepository = cateringRepository;
        }
        public IEnumerable<Catering> GetCaterings(bool? status)=>_cateringRepository.GetCaterings(status);
       

        public Catering GetCateringById(int id)=>_cateringRepository.GetCateringById(id);
        

        public Catering GetCateringByName(string name)=>_cateringRepository.GetCateringByName(name);


        public void AddCatering(Catering catering) => _cateringRepository.AddCatering(catering);
       

        public void UpdateCateringById(int id, Catering catering)=>_cateringRepository.UpdateCateringById(id, catering);
       

        public void UpdateCateringStatus(int id, bool status)=>_cateringRepository.UpdateCateringStatus(id, status);
        
    }
}

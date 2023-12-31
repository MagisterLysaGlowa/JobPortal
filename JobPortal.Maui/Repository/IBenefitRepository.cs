﻿using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface IBenefitRepository
    {
        Task<Benefit> AddBenefit(int jobOfertId,Benefit benefit);
        Task<List<Benefit>> GetBenefits(int jobOfertId);
        Task DeleteBenefitsByJobOfert(int jobOfertId);
    }
}

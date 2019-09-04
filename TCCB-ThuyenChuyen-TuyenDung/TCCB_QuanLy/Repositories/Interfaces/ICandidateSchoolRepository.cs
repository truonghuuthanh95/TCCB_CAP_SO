using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Repositories.Interfaces
{
    public interface ICandidateSchoolRepository
    {
        List<CandidateSchool> GetCandidateBySchoolId(int schoolId);
        CandidateSchool UpdateStatusCandidate(CandidateSchool candidateSchool);
        CandidateSchool GetCandidateSchoolById(int id);
        List<CandidateSchool> GetAllCandidatesSchool();
    }
}
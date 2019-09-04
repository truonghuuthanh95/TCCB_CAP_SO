using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;

namespace TCCB_QuanLy.Repositories.Implements
{
    public class CandidateSchoolRepository : ICandidateSchoolRepository
    {
        TCCBDB _db;

        public CandidateSchoolRepository(TCCBDB db)
        {
            _db = db;
        }

        public List<CandidateSchool> GetAllCandidatesSchool()
        {
            List<CandidateSchool> candidateSchools = _db.CandidateSchools.AsNoTracking()
                .Include("RegistrationInterview")
                .Include("RegistrationInterview.MonDuTuyen.ViTriUngTuyen")
                .Include("StatusTiepNhan")
                .Include("AccountSchool")
                .ToList();
            return candidateSchools;
        }

        public List<CandidateSchool> GetCandidateBySchoolId(int schoolId)
        {
            List<CandidateSchool> candidateSchools = _db.CandidateSchools.AsNoTracking()
                .Include("RegistrationInterview")
                .Include("RegistrationInterview.MonDuTuyen.ViTriUngTuyen")
                .Include("StatusTiepNhan")
                .Where(s => s.SchoolId == schoolId).ToList();
            return candidateSchools;
        }

        public CandidateSchool GetCandidateSchoolById(int id)
        {
            CandidateSchool candidateSchool = _db.CandidateSchools.Include("RegistrationInterview").Where(s => s.Id == id).SingleOrDefault();
            return candidateSchool;
        }

        public CandidateSchool UpdateStatusCandidate(CandidateSchool candidateSchool)
        {
            _db.Entry(candidateSchool).State = EntityState.Modified;

            _db.SaveChanges();

            return candidateSchool;
        }
    }
}
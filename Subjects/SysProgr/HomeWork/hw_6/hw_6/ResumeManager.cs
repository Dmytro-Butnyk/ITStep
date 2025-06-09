using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_6
{
    public class ResumeManager
    {
        public List<Resume> Resumes { get; set; }
        readonly string _path = "Resumes.json";

        public ResumeManager()
        {
            if (File.Exists(_path) && new FileInfo(_path).Length > 0)
                Resumes = JsonConvert.DeserializeObject<List<Resume>>(_path);
            else
                Resumes = new List<Resume>();
        }
        // Save & Read
        #region
        public void SaveChanges()
        {
            string json = JsonConvert.SerializeObject(Resumes, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
        public void ReadResumes()
        {
            if (File.Exists(_path) && new FileInfo(_path).Length > 0)
                Resumes = JsonConvert.DeserializeObject<List<Resume>>(_path);
            else
                Resumes = new List<Resume>();
        }
        #endregion

        public Resume GetMostExperiencedCandidate()
        {
            return Resumes.AsParallel().OrderByDescending(r => r.YearsOfExperience).FirstOrDefault();
        }

        public Resume GetLeastExperiencedCandidate()
        {
            return Resumes.AsParallel().OrderBy(r => r.YearsOfExperience).FirstOrDefault();
        }

        public IEnumerable<Resume> GetCandidatesFromCity(string city)
        {
            return Resumes.AsParallel().Where(r => r.City == city);
        }

        public Resume GetCandidateWithLowestSalaryExpectation()
        {
            return Resumes.AsParallel().OrderBy(r => r.ExpectedSalary).FirstOrDefault();
        }

        public Resume GetCandidateWithHighestSalaryExpectation()
        {
            return Resumes.AsParallel().OrderByDescending(r => r.ExpectedSalary).FirstOrDefault();
        }
    }
}

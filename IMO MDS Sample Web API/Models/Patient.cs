using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMO_MDS_Sample_Web_API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
​
        public List<Medication> medications;
        public List<Allergy> allergies;
        public List<Problem> problems;

        public Patient()
        {
            medications = new List<Medication>();
            allergies = new List<Allergy>();
            problems = new List<Problem>();
        }

        public Patient(int id, string name, int age, string gender, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            medications = new List<Medication>();
            allergies = new List<Allergy>();
            problems = new List<Problem>();
        }
​
        public void addMedication(Medication newMedication)
        {
            medications.Add(newMedication);
        }
​
        public void addAllergy(Allergy newAllergy)
        {
            allergies.Add(newAllergy);
        }
​
        public void addProblem(Problem newProblem)
        {
            problems.Add(newProblem);
        }
    }
}
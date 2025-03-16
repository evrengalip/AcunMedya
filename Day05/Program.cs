// Entities Katmanı
namespace Entities
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguage { get; set; }
    }
}

// Data Access Katmanı
namespace DataAccess
{
    using Entities;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }

    public class ProgrammingLanguageRepository : IRepository<ProgrammingLanguage>
    {
        private List<ProgrammingLanguage> _languages = new();

        public void Add(ProgrammingLanguage entity) => _languages.Add(entity);
        public void Delete(int id) => _languages.RemoveAll(l => l.Id == id);
        public void Update(ProgrammingLanguage entity)
        {
            var lang = _languages.FirstOrDefault(l => l.Id == entity.Id);
            if (lang != null) lang.Name = entity.Name;
        }
        public ProgrammingLanguage GetById(int id) => _languages.FirstOrDefault(l => l.Id == id);
        public List<ProgrammingLanguage> GetAll() => _languages;
    }

    public class TechnologyRepository : IRepository<Technology>
    {
        private List<Technology> _technologies = new();

        public void Add(Technology entity) => _technologies.Add(entity);
        public void Delete(int id) => _technologies.RemoveAll(t => t.Id == id);
        public void Update(Technology entity)
        {
            var tech = _technologies.FirstOrDefault(t => t.Id == entity.Id);
            if (tech != null) tech.Name = entity.Name;
        }
        public Technology GetById(int id) => _technologies.FirstOrDefault(t => t.Id == id);
        public List<Technology> GetAll() => _technologies;
    }
}

// Business Katmanı
namespace Business
{
    using DataAccess;
    using Entities;
    using System.Collections.Generic;

    public class ProgrammingLanguageManager
    {
        private IRepository<ProgrammingLanguage> _repository;
        public ProgrammingLanguageManager(IRepository<ProgrammingLanguage> repository)
        {
            _repository = repository;
        }
        public void AddLanguage(ProgrammingLanguage language) => _repository.Add(language);
        public List<ProgrammingLanguage> GetAllLanguages() => _repository.GetAll();
    }

    public class TechnologyManager
    {
        private IRepository<Technology> _repository;
        public TechnologyManager(IRepository<Technology> repository)
        {
            _repository = repository;
        }
        public void AddTechnology(Technology technology) => _repository.Add(technology);
        public List<Technology> GetAllTechnologies() => _repository.GetAll();
    }
}

// Core Katmanı
namespace Core
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}

// Presentation Katmanı
namespace Presentation
{
    using Business;
    using DataAccess;
    using Entities;
    using System;

    class Program
    {
        static void Main()
        {
            var languageRepo = new ProgrammingLanguageRepository();
            var languageManager = new ProgrammingLanguageManager(languageRepo);

            var techRepo = new TechnologyRepository();
            var techManager = new TechnologyManager(techRepo);

            Console.WriteLine("Bir programlama dili girin:");
            string languageName = Console.ReadLine();
            languageManager.AddLanguage(new ProgrammingLanguage { Id = 1, Name = languageName });

            Console.WriteLine("Bir teknoloji girin:");
            string techName = Console.ReadLine();
            techManager.AddTechnology(new Technology { Id = 1, Name = techName, ProgrammingLanguage = languageName });

            Console.WriteLine("Eklenen Programlama Dilleri:");
            foreach (var lang in languageManager.GetAllLanguages())
            {
                Console.WriteLine(lang.Name);
            }

            Console.WriteLine("Eklenen Teknolojiler:");
            foreach (var tech in techManager.GetAllTechnologies())
            {
                Console.WriteLine($"{tech.Name} ({tech.ProgrammingLanguage})");
            }
        }
    }
}

using HR.DAL.Domain;
using HR.Entities.GenericModels;
using HR.Entities.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDBContext _context;
        public UnitOfWork(HRDBContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            UserRolesRepository = new UserRolesRepository(_context);
            VacancyRepository = new VacancyRepository(_context);
            VacancyAppliersRepository = new VacancyAppliersRepository(_context);
        }

       
        public async Task<GenericResponse> CheckDbConnectionStatus()
        {
            var result = new GenericResponse();

            try
            {
                result.IsSuccessful = await _context.Database.CanConnectAsync();

                if (result.IsSuccessful)
                {
                    result.ResponseCode = CustomStatusCodes.Success;

                    result.ResponseMessages = new List<string> { $"Service is up and running {DateTime.Now.ToString()}" };
                }
                else
                {
                    result.ResponseCode = CustomStatusCodes.Failed;
                    result.ResponseMessages = new List<string> { "Cannot connect to the database or not found" };
                }
            }

            catch (Exception)
            {
                result.IsSuccessful = false;
                result.ResponseCode = CustomStatusCodes.Failed;
                result.ResponseMessages = new List<string> { "Cannot connect to the database or not found" };
            }
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IUserRepository UserRepository { get; set; }
        public IUserRolesRepository UserRolesRepository { get; set; }
        public IVacancyRepository VacancyRepository { get; set; }
        public IVacancyAppliersRepository VacancyAppliersRepository { get; set; }

    }
}

using System;
namespace SurveyManagement.Application.Abstractions
{
	public interface IUnitOfWork
	{
        IBaseRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}


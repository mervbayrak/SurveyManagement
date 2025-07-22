using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands.DeleteSurvey
{
    public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSurveyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var survey = await _unitOfWork.Repository<Survey>().GetByIdAsync(request.Id);

                if (survey is null)
                {
                    return false;
                }
                await _unitOfWork.Repository<Survey>().DeleteAsync(survey);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}


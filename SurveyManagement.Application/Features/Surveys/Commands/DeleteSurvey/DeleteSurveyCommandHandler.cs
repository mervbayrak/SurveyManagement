using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Domain.Exceptions;

namespace SurveyManagement.Application.Features.Surveys.Commands.DeleteSurvey
{
    public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand, SurveyResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSurveyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SurveyResult<bool>> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {

            var survey = await _unitOfWork.Repository<Survey>().GetByIdAsync(request.Id);

            if (survey is null)
            {
                throw new NotFoundException("Anket bulunamadı!");
            }

            await _unitOfWork.Repository<Survey>().DeleteAsync(survey);
            await _unitOfWork.SaveChangesAsync();

            return SurveyResult<bool>.Success(true, "Anket başarıyla silindi.");
        }
    }
}


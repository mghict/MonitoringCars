using Application.RecievedData.Commands;
using Application.RecievedData.Validation;
using AutoMapper;
using Common.Extensions;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecievedData.CommandHandlers
{
    public class RecievedDataCreateHandler : IRequestHandler<RecievedDataCreateCommand, FluentResults.Result>
    {
        private readonly Service.Services.RecievedDataService _service;
        private readonly IMapper _mapper;
        private readonly RecievedDataCreateValidation _validation;
        public RecievedDataCreateHandler(IMapper mapper, RecievedDataCreateValidation validation, Service.Services.RecievedDataService service)
        {
            _mapper = mapper;
            _validation = validation;
            _service = service;
        }

        //


        public async Task<Result> Handle(RecievedDataCreateCommand request, CancellationToken cancellationToken)
        {
            //return new Result();
            FluentResults.Result result = await FluentValidationExt.Validate(_validation, request);
            

            if (result.IsFailed)
            {
                return result;
            }

            try
            {
                var entity = _mapper.Map<Domain.Entities.RecievedData>(request);

                await _service.CreateData(entity);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;

        }
    }
}
